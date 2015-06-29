using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finan.Controller;

namespace Finan
{
    //THIS CLASS IS USED FOR WHEN THE USER SELECTS 'Standaard map uitladen'.
    public partial class LoadMapView : Form
    {
        public MainController mainController;

        public LoadMapView(MainController mc)
        {
            this.mainController = mc;
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            mainController.fileSelectController.LoadDefaultFolder();
            this.Close();
        }

    }
}
