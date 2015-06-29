using System;
using System.Windows.Forms;
using Finan.Controller;
using System.Collections.Generic;
using System.Collections;

namespace Finan
{
    public partial class ResultView : UserControl
    {
        private MainController mainController;
        private ResultController resultController;
        public ArrayList[] selectedColums;


        public ResultView(MainController mainController)
        {
            InitializeComponent();
            this.mainController = mainController;
            this.resultController = mainController.resultController;

            Nummer.ReadOnly = true;
            Gebruiker.ReadOnly = true;
            Datum.ReadOnly = true;
            Bodem.ReadOnly = true;
            Verdunning.ReadOnly = true;
            Kolonies.ReadOnly = true;
        }


        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//13 = enter
            {
                MessageBox.Show(searchBox.Text);
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Zoek")
            {
                searchBox.Text = "";
            }
        }

        //On searchBox leave
        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text.Equals(""))
            {
                searchBox.Text = "Zoek";
            }
        }
        private void DataView_On_Content_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                resultController.HighlightSelected(e);
            }
            catch (Exception) { }

        }
        //On dateView click
        private void dataView_onCellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.resultController = mainController.resultController;
            int id = 0;

            try
            {
                //Gets the ID from the selected row
                id = (int)dataView.Rows[e.RowIndex].Cells[3].Value;
            }

            //When user clicks on the DataGrid header (ID,GEBRUIKER, ETC.)
            //
            catch (ArgumentOutOfRangeException)
            {
            }
            resultController.OpenResultDialog(e, id);
        }

        // When the 'First page' button is clicked >> go to the first page there is.
        private void firstPageButton_Click(object sender, EventArgs e)
        {
            mainController.resultController.GoFirst();
        }

        // When the 'Previous page' button is clicked >> go to the previous page.
        private void previousPageButton_Click(object sender, EventArgs e)
        {
            mainController.resultController.GoPrevious();
        }

        // When the 'Next page' button is clicked >> go to the next page.
        private void nextPageButton_Click(object sender, EventArgs e)
        {
            mainController.resultController.GoNext();
        }

        // When the 'Last page' button is clicked >> go to the last page there is.
        private void lastPageButton_Click(object sender, EventArgs e)
        {
            mainController.resultController.GoLast();
        }

        //When the user changes the value start loadtabledata. The parameter true = to reset the current page to 0.
        private void paginaGrootteNumberBox_ValueChanged(object sender, EventArgs e)
        {
            mainController.resultController.LoadTableData(true);
        }

        //When the user pressed 'enter' on the numberbox > run loadtabledata. The parameter true resets the currentpage to 0.
        private void paginaGrootteNumberBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyData)
            {
                mainController.resultController.LoadTableData(true);
            }
        }

        //Remove the rows when the user clicks verwijder button.
        private void VerwijderButton_Click(object sender, EventArgs e)
        {
            mainController.resultController.RemoveRows();
        }

        private void exporteerButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Whenever the user clicks on Statistic he will be redirected to the third label with the correct data filled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statisticButton_Click(object sender, EventArgs e)
        {
            mainController.statisticController.GetSelectedData();
            mainController.statisticController.CreateBoxPlots(mainController.statisticController.statisticsList);

        }

    }
}
