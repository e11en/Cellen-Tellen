using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Finan.View;

namespace Finan.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultController
    {

        private ResultView resultView;
        private DataGridView dataView;
        public SqlConnection connection;
        private MainView mainView;
        private MainController mainController;

        //used by AddInleesAndWijzigColumns()
        private bool isUsed = false;

        private List<int> checkedItems;

        public ResultController(MainController mainController)
        {
            this.mainController = mainController;
            this.resultView = mainController.resultView;
            this.mainView = mainController.mainView;
            this.dataView = resultView.dataView;
            this.connection = mainController.dbConnection.connection;
            checkedItems = new List<int>();
        }

        
        /// <summary>
        /// Create empty ResultController.
        /// </summary>
        public ResultController() { }

        //Initalise items
        public void Init()
        {
            //Set loading cursor while this method is running
            mainView.Cursor = Cursors.WaitCursor;
            //Try to Create and load database table data
            resultView.verwijderButton.Visible = mainController.isAdministrator;
            try
            {
                LoadTableData(true);
                AddInleesAndWijzigColumns();
            }
            catch (SqlException)
            {
                //Show mbox
                MessageBox.Show("Er zijn problemen met de verbinding naar de database, probeer het later nog eens of neem contact op met uw systeem beheerder.",
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Set selectec tab back to inlees
                mainView.tabPanels.SelectedIndex = 0;
            }
            finally
            {
                //Restore cursor
                mainView.Cursor = Cursors.Default;
            }



            resultView.searchBox.Text = "Zoek";

            resultView.radioButtonNummer.Checked = true;
        }

        /// <summary>
        /// Shows an message asking a user to delete selected records
        /// if user agrees then it will create an connection to the database
        /// After which it will loop through every valueIndex in checkedItems. Creating a delete query which removes the valueIndex from the database. And removing the image from the filestorage
        /// If an error occurs it is shown with a message containing what went wrong.
        /// After this it will close the connection if it is still open. Clear the resultList and refresh the datagridview.
        /// </summary>
        private void deleteSelected()
        {
            DialogResult result = MessageBox.Show("Weet u zeker dat u deze items wilt verwijderen", "Verwijder bevestiging", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    connection.Open();
                    foreach (int id in checkedItems)
                    {
                        DeleteImage(id);

                        string query = @"DELETE FROM Resultaat WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    checkedItems.Clear();
                    Init();
                }
            }
        }

        /// <summary>
        /// Checks if there is a checkbox selected.
        /// At the end the dataview is refreshed so any row that is deleted isn't shown again.
        /// When there is no checkbox selected it will look at highlighted cells.
        /// It will then collect all the cells in a resultList which will then be filtered for identical rows.
        /// After this step it will retrieve all the ID's from the datagridview.
        /// It will then execute the delete method.
        /// If nothing is selected it will show a message warning a user to select a field.
        /// </summary>
        public void RemoveRows()
        {

            if (checkedItems.Count > 0)
            {
                deleteSelected();
            }
            else if(resultView.dataView.SelectedCells.Count > 0)
            {
                List<int> Rows = new List<int>();
                foreach (DataGridViewCell cell in resultView.dataView.SelectedCells)
                {
                    Rows.Add(cell.RowIndex);
                }
                var uniqueRow = new HashSet<int>(Rows);
                foreach(int i in uniqueRow)
                {
                    checkedItems.Add((int)resultView.dataView["ID", i].Value);
                }
                deleteSelected();
            }
            else
            {
                MessageBox.Show("Selecteer een veld AUB");
            }
        }

        private void DeleteImage(int id)
        {
            try
            {
                string query = @"SELECT Path FROM Resultaat WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                string path = (string)cmd.ExecuteScalar();

                FtpController.DeleteFile(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Afbeelding van het geselecteerde afbeelding is niet gevonden", "Afbeelding niet gevonden.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Returns the table and fills it into the grid.
        /// If reset = true (which is only done when pagesize is changed) current page will be set to 0.
        /// This prevents that when the user is on page 30 and changes to size to i.e. 40 that the label shows : 30/3 (on page 30 of 3).
        /// If reset = false this will be ignored.
        /// </summary>
        /// <param name="reset"></param>
        public void LoadTableData(bool reset)
        {
            FillGrid();

            if (reset)
                CurrentPage = 0;

            int pageOn = CurrentPage + 1; // This is the current page + 1, so 0 isn't displayed.

            //Set the page label, example : 1/5 (you are on page / total amount of pages).
            mainController.resultView.currentPageLabel.Text = String.Format(pageOn + "/" + PageCount);

            //Try to open connection with database, throw exception
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (SqlException sqlE)
            {
                throw sqlE;
            }

            //WHERE E_Id NOT IN " + 
            //"(SELECT TOP " + intSkip + " E_Id FROM tblEmp)";
            int skip = (this.CurrentPage * this.PageSize);
            string query = @"SELECT TOP " + this.PageSize + " ID, Gebruiker, Verdunning, Kolonies, Datum, Temperatuur, " +
                            "Soort, Strain, Tijdsduur, Voedingsbodem, Bron FROM Resultaat WHERE ID NOT IN " +
                            "(SELECT TOP " + skip + " ID from dbo.Resultaat)";
            // ORDER BY ID desc
            // Create a command to extract the required data and assign it the connection string. It select the first 20 rows at first.
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;

            // Create a DataAdapter to run the command and fill the DataTable
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //Convert tijdsduur
            ConvertTableDataDate(ref dataTable);

            resultView.dataView.DataSource = dataTable;
            foreach (DataColumn dc in dataTable.Columns)
            {
                dc.ReadOnly = true;
            }
            if (connection.State == ConnectionState.Open)
                connection.Close();
            SetDataGridViewRowAsHighlighted();
        }

        //Change datatype and Convert time for Tijdsduur Column. 25 hours wil be converted to 1d and 1 hour using the CalculateDaysAndHours method.
        public void ConvertTableDataDate(ref DataTable dataTable)
        {
            /* 
             *  Create new dataTable with different dataTypes
             */
            //Clone datatable     
            DataTable dtCloned = dataTable.Clone();
            //change data type of column to string from int32
            dtCloned.Columns["Tijdsduur"].DataType = typeof(string);
            //import row to cloned datatable
            foreach (DataRow row in dataTable.Rows)
            {
                dtCloned.ImportRow(row);
            }

            //Set the new datatable
            dataTable = dtCloned;

            //Change the display for Tijdsduur to the wanted result, using the CalculateDaysAndHours method, eg. 6 dagen; 3 uur, instead of just eg. 45.
            foreach (DataRow dataRow in dataTable.Rows)
            {
                int tempData = Convert.ToInt32(dataRow["Tijdsduur"]);
                dataRow["Tijdsduur"] = CalculateDaysAndHours(tempData);
            }
        }

         

        //Calculates for example: 57 hours to 2 days and 9 hours.
        public string CalculateDaysAndHours(int time)
        {
            //Set timespawn to the given hours.
            TimeSpan tempTime = new TimeSpan(time, 0, 0);

            //
            //Check if there are days.
            //
            //Singleday
            if (tempTime.Days == 1) //returnValue = eg. 1 dag; 4 uur
            {
                //Zero hours
                if (tempTime.Hours == 0) //returnValue = 1 dag.
                {
                    return string.Format("{0} dag", tempTime.Days);
                }


                return string.Format("{0} dag & {1} uur", tempTime.Days, tempTime.Hours);
            }
            //Multiple days
            else if (tempTime.Days >= 2) //returnValue = eg. 2 dagen; 4 uur
            {
                //Zero hours
                if (tempTime.Hours == 0)
                {
                    return string.Format("{0} dagen", tempTime.Days);
                }


                return string.Format("{0} dagen & {1} uur", tempTime.Days, tempTime.Hours);
            }
            //If there are no days
            else //returnValue = eg. 4 uur
            {
                return string.Format("{0} uur", tempTime.Hours);
            }
        }

        public void AddInleesAndWijzigColumns()
        {
            if (!isUsed)
            {
                //Add "Inzien" and "Wijzig" colums with buttons.
                DataGridViewButtonColumn btnColumnInzien = new DataGridViewButtonColumn();
                btnColumnInzien.HeaderText = "Inzien";
                btnColumnInzien.Text = "Inzien";
                btnColumnInzien.UseColumnTextForButtonValue = true;
                dataView.Columns.Add(btnColumnInzien);

                DataGridViewButtonColumn btnColumnWijzig = new DataGridViewButtonColumn();
                btnColumnWijzig.HeaderText = "Wijzigen";
                btnColumnWijzig.Text = "Wijzig";
                btnColumnWijzig.UseColumnTextForButtonValue = true;
                dataView.Columns.Add(btnColumnWijzig);

                //Adds checkboxes to each row.
                DataGridViewCheckBoxColumn chkBoxColumn = new DataGridViewCheckBoxColumn();
                chkBoxColumn.HeaderText = "Selecteer";
                dataView.Columns.Add(chkBoxColumn);
                //Set is used to true so i cant be used again.
                isUsed = true;
            }
        }

        //Get result from the database. ID = the id from the selected row.
        public ResultModel GetDataFromDataBase(int id)
        {
            ResultModel resultModel = new ResultModel();
            String Kolonie_positie = "";

            //If connection is closed > open..if open, skip 
            int connOpen = 0;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                connOpen = 1;
            }

            //Query
            String query = @"SELECT * FROM Resultaat WHERE ID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("ID", id));

            //Read the result
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    resultModel.ID = (int)reader["ID"];
                    resultModel.Gebruiker = reader.GetString(1);
                    resultModel.Verdunning = (int)reader["Verdunning"];
                    resultModel.Kolonies = (int)reader["Kolonies"];
                    resultModel.Datum = (DateTime)reader["Datum"];
                    resultModel.Temperatuur = (int)reader["Temperatuur"];
                    resultModel.Soort = reader.GetString(6);
                    resultModel.Strain = reader.GetString(7);
                    resultModel.Tijdsduur = (int)reader["Tijdsduur"];
                    resultModel.Voedingsbodem = reader.GetString(9);
                    resultModel.Bron = reader.GetString(10).Trim();
                    resultModel.Medium = reader.GetString(11).Trim();
                    resultModel.Behandeling = reader["Behandeling"].ToString();
                    resultModel.FilePath = reader["Path"].ToString();
                    Kolonie_positie = reader["Kolonie_positie"].ToString();
                }

                // IF OPEN THEN CLOSE
                if (connOpen == 1)
                    connection.Close();
            }
            cmd.Parameters.Clear();
            Console.WriteLine(Kolonie_positie + "test");
            resultModel.ColonyList = GetColonyListFromString(Kolonie_positie);

            if (resultModel.ColonyList.Count > 0)
            {
                resultModel.Berekend = true;
            }

            return resultModel;
        }

        public void OpenResultDialog(DataGridViewCellEventArgs e, int id)
        {

            //Column inzien
            if (e.ColumnIndex == 0)
            {
                //Create dialog
                ResultDialogView resultDialogView = new ResultDialogView(false, mainController);//not editable

                //Fill the result with the result obtained from the getDatafromdatabase method, id = the ID from 
                //the selected row
                try
                {
                    resultDialogView.ResultModel = GetDataFromDataBase(id);
                    resultDialogView.SetImage();
                    resultDialogView.SetTextBox();
                    resultDialogView.DrawCircles();
                    resultDialogView.ShowDialog();
                }
                catch (SqlException)
                {
                    //Show mbox
                    MessageBox.Show("Er zijn problemen met de verbinding naar de database, probeer het later nog eens of neem contact op met uw systeem beheerder.",
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Column wijzig
            if (e.ColumnIndex == 1)
            {
                //Create dialog
                ResultDialogView resultDialogView = new ResultDialogView(true, mainController);//editable

                //Fill the result with the result obtained from the getDatafromdatabase method, id = the ID from 
                //the selected row
                try
                {
                    resultDialogView.ResultModel = GetDataFromDataBase(id);
                    resultDialogView.SetImage();
                    resultDialogView.SetTextBox();
                    resultDialogView.DrawCircles();
                    resultDialogView.ShowDialog();
                }
                catch (SqlException)
                {
                    //Show mbox
                    MessageBox.Show("Er zijn problemen met de verbinding naar de database, probeer het later nog eens of neem contact op met uw systeem beheerder.",
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Highlights the current selected row if it's checkbox is checked.
        /// </summary>
        /// <param name="e"></param>
        public void HighlightSelected(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                resultView.dataView.MultiSelect = true;
                if ((bool)resultView.dataView[2, e.RowIndex].FormattedValue == true)
                {
                  //  resultView.dataView[2, e.RowIndex].Value = false;
                    checkedItems.Remove((int)resultView.dataView["ID",e.RowIndex].Value);
                }
                else
                {
                 //   resultView.dataView[2, e.RowIndex].Value = true;
                    checkedItems.Add((int)resultView.dataView["ID", e.RowIndex].Value);
                    
                }
                
                SetDataGridViewRowAsHighlighted();
            }
        }
        
        /// <summary>
        /// Highlights all the rows that are contained in the checkedItems resultList
        /// It also checks the checkbox if it is found in the checkedItems 
        /// </summary>
        private void SetDataGridViewRowAsHighlighted()
        {
            int index = 0;
            foreach (DataGridViewRow dgvrow in resultView.dataView.Rows)
            {
                foreach (int id in checkedItems)
                {
                    if ((int)dgvrow.Cells[3].Value == id)
                    {
                        resultView.dataView.Rows[index].Selected = true;
                        resultView.dataView[2, index].Value = true;
                        break;
                    }
                    else
                    {
                        resultView.dataView.Rows[index].Selected = false;
                        resultView.dataView[2, index].Value = false;
                    }
                }
                index++;
            }
        }
        /// <summary>
        /// Returns a resultList of colonyModels from a string.
        /// </summary>
        /// <param name="kolonie_positie"></param>
        /// <returns></returns>
        public static List<ColonyModel> GetColonyListFromString(String kolonie_positie)
        {
            List<ColonyModel> list = new List<ColonyModel>();
            String[] colonyModelString = kolonie_positie.Split(';');
            foreach (String s in colonyModelString)
            {
                if (!s.Equals(""))
                {
                    float x = (float)Convert.ToDouble(s.Split('-')[0]);
                    float y = (float)Convert.ToDouble(s.Split('-')[1]);
                    float radius = (float)Convert.ToDouble(s.Split('-')[2]);
                    list.Add(new ColonyModel(new AForge.Point(x, y), radius));
                }
            }
            Console.WriteLine(list.Count);
            return list;
        }

        //EVERYTHING UNDER HERE IS USED FOR PAGING!
        public int CurrentPage = 0;                 // The current page the user is on. If the user is on page 7, current page will be 6.
        public int PageCount { get; set; }          // Amount of pages. If there are 10 pages, page count will be 10.
        public int TotalRecords { get; set; }       // Total amount of records.
        public int PageSize { get; set; }           // The page size (how many columns to return).

        /// <summary>
        /// Fill the attributes and properties. This is later called in LoadPage().
        /// </summary>
        public void FillGrid()
        {
            PageSize = (int)mainController.resultView.paginaGrootteNumberBox.Value;
            TotalRecords = GetCount();

            //Always round PageCount up. If its 2.1 it should be 3, if its 2.9 it also should be 3.
            if(PageSize < TotalRecords)
                PageCount = (int)Math.Ceiling((double)TotalRecords / (double)PageSize);

            //If the pagesize is bigger than totalrecords, pagecount should be 1 !
            else
            {
                PageCount = 1;
            }
           
        }

        /// <summary>
        /// Method returns amount of rows there are in the database.
        /// </summary>
        /// <returns>count</returns>
        public int GetCount()
        {
            //Count will be returned.
            int count = 0;
            //If connection is closed > open..if open, skip 
            int connOpen = 0;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                connOpen = 1;
            }

            //Select COUNT * returns the amount of rows there are.
            string query = "SELECT COUNT(*) FROM dbo.Resultaat";

            SqlCommand command = new SqlCommand(query, connection);

            //Execute the query and cast the result to int. count will be the value from the query
            count = (int)command.ExecuteScalar();

            command.Dispose();

            //Close the connection, only when it's open.
            if (connOpen == 1)
                connection.Close();

            return count;
        }

        /// <summary>
        /// When the go first button is pressed.
        /// When the user is at the first page, this won't run.
        /// When the user isn't at the first page, this will run.
        /// </summary>
        public void GoFirst()
        {
            if (CurrentPage != 0)
            {
                CurrentPage = 0;
                LoadTableData(false);
                SetDataGridViewRowAsHighlighted();

            }
        }

        /// <summary>
        /// When the go previous button is pressed.
        /// When the user ISN't at the first page this will run.
        /// When the user IS at the first page, this WON'T run.
        /// </summary>
        public void GoPrevious()
        {
            if (CurrentPage != 0)
            {
                CurrentPage--;
                LoadTableData(false);
                SetDataGridViewRowAsHighlighted();
            }
        }

        /// <summary>
        /// When the go next button is pressed.
        /// If the user isn't at the last page this will run.
        /// If the user IS at the last page, this WON'T run.
        /// </summary>
        public void GoNext()
        {
            if (CurrentPage != PageCount - 1)
            {
                CurrentPage++;
                LoadTableData(false);
                SetDataGridViewRowAsHighlighted();
            }
        }

        /// <summary>
        /// When the go last button is pressed, this will run. If the user isnt on the last page
        /// the current page will be set to the last page. if the user is on the last page, the page won't be changed.
        /// </summary>
        public void GoLast()
        {
            if (CurrentPage != PageCount - 1)
            {
                CurrentPage = PageCount - 1;
                LoadTableData(false);
                SetDataGridViewRowAsHighlighted();
            }
            
        }

        /// <summary>
        /// Returns a Array with arraylists ith the content of the selected columns
        /// </summary>
        /// <param name="dataGrid">The dataGrid with the selected data.</param>
        /// <returns></returns>
        public ArrayList[] getResultSelection(CustomDataGridView dataGrid)
        {
            ArrayList[] lijsten = new ArrayList[2];
            lijsten[0] = new ArrayList();
            lijsten[1] = new ArrayList();

            //Get number of unique columns.
            try
            {
                List<int> columns = new List<int>();
                foreach (DataGridViewTextBoxCell item in dataView.SelectedCells)
                {
                    columns.Add(item.ColumnIndex);
                }
                var unique_items = new HashSet<int>(columns);
                List<int> uniekeColumns = new List<int>();
                foreach (int i in unique_items)
                {
                    uniekeColumns.Add(i);
                }

                //if 1 of 2 colomns are selected.
                if (uniekeColumns.Count < 3 && uniekeColumns.Count > 0)
                {
                    int column1 = uniekeColumns[0];
                    int column2 = uniekeColumns.Count == 2 ? uniekeColumns[1] : 0;
                    ArrayList listColomn1 = new ArrayList();
                    ArrayList listColomn2 = new ArrayList();

                    //add to column resultList.
                    foreach (DataGridViewTextBoxCell item in dataView.SelectedCells)
                    {
                        if (item.ColumnIndex == column1)
                        {
                            listColomn1.Add(item.Value.ToString());
                        }
                        if (item.ColumnIndex == column2)
                        {
                            listColomn2.Add(item.Value.ToString());
                        }
                    }

                    //if both resultList are the same size or list2 is empty, set the lists to the arrayListOfArrayLists.      
                    if (listColomn1.Count == listColomn2.Count || listColomn2.Count == 0)
                    {
                        listColomn1.Reverse();
                        listColomn2.Reverse();
                        lijsten[0] = (listColomn1);
                        lijsten[1] = (listColomn2);

                        foreach (ArrayList a in lijsten)
                        {
                            foreach (String s in a)
                            {
                                Console.WriteLine(s);
                            }
                            Console.WriteLine();
                        }
                        List<int> lijst1 = StatisticCalculator.ConvertToList(lijsten[0]);
                        List<int> lijst2 = new List<int>();
                        if(listColomn2.Count != 0)
                            lijst2 = StatisticCalculator.ConvertToList(lijsten[1]);

                        //If the selection is only a string or string + string give a message
                        if (lijst1[0] == -1 && lijst2.Count == 0  || (lijst1[0] == -1 && lijst2[0] == -1))
                        {
                            MessageBox.Show("Selecteer a.u.b. ook getallen.", "Selectie bevat geen getallen.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            mainController.statisticView.ClearData();
                            //mainController.mainViewController.SelectTab(1);
                            lijsten = null;
                            return lijsten;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecteer twee evenlange kolommen a.u.b.", "Kolommen zijn niet even lang.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mainController.statisticView.ClearData();

                    }
                }
                else
                {
                    MessageBox.Show("Selecteer a.u.b. eerst één of twee kolommen in de resultaten tap.", "Er kan geen scatter plot van uw selectie gemaakt worden.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mainController.statisticView.ClearData();

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Sellecteer alleen kolom met tekst a.u.b.", "U mag geen knopjes selecteren.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mainController.statisticView.ClearData();
            }
            
            return lijsten;
        }
    }
}
