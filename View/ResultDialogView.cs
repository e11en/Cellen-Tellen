using System;
using System.Drawing;
using System.Windows.Forms;
using Finan.Controller;

namespace Finan
{
    public partial class ResultDialogView : Form
    {
        private Boolean editable = false;
        private MainController mainController;
        private ResultDialogController resultDialogController;
        public ResultModel ResultModel { get; set; }
        private bool BerekenClick { get; set; }
        private int OptionSelect { get; set; }
        
        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="editable">Boolean whether the dialog should be editable.</param>
        /// <param name="mainController"></param>
        public ResultDialogView(Boolean editable, MainController mainController)
        {
            InitializeComponent();
            ResultModel = new ResultModel();
            this.mainController = mainController;
            this.resultDialogController = mainController.resultDialogController;
            this.editable = editable;            
            checkBoxBewerk.Checked = editable;
            MakeEditable();
        } 

        /// <summary>
        /// Sets the buttons enabled or not enabled.
        /// </summary>
        /// <param name="berekend">Boolean whether button berekend has been clicked on.</param>
        /// <param name="editable">Boolean whether the dialog should be edited.</param>
        public void SetButtons(bool berekend, bool editable)
        {
            switch (berekend)
            {
                case true:
                    buttonBereken.Enabled = false;
                    buttonReset.Enabled = true;
                    break;
                case false:
                    buttonBereken.Enabled = true;
                    buttonReset.Enabled = false;
                    break;
            }

            if(editable == false)
            {
                buttonBereken.Enabled = false;
                buttonReset.Enabled = false;
            }
        }
        

        /// <summary>
        /// Draws the circles from the ResultModel.
        /// </summary>
        public void DrawCircles()
        {
            var redPen = new Pen(Color.Red, 2);           

            if (pictureBox.Image != null)
            {
                pictureBox.Image = ResultModel.ResultImage;

                var bitM = new Bitmap(pictureBox.Image);
                var g = Graphics.FromImage(bitM);

                // DRAW CIRCEL AROUND CELL
                foreach (var c in ResultModel.ColonyList)
                {
                    g.DrawEllipse(redPen,
                    (float)(c.Center.X - c.Radius),
                    (float)(c.Center.Y - c.Radius),
                    (float)(c.Radius * 2),
                    (float)(c.Radius * 2));
                }

                g.Dispose();
                pictureBox.Image = bitM;
            }
            redPen.Dispose();
        }

        public void SetImage()
        {
            ResultModel.ResultImage = FtpController.GetImage(ResultModel.FilePath);
            pictureBox.Image = ResultModel.ResultImage;
            pictureBox.Invalidate();
        }

        /// <summary>
        /// Set the editable of the items equal to boolean editable.
        /// </summary>
        private void MakeEditable()
        {
            //Always readOnly
            idTextBox.ReadOnly = true;
            datumTextBox.ReadOnly = true;
            gebruikerTextBox.ReadOnly = true;
            nmKolonies.ReadOnly = true;
            nmKolonies.Increment = 0;

            //Always same color
            idTextBox.BackColor = SystemColors.Control;
            datumTextBox.BackColor = SystemColors.Control;
            gebruikerTextBox.BackColor = SystemColors.Control;

            //readOnly = boolean !editable
            soortTextBox.ReadOnly = !editable;
            strainTextBox.ReadOnly = !editable;
            bronTextBox.ReadOnly = !editable;
            mediumTextBox.ReadOnly = !editable;
            behandelingTextBox.ReadOnly = !editable;

            nmVerdunning.ReadOnly = !editable;
            nmDagen.ReadOnly = !editable;
            nmUren.ReadOnly = !editable;
            nmTemperatuur.ReadOnly = !editable;

            //NumericBox increment = boolean editable to int
            nmVerdunning.Increment = Convert.ToInt32(editable);
            nmDagen.Increment = Convert.ToInt32(editable);
            nmUren.Increment = Convert.ToInt32(editable);
            nmTemperatuur.Increment = Convert.ToInt32(editable);

            //Backcolor is white when editable, else control color.
            soortTextBox.BackColor = editable ? Color.White : SystemColors.Control;
            strainTextBox.BackColor = editable ? Color.White : SystemColors.Control;
            bronTextBox.BackColor = editable ? Color.White : SystemColors.Control;
            mediumTextBox.BackColor = editable ? Color.White : SystemColors.Control;
            behandelingTextBox.BackColor = editable ? Color.White : SystemColors.Control;
            bodemComboBox.BackColor = editable ? Color.White : SystemColors.Control;
            bodemComboBox.DropDownStyle = editable ? ComboBoxStyle.DropDown : ComboBoxStyle.Simple;

            SetButtons(ResultModel.Berekend, editable);
        }

        /// <summary>
        /// Set textboxes with information from the resultModel
        /// </summary>
        public void SetTextBox()
        {
            TimeSpan t = new TimeSpan(ResultModel.Tijdsduur, 0, 0);
            idTextBox.Text = ResultModel.ID.ToString();
            gebruikerTextBox.Text = ResultModel.Gebruiker;
            nmVerdunning.Text = ResultModel.Verdunning.ToString();

            //TODO: Combobox indexing with default values 
            bodemComboBox.Text = ResultModel.Voedingsbodem;
            nmKolonies.Text = ResultModel.Kolonies.ToString();
            datumTextBox.Text = ResultModel.Datum.ToShortDateString();
            nmTemperatuur.Text = ResultModel.Temperatuur.ToString();
            soortTextBox.Text = ResultModel.Soort;
            strainTextBox.Text = ResultModel.Strain;
            bronTextBox.Text = ResultModel.Bron.ToString();
            nmDagen.Text = t.Days.ToString();
            nmUren.Text = t.Hours.ToString();
            mediumTextBox.Text = ResultModel.Medium;
            behandelingTextBox.Text = ResultModel.Behandeling;
        }

        /// <summary>
        /// Sets the boolean whether to search for colonies or background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAchtergrond_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAchtergrond.Checked)
                BerekenClick = true;
            else //if (rbColony.Checked)
                BerekenClick = false;
        }

        /// <summary>
        /// Changes whether the dialog should be editable on Checkbox click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxBewerk_CheckedChanged(object sender, EventArgs e)
        {
            editable = checkBoxBewerk.Checked;
            MakeEditable();
            if (editable == true)
            {
                labelBewerkstatus.Visible = false;
            }
        }

        /// <summary>
        /// Closes the dialog on annuleren click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnnuleren_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Set the numericbox text equal to the value.
        /// Prevents empty numericboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nm_Leave(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown n = (NumericUpDown)sender;
                n.Text = n.Value + "";
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Sets a warning message if the dialoag is not editable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_Click(object sender, EventArgs e)
        {
            if (editable == false)
            {
                labelBewerkstatus.Visible = true;
            }
            else
            {
                labelBewerkstatus.Visible = false;
            }
        }

        /// <summary>
        /// Saves the resultModel to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpslaan_Click(object sender, EventArgs e)
        {
            TextBoxBase[] forms = { soortTextBox, strainTextBox, bronTextBox };
            if (resultDialogController.TextBoxEmpty(forms))
            {
                MessageBox.Show("Het is niet toegestaan om de velden: Soort, Strain of Bron leeg te laten");
            }
            else
            {
                ResultModel.Verdunning = Convert.ToInt32(nmVerdunning.Text);
                ResultModel.Kolonies = Convert.ToInt32(nmKolonies.Text);
                ResultModel.Temperatuur = Convert.ToInt32(nmTemperatuur.Text);
                ResultModel.Soort = soortTextBox.Text;
                ResultModel.Strain = strainTextBox.Text;
                ResultModel.Bron = bronTextBox.Text;
                ResultModel.Tijdsduur = (Convert.ToInt32(nmDagen.Text) * 24) + Convert.ToInt32(nmUren.Text);
                ResultModel.Voedingsbodem = bodemComboBox.Text;
                ResultModel.Medium = mediumTextBox.Text;
                ResultModel.Behandeling = behandelingTextBox.Text;
                //write resultModel to db
                resultDialogController.ResultModelToDB(ResultModel);
                Close();
            }
        }

        /// <summary>
        /// Prevents typing in combobox when editable is false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bodemComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !editable;
        }

        /// <summary>
        /// Counts the number of colonies on berken click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBereken_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                if (OptionSelect != 0)
                {
                    mainController.inleesViewController.BerekenKolonies(pictureBox, BerekenClick, ResultModel);
                    ResultModel.Berekend = true;
                    SetButtons(ResultModel.Berekend, editable);
                    DrawCircles();
                    pictureBox.Invalidate();
                }
                else
                {
                    labelKleur.Visible = true;
                }
            }
        }

        /// <summary>
        /// Resets the number of colonies on reset click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            //mainController.resultModelList[mainController.inleesViewController.currentModel.Index].ColonyList.Clear();
            ResultModel.ColonyList.Clear();
            ResultModel.Kolonies = ResultModel.ColonyList.Count;
            SetTextBox();
            ResultModel.Berekend = false;
            SetButtons(ResultModel.Berekend, editable);
            DrawCircles();
            OptionSelect = 0;
        }

        /// <summary>
        /// Adds a colony on left mouse click.
        /// Removes a colony on right mouse click.
        /// Selects a color on left mouse click when there is no color selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image != null && editable == true)
            {
                try
                {
                    //lblColor.Text = "Kleur: " + mainController.inleesViewController.countModel.GetSelectedColor(pictureBox, e);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                }

                if (e.Button == MouseButtons.Left)
                {
                    if (!ResultModel.Berekend)
                    {
                        mainController.colonyController.SetColorRange(pictureBox, e,true);
                        mainController.colonyController.SetColorRange(pictureBox, e, false);
                        OptionSelect = 1;
                        labelKleur.Visible = false;
                    }
                    else
                    {
                        ColonyController.AddColony(e.X, e.Y, pictureBox, ResultModel);
                        ResultModel.Kolonies = ResultModel.ColonyList.Count;
                        DrawCircles();
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    ColonyController.RemoveKolonie(e.X, e.Y, pictureBox, ResultModel);
                    ResultModel.Kolonies = ResultModel.ColonyList.Count;
                    DrawCircles();
                }
            }

            pictureBox.Invalidate();
            SetTextBox();
        }
    }
}
