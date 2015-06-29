using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Finan.Model
{
    public class PlotterModel : Chart       
    {
        private string chartName = "MijnScatterPlotter";
        private String serieOne = "Punten";
        private String serieTwo = "Helling";

        /// <summary>
        /// Gradient of plotter.
        /// </summary>
        public double gradient = -1;
        ArrayList[] points;
        /// <summary>
        /// Constructor
        /// </summary>
        public PlotterModel()
        {
            this.ResetAutoValues();
            Init();   
        }

        /// <summary>
        /// Initialize plotter.
        /// </summary>
        private void Init()
        {
            this.Name = chartName;
            this.Text = chartName + "Grafiek test ding";

            this.ChartAreas.Add(chartName);

            this.Series.Add(serieOne);
            this.Series[0].ChartType = SeriesChartType.Point;

            this.Series.Add(serieTwo);
            this.Series[1].ChartType = SeriesChartType.Line;
        }

        /// <summary>
        /// Add points to the plotter
        /// </summary>
        /// <param name="points"></param>
        public void AddPoints(ArrayList[] points)
        {
            this.points = points;
            this.Series[serieOne].Points.Clear();
            this.Series[serieTwo].Points.Clear();
            //Should be two arraylist which are both the same size and not empty.
            if (points.Length < 3 && points.Length > 0 && points[0].Count > 0 && points[1].Count > 0 && points[0].Count == points[1].Count)
            {
                //if noth columns are numbers.
                try
                {
                    for (int i = 0; i < points[0].Count; i++)
                    {
                        this.Series[serieOne].Points.AddXY(Convert.ToInt32(points[0][i]), Convert.ToInt32(points[1][i]));
                    }
                }
                    //if column is a string.
                catch (Exception ex)
                {
                    this.Series[serieOne].Points.Clear();
                    for (int i = 0; i < points[0].Count; i++)
                    {
                        this.Series[serieOne].Points.AddXY(points[0][i], points[1][i]);
                    }
                }             
            }

            //set gradientline.
            int gemY = 0;
            try
            {
                for (int i = 0; i < points[0].Count; i++)
                {
                    gemY += Convert.ToInt32(points[1][i]);
                }
            }
            catch (Exception)
            {
                gemY = 0;
            }
            gemY /= points[0].Count;
            Console.WriteLine(gemY);

            gradient = Math.Round(StatisticCalculator.getGradient(points), 3);
            int max = getMax(points[0]);
            int min = getMin(points[0]);


            this.Series[serieTwo].Points.AddXY(min, (min * gradient));
            this.Series[serieTwo].Points.AddXY(max, (max * gradient));

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Invert the plotter.
        /// </summary>
        public void Invert()
        {
            ArrayList xList = new ArrayList();
            ArrayList yList = new ArrayList();
            for (int i = 0; i < points[0].Count; i++)
            {
                yList.Add(points[0][i]);
            }
            for (int i = 0; i < points[1].Count; i++)
            {
                xList.Add(points[1][i]);
            }
            points[0] = xList;
            points[1] = yList;

            AddPoints(points);

        }

        /// <summary>
        /// Get max number in arraylist.
        /// </summary>
        /// <param name="resultList">ArrayList</param>
        /// <returns>int with max number</returns>
        private int getMax(ArrayList list)
        {
            int max = 0;
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (Convert.ToInt32(list[i]) > max)
                    {
                        max = Convert.ToInt32(list[i]);
                    }
                }
            }
            catch (Exception)
            {

            }
            return max;
        }

        private int getMin(ArrayList list)
        {
            int min = int.MaxValue;
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (Convert.ToInt32(list[i]) < min)
                    {
                        min = Convert.ToInt32(list[i]);
                    }
                }
            }
            catch (Exception)
            {

            }
            return min;
        }
    }
}
