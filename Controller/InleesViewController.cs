using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Data;

namespace Finan.Controller
{
    public class InleesViewController
    {
        private string fileStorage;
        public InleesView inleesView;
        public MainController mainController;
        public ResultModel currentModel;

        public InleesViewController(MainController mainController)
        {
            this.inleesView = mainController.inleesView;
            this.mainController = mainController;
            //Sets the location for image storage
            this.fileStorage = Application.StartupPath + @"\"; //TODO: WIJZIG DIT IN LATERE SPRINT
        }

        /// <summary>
        /// Adds pictures to the multi view panel in the proper position. 
        /// Position example: ([] = picture)
        /// [][][][][][][]
        /// [][][][][][][]
        /// [][][]
        /// </summary>
        public void AddPicture()
        {
            CustomPanelView panel = mainController.inleesView.inleesImageListView;
                      
            // SET PICTUREBOX TO RESULTMODEL IMAGE
            //Panel X and Y location cords
            int xStart = 0;
            int yStart = 0;

            int xIndex = 0;
            int yIndex = 0;
            
            int x = xStart;
            int y = yStart;

            //For the new position of a new panel
            int xlocationSpread = 110;
            int ylocationSpread = 110;

            int imageSize = 100;
            int correctionValue = 30;

            //Clear the panel
            panel.Controls.Clear();

            foreach (ResultModel result in mainController.resultModelList.Reverse<ResultModel>())
            {
                x = xIndex * xlocationSpread;

                if (x + imageSize + correctionValue > mainController.inleesView.inleesImageListView.Width)
                {
                    yIndex++;
                    y = yIndex * ylocationSpread;

                    xIndex = xStart;
                    x = xIndex * xlocationSpread;
                }

                //Panel layout
                result.panel.Location = new System.Drawing.Point(x, y);
                result.panel.Size = new System.Drawing.Size(imageSize, imageSize);
                result.panel.BackgroundImageLayout = ImageLayout.Zoom;
                result.panel.Tag = result.Index;
                //result.panel.Click += new System.EventHandler(panel_Click);
                inleesView.inleesImageListView.Controls.Add(result.panel);

                xIndex++;
            }

        }

        private int[] CalculatePanelPosition(int x)
        {
            int maxPanels = 4;

            var point = new int[2];
            point[0] = x * 110 + 20;
            point[1] = 10;

            var row = mainController.resultModelList.Count / maxPanels;
            if (mainController.resultModelList.Count == maxPanels)
                row = 0;

            if (row > 0)
            {
                if (x >= maxPanels)
                {
                    point[1] = 120;
                    if (x >= maxPanels) { point[0] = (x - maxPanels) * 110 + 20; }
                }

                if (x >= maxPanels * 2)
                {
                    point[1] = 230;
                    if (x >= maxPanels) { point[0] = (x - maxPanels) * 110 + 20; }
                }
            }
            return point;
        }

        public void panel_Click(object sender, EventArgs e)
        {
            // SAVE CURRENT MODEL TO RESULT MODEL
            SaveToModel();

            if (inleesView.temporaryPanel != null)
            {
                inleesView.temporaryPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
            //Set selection and remove selection from other
            Panel t = (Panel)sender;

            // SET CURRENT MODEL
            currentModel = mainController.resultModelList[(int)t.Tag];
            t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            inleesView.currentResult = currentModel;
            inleesView.pictureBox.Image = inleesView.currentResult.ResultImage;
            inleesView.temporaryPanel = t;

            SetTextFields();
            inleesView.SetButtons(currentModel.Berekend);
            mainController.colonyController = new ColonyController();

            inleesView.OptionSelect = 0;
            inleesView.DrawCircles();
            inleesView.pictureBox.Invalidate();
            inleesView.erp.Clear();
            inleesView.ResetColorPanels();
        }

        public void SetTextFields()
        {
            // RESET TEXTBOXES
            inleesView.gebruikerTextBox.Text = currentModel.Gebruiker;
            inleesView.nmVerdunning.Value = currentModel.Verdunning;
            inleesView.behandelingTextBox.Text = currentModel.Behandeling;
            inleesView.bodemComboBox.Text = currentModel.Voedingsbodem;
            inleesView.nmKolonies.Value = currentModel.ColonyList.Count;
            inleesView.nmTemperatuur.Value = currentModel.Temperatuur;
            inleesView.SetTextBoxes(currentModel);
        }

        public void SaveToModel()
        {
            // SAVE COLONY TO RESULT
            // SAVE TXTBOXES TO RESULT
            if (currentModel != null)
            {
                int index = currentModel.Index;

                // SAVE TXTBOXES
                mainController.resultModelList[index].Gebruiker = inleesView.gebruikerTextBox.Text;
                mainController.resultModelList[index].Tijdsduur = ((int)inleesView.nmDagen.Value * 24 + (int)inleesView.nmUren.Value);
                mainController.resultModelList[index].Verdunning = (int)inleesView.nmVerdunning.Value;
                mainController.resultModelList[index].Strain = inleesView.strainTextBox.Text;
                mainController.resultModelList[index].Bron = inleesView.bronTextBox.Text;
                mainController.resultModelList[index].Medium = inleesView.mediumTextBox.Text;
                mainController.resultModelList[index].Behandeling = inleesView.behandelingTextBox.Text;
                mainController.resultModelList[index].Temperatuur = (int)inleesView.nmTemperatuur.Value;
                mainController.resultModelList[index].Soort = inleesView.soortTextBox.Text;
                mainController.resultModelList[index].Voedingsbodem = inleesView.bodemComboBox.Text;
            }
        }

        public void BerekenKolonies(PictureBox picturebox, bool bgSelect)
        {
            SaveToModel();
            try
            {
                // PROCESS IMAGE
                currentModel.ColonyList = mainController.colonyController.ProcessImage(picturebox, bgSelect);


                // SET AANTAL COUNTED CELLS

                inleesView.nmKolonies.Value = currentModel.ColonyList.Count;

                // SET RESULT MODEL 
                currentModel.Datum = DateTime.Now;
                currentModel.Gebruiker = inleesView.gebruikerTextBox.Text;
                currentModel.Verdunning = (int)inleesView.nmVerdunning.Value;
                //mainController.resultModelList.Add(currentModel); //TODO: Ask ellen about this, removing this solves the problem 
                //of positioning of the multi panel.
                SetTextFields();
            }
            catch (Exception) { }
        }

        public void BerekenKolonies(PictureBox picturebox, bool bgSelect, ResultModel resultModel)
        {
            try
            {
                ColonyController c = new ColonyController();
                c.RangeRed = new AForge.IntRange(239, 239);
                c.RangeGreen = new AForge.IntRange(228, 228);
                c.RangeBlue = new AForge.IntRange(176, 176);
                // PROCESS IMAGE
                resultModel.ColonyList = c.ProcessImage(picturebox, bgSelect);

                // SET AANTAL COUNTED CELLS
                resultModel.Kolonies = resultModel.ColonyList.Count;
                Console.WriteLine(resultModel.ColonyList.Count);
            }
            catch (Exception) { }
        }

        public void AddResult()
        {
            SqlConnection con = mainController.dbConnection.connection;
            try
            {
                SaveToModel(); //Save all fields in result Model
                if (currentModel.ResultImage != null && !CheckForEmptyField())
                {
                    string storedFileName = FtpController.SaveImage(currentModel.ResultImage); //File path for image that is saved with method
                    string query = @"INSERT INTO Resultaat (Gebruiker, Verdunning, Kolonies, Temperatuur, Soort, Strain, Tijdsduur, Voedingsbodem, Bron, Medium, Behandeling, Path, Kolonie_positie) VALUES(" +
                        "@Gebruiker,@Verdunning,@Kolonies,@Temperatuur,@Soort,@Strain,@Tijdsduur,@Voedingsbodem,@Bron,@Medium,@Behandeling,@Path,@Kolonie_positie)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Gebruiker", currentModel.Gebruiker);
                    cmd.Parameters.AddWithValue("@Verdunning", currentModel.Verdunning);
                    cmd.Parameters.AddWithValue("@Kolonies", currentModel.ColonyList.Count);
                    cmd.Parameters.AddWithValue("@Temperatuur", currentModel.Temperatuur);
                    cmd.Parameters.AddWithValue("@Soort", currentModel.Soort);
                    cmd.Parameters.AddWithValue("@Strain", currentModel.Strain);
                    cmd.Parameters.AddWithValue("@Tijdsduur", currentModel.Tijdsduur);
                    cmd.Parameters.AddWithValue("@Voedingsbodem", currentModel.Voedingsbodem);
                    cmd.Parameters.AddWithValue("@Bron", currentModel.Bron);
                    cmd.Parameters.AddWithValue("@Medium", currentModel.Medium);
                    cmd.Parameters.AddWithValue("@Behandeling", currentModel.Behandeling);
                    cmd.Parameters.AddWithValue("@Path", storedFileName);
                    cmd.Parameters.AddWithValue("@Kolonie_positie", currentModel.ColonyListToString());

                    inleesView.currentResult.FilePath = storedFileName;

                    //Open Database connection and execute the SQL query
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //Show that the result has been added
                    MessageBox.Show("Resultaat toegevoegd.");
                }
                else
                {
                    MessageBox.Show("Vul a.u.b. alle velden in", "Niet alle velden zijn ingevuld.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Database error");
            }
            catch (Exception)
            {

                MessageBox.Show("Laad a.u.b. een afbeelding in");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }


        }
        /// <summary>
        /// Checks if the variables in currentModel have a legit value
        /// if they don't then the field that is linked to that value gets an error on it
        /// Error is also put on the left top side of the selected field and the boolean is set to true.
        /// </summary>
        /// <returns></returns>
        public bool CheckForEmptyField()
        {
            inleesView.erp.Clear();
            bool check = false;
            if (currentModel.Gebruiker == "")
            {
                inleesView.erp.SetError(inleesView.gebruikerTextBox, "Vul een gebruiker in");
                inleesView.erp.SetIconAlignment(inleesView.gebruikerTextBox, ErrorIconAlignment.TopLeft);
                check = true;
            }
            if (currentModel.Verdunning == 0)
            {
                inleesView.erp.SetError(inleesView.nmVerdunning, "Vul een verdunning in");
                inleesView.erp.SetIconAlignment(inleesView.nmVerdunning, ErrorIconAlignment.TopLeft);
                check = true;
            }
            if (currentModel.Soort == "")
            {
                inleesView.erp.SetError(inleesView.soortTextBox, "Vul een soort in");
                inleesView.erp.SetIconAlignment(inleesView.soortTextBox, ErrorIconAlignment.TopLeft);
                check = true;
            }
            if (currentModel.Strain == "")
            {
                inleesView.erp.SetError(inleesView.strainTextBox, "vul een strain in");
                inleesView.erp.SetIconAlignment(inleesView.strainTextBox, ErrorIconAlignment.TopLeft);
                check = true;
            }
            if (currentModel.Tijdsduur == 0)
            {
                inleesView.erp.SetError(inleesView.nmDagen, "Vul een tijd in");
                inleesView.erp.SetIconAlignment(inleesView.nmDagen, ErrorIconAlignment.TopLeft);
                check = true;
            }
            if (currentModel.Voedingsbodem == "")
            {
                inleesView.erp.SetError(inleesView.bodemComboBox, "Selecteer een voedingsbodem");
                inleesView.erp.SetIconAlignment(inleesView.bodemComboBox, ErrorIconAlignment.TopLeft);
                check = true;
            }
            if (currentModel.Bron == "")
            {
                inleesView.erp.SetError(inleesView.bronTextBox, "Selecteer een bron");
                inleesView.erp.SetIconAlignment(inleesView.bronTextBox, ErrorIconAlignment.TopLeft);
                check = true;
            }
            return check;
        }
    }
}

