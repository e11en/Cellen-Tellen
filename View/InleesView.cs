using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using Finan.Controller;
//using Microsoft.WindowsAPICodePack.Dialogs;

namespace Finan
{
    public partial class InleesView : UserControl
    {
        public Panel temporaryPanel;
        public ResultModel currentResult;
        public MainController mainController;

        public int OptionSelect { get; set; }
        public bool BerekenClick { get; set; }

        /// <summary>
        /// CONSTRUCTOR FOR THE INLEESVIEW
        /// </summary>
        /// <param name="mainController"></param>
        public InleesView(MainController mainController) 
        {
            InitializeComponent();
            this.mainController = mainController;
            this.BerekenClick = true;

            nmKolonies.ReadOnly = true;
            nmKolonies.Increment = 0;
            nmKolonies.BackColor = SystemColors.Control;
        }

        private void btnBereken_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                if (OptionSelect > 1)
                {
                    mainController.inleesViewController.BerekenKolonies(pictureBox, BerekenClick);
                    currentResult.Berekend = true;
                    SetButtons(currentResult.Berekend);
                    DrawCircles();
                    pictureBox.Invalidate();
                }
                else
                {
                    lblSelect.Visible = true;
                    lblSelect.Text = "Selecteer de achtergrond.";
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // CHECK PICTUREBOX IS NOT EMPTY
            if (pictureBox.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!currentResult.Berekend)
                    {
                        if (OptionSelect == 0)
                        {
                            mainController.colonyController.SetColorRange(pictureBox, e, true, AchtergrondPanelKleur);
                            lblSelect.Text = "Selecteer een kolonie.";
                            OptionSelect = 1;
                            btnReset.Enabled = true;
                        }
                        else
                        {
                            mainController.colonyController.SetColorRange(pictureBox, e, false, KoloniePanelKleur);
                            OptionSelect = 2;
                            lblSelect.Visible = false;
                            btnReset.Enabled = true;
                        }
                    }
                    else
                        ColonyController.AddColony(e.X, e.Y, pictureBox, currentResult);
                }
                if (e.Button == MouseButtons.Right)
                {
                    ColonyController.RemoveKolonie(e.X, e.Y, pictureBox, currentResult);
                }

                DrawCircles();
                pictureBox.Invalidate();
            }
            
            RefreshTxt();
        }

        /// <summary>
        /// REFRESH ALL TEXT BOXES
        /// </summary>
        private void RefreshTxt()
        {
            // REFRESH AANTAL
            if (pictureBox.Image != null)
                nmKolonies.Text = "" + mainController.inleesViewController.currentModel.ColonyList.Count;

            // REFRESH ALL TXTBOXES
            nmKolonies.Refresh();
            gebruikerTextBox.Refresh();
            nmDagen.Refresh();
            nmUren.Refresh();
            nmVerdunning.Refresh();
            strainTextBox.Refresh();
            soortTextBox.Refresh();
            nmTemperatuur.Refresh();
            bronTextBox.Refresh();
            mediumTextBox.Refresh();
            behandelingTextBox.Refresh();
        }

        /// <summary>
        /// CLICKED ON THE BUTTON RESET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            mainController.resultModelList[mainController.inleesViewController.currentModel.Index].ColonyList.Clear();
            currentResult.ColonyList.Clear();
            RefreshTxt();
            currentResult.Berekend = false;
            SetButtons(currentResult.Berekend);
            DrawCircles();
            OptionSelect = 0;

            AchtergrondPanelKleur.BackColor = Color.White;
            KoloniePanelKleur.BackColor = Color.White;
        }

        public void ResetColorPanels()
        {
            OptionSelect = 0;
            AchtergrondPanelKleur.BackColor = Color.White;
            KoloniePanelKleur.BackColor = Color.White;
        }

        /// <summary>
        /// SET ALL THE TEXTBOXES
        /// </summary>
        /// <param name="resultModel">THE CURRENT RESULT MODEL</param>
        public void SetTextBoxes(ResultModel resultModel)
        {
            gebruikerTextBox.Text = resultModel.Gebruiker;
            nmVerdunning.Value = resultModel.Verdunning;
            strainTextBox.Text = resultModel.Strain;
            bronTextBox.Text = resultModel.Bron;
            mediumTextBox.Text = resultModel.Medium;
            behandelingTextBox.Text = resultModel.Behandeling;
            soortTextBox.Text = resultModel.Soort;
            nmUren.Value = (resultModel.Tijdsduur % 24);
            nmDagen.Value = (resultModel.Tijdsduur / 24);
            RefreshTxt();
        }

        /// <summary>
        /// ENABLE OR DISABLE THE BUTTONS
        /// </summary>
        /// <param name="berekend">CHECK IF RESULT IS ALREADY CALCULATED</param>
        public void SetButtons(bool berekend)
        {
            switch (berekend)
            {
                case true:
                    btnBereken.Enabled = false;
                    btnReset.Enabled = true;
                    break;
                case false:
                    btnBereken.Enabled = true;
                    btnReset.Enabled = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainController.inleesViewController.AddResult();
        }

        /// <summary>
        /// DRAW CIRKEL FOR EACH COLONY
        /// </summary>
        public void DrawCircles()
        {
            var redPen = new Pen(Color.Red, 2);

            if (pictureBox.Image != null)
            {
                pictureBox.Image = currentResult.ResultImage;

                var bitM = new Bitmap(pictureBox.Image);
                var g = Graphics.FromImage(bitM);

                // DRAW CIRCEL AROUND CELL
                foreach (var c in currentResult.ColonyList)
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

        /// <summary>
        /// On panel resize, run AddPicture method. Image panels will be repositioned according to the panel width
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inleesImageListView_Resize(object sender, EventArgs e)
        {
            mainController.inleesViewController.AddPicture();
        }

        /// <summary>
        /// If the mouse enters the pannel, set focus. This is used for the mouse wheel, so you can scroll with it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inleesImageListView_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
                ((CustomPanelView)sender).Focus();
        }

    }
}