using Finan.Controller;
using Finan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Finan.View
{
    public partial class StatisticView : UserControl
    {
        public MainController mainController;
        public StatisticView(MainController mainController)
        {
            this.mainController = mainController;
            InitializeComponent();
        }

        /// <summary>
        /// The data in statistic view should be changed when this is ran. All the data is retrieved from StatisticModel sm
        /// </summary>
        /// <param name="sm"></param> The statistic model that is going to be used.
        /// <param name="res"></param>This will either be 1 or 2. When its 1 it should change the data for label 1 and if its 2 it should change label 2
        public void SetData(StatisticModel sm, int res)
        {
            if (res == 1)
            {
                gemiddeldeLabel1.Text = sm.Gemiddelde.ToString().Equals("-1") ? "n.v.t." : sm.Gemiddelde.ToString();
                standaardafwijkingLabel1.Text = sm.Standaardafwijking.ToString().Equals("-1") ? "n.v.t." : sm.Standaardafwijking.ToString();
                kleinsteWaardeLabel1.Text = sm.KleinsteWaarde.ToString().Equals("-1") ? "n.v.t." : sm.KleinsteWaarde.ToString();
                eersteKwartielLabel1.Text = sm.EersteKwartiel.ToString().Equals("-1") ? "n.v.t." : sm.EersteKwartiel.ToString();
                mediaanLabel1.Text = sm.Mediaan.ToString().Equals("-1") ? "n.v.t." : sm.Mediaan.ToString();
                derdeKwartielLabel1.Text = sm.DerdeKwartiel.ToString().Equals("-1") ? "n.v.t." : sm.DerdeKwartiel.ToString();
                grootsteWaardeLabel1.Text = sm.GrootsteWaarde.ToString().Equals("-1") ? "n.v.t." : sm.GrootsteWaarde.ToString();
            }
            if (res == 2)
            {
                gemiddeldeLabel2.Text = sm.Gemiddelde.ToString().Equals("-1") ? "n.v.t." : sm.Gemiddelde.ToString();
                standaardafwijkingLabel2.Text = sm.Standaardafwijking.ToString().Equals("-1") ? "n.v.t." : sm.Standaardafwijking.ToString();
                kleinsteWaardeLabel2.Text = sm.KleinsteWaarde.ToString().Equals("-1") ? "n.v.t." : sm.KleinsteWaarde.ToString();
                eersteKwartielLabel2.Text = sm.EersteKwartiel.ToString().Equals("-1") ? "n.v.t." : sm.EersteKwartiel.ToString();
                mediaanLabel2.Text = sm.Mediaan.ToString().Equals("-1") ? "n.v.t." : sm.Mediaan.ToString();
                derdeKwartielLabel2.Text = sm.DerdeKwartiel.ToString().Equals("-1") ? "n.v.t." : sm.DerdeKwartiel.ToString();
                grootsteWaardeLabel2.Text = sm.GrootsteWaarde.ToString().Equals("-1") ? "n.v.t." : sm.GrootsteWaarde.ToString();
            }

            mainController.mainView.tabPanels.SelectedIndex = 2;
        }


        /// <summary>
        /// Clear all the data, this is used whenever an exception is caught.
        /// </summary>
        public void ClearData()
        {
            gemiddeldeLabel1.Text = "";
            standaardafwijkingLabel1.Text = "";
            kleinsteWaardeLabel1.Text = "";
            eersteKwartielLabel1.Text = "";
            mediaanLabel1.Text = "";
            derdeKwartielLabel1.Text = "";
            grootsteWaardeLabel1.Text = "";

            gemiddeldeLabel2.Text = "";
            standaardafwijkingLabel2.Text = "";
            kleinsteWaardeLabel2.Text = "";
            eersteKwartielLabel2.Text = "";
            mediaanLabel2.Text = "";
            derdeKwartielLabel2.Text = "";
            grootsteWaardeLabel2.Text = "";
        }

        private void boxplotButton_Click(object sender, EventArgs e)
        {
            mainController.statisticController.CreateBoxPlots(mainController.statisticController.statisticsList);
        }

        private void scatterButton_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.statisticController.setPlotter();
            }
            catch
            {
            }
        }

        private void exporteerButton_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.statisticController.ExporteerButtonClick();
            }
            catch
            {
            }
            
        }

    }
}
