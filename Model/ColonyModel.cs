using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finan
{
    public class ColonyModel
    {
        // CLASS FOR ONE COLONY OF CELLS
        public AForge.Point Center { get; set; }
        public float Radius { get; set; }

        public ColonyModel(AForge.Point center, float radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public override string ToString()
        {
            return Center.X + "-" + Center.Y + "-" + Radius.ToString() + ";";
        }
    }
}
