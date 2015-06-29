using Finan.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finan.View
{
    public partial class PlotterView : Form
    {
        private PlotterController plotterController;
        private Label helling = new Label();

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        public PlotterView()
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(helling, 1, 0);
            this.Text = "Scatter plot";
        }

        /// <summary>
        /// Set a plotter to this view.
        /// </summary>
        /// <param name="p">PlotterModel to display</param>
        public void setPlotter(PlotterController p)
        {
            plotterController = p;
            tableLayoutPanel1.Controls.Add(plotterController, 0, 0);
            setLabel();
        }

        /// <summary>
        /// Set label text.
        /// </summary>
        private void setLabel()
        {
            helling.Text = "Helling: " + plotterController.gradient;
        }

        /// <summary>
        /// On button invert click, invert the plotter and reset the label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInvert_Click(object sender, EventArgs e)
        {
            plotterController.Invert();
            setLabel();
        }
    }
}