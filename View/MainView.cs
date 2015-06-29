using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finan.Controller;

namespace Finan
{
    public partial class MainView : UserControl
    {
        public MainController mainController;

        public MainView(MainController mc)
        {
            this.mainController = mc;

            InitializeComponent();
        }

        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // GO TO FIRST TAB
            mainController.mainViewController.SelectTab(0);

            //Action
            mainController.fileSelectController.SelectPicture();
        }

        private void selecteerStandaardMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.fileSelectController.SelectDefaultFolder();
        }

        private void standaardMapInladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OPEN DIALOG
            mainController.loadMapView.ShowDialog();
        }

        private void tabPanels_Selected(object sender, TabControlEventArgs e)
        {
            if (tabPanels.SelectedIndex == 1)
            {
                mainController.resultController.Init();
            }
            if (tabPanels.SelectedIndex == 0)
            {
                mainController.inleesView.Refresh();
            }
        }

        private void inloggenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.mainViewController.OpenAdminLoginWindow();
        }

        private void uitloggenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.mainViewController.LogOutAdmin();
        }


    }
}
