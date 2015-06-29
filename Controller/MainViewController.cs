using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finan.View;

namespace Finan.Controller
{
    public class MainViewController
    {
        // CONTROLLER FOR THE MAINVIEW

        private MainView mainView;
        private MainController mainController;
        private string formName = "Cellen Tellen";
        private string formNameAdmin = " (Beheerder)";

        public MainViewController(MainController mainController)
        {
            this.mainView = mainController.mainView;
            this.mainController = mainController;
        }

        // GO TO GIVEN TAB
        public void SelectTab(int tab)
        {
            this.mainView.tabPanels.SelectedTab = mainView.tabPanels.TabPages[tab];
        }

        // ADD CONTROL TO GIVEN TAB PAGE
        public void AddToPage(Control control, int tab)
        {
            control.Parent = mainView.tabPanels.TabPages[tab];
            mainView.tabPanels.SuspendLayout();
            mainView.tabPanels.TabPages[tab].Controls.Add(control);
            mainView.tabPanels.ResumeLayout();
            control.Show();
            control.Dock = DockStyle.Fill;
            mainView.Refresh();
        }

        /// <summary>
        /// Creates the adminLoginView. The user can login with this view. If the password is correct, login. 
        /// If not, show error and rerun this method.
        /// </summary>
        public void OpenAdminLoginWindow()
        {
            using (AdminLoginView adminLoginView = new AdminLoginView())
            {
                TextBox wachtwoordTxtBox = adminLoginView.wachtwoordTxtBox;

                DialogResult result = adminLoginView.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //Hard coded YOLO
                    if (wachtwoordTxtBox.Text == "admin")
                    {
                        LogInAdmin();
                    }
                    else
                    {
                        MessageBox.Show("U heeft een verkeerd wachtwoord ingevoerd, probeer het opnieuw!");
                        OpenAdminLoginWindow();
                    }
                }
            }
        }

        /// <summary>
        /// Login as an administrator and show successful message box, Also sets inloggen and uitloggen tool strip items
        /// and changes the formname
        /// </summary>
        public void LogInAdmin()
        {
            mainController.isAdministrator = true;
            mainController.mainView.inloggenToolStripMenuItem.Enabled = false;
            mainController.mainView.uitloggenToolStripMenuItem.Enabled = true;
            mainController.mainForm.Text = formName + formNameAdmin;
            mainController.resultController.Init();
            MessageBox.Show("U bent nu ingelogd als administrator!");
        }

        /// <summary>
        /// Log out administrator and show successful message box, Also sets inloggen and uitloggen tool strip items
        /// and changesthe form name
        /// </summary>
        public void LogOutAdmin()
        {
            mainController.isAdministrator = false;
            mainController.mainView.inloggenToolStripMenuItem.Enabled = true;
            mainController.mainView.uitloggenToolStripMenuItem.Enabled = false;
            mainController.mainForm.Text = formName;
            mainController.resultController.Init();
            MessageBox.Show("U bent uitgelogd!");
        }
    }
}
