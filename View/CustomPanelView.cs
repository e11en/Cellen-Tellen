using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finan
{
    public class CustomPanelView:Panel
    {
        public CustomPanelView(): base()
        {
            DoubleBuffered = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //this.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
