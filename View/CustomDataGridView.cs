﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finan.View
{
    public partial class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
    }
}
