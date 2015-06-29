using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Finan.Model
{
    /// <summary>
    /// Main class for creating new boxplots
    /// </summary>
    public class BoxPlotModel : Chart
    {
        /// <summary>
        /// Create a test boxplot. It has some test values in it
        /// </summary>
        public BoxPlotModel()
        {
            Initialize(55.62, 45.54, 73.45, 9.73, 88.42, 45.9, "test");
        }

        /// <summary>
        /// Create a boxplot with costum values
        /// </summary>
        /// <param name="lowerWhisker"></param>
        /// <param name="upperWhisker"></param>
        /// <param name="lowerBox"></param>
        /// <param name="upperBox"></param>
        /// <param name="average"></param>
        /// <param name="median"></param>
        public BoxPlotModel(double lowerWhisker, double upperWhisker, double lowerBox, double upperBox, double average, double median, string chartTile)
        {
            Initialize(lowerWhisker, upperWhisker, lowerBox, upperBox, average, median, chartTile);
        }


        /// <summary>
        /// Initialisize the boxplot
        /// </summary>
        /// <param name="lowerWhisker"></param>
        /// <param name="upperWhisker"></param>
        /// <param name="lowerBox"></param>
        /// <param name="upperBox"></param>
        /// <param name="average"></param>
        /// <param name="median"></param>
        public void Initialize(double lowerWhisker, double upperWhisker, double lowerBox, double upperBox, double average, double median, string chartTitle)
        {
            //Boxplot data names
            string areaName = "BoxPlotArea";
            string dataSeriesName = "Data";
            string boxPlotSeriesName = "BoxPlot";

            //This
            this.Dock = DockStyle.Fill;

            //Chart Area
            this.ChartAreas.Add(areaName);
            this.ChartAreas[areaName].AxisX.Title = chartTitle;
            this.ChartAreas[areaName].AxisX.MajorGrid.Enabled = false;
            this.ChartAreas[areaName].AxisY.MajorGrid.Enabled = false;
            this.ChartAreas[areaName].AxisX.LabelStyle.Enabled = false;

            //Data Series (Data)
            Series dataSeries = new Series(dataSeriesName);
            dataSeries.ChartArea = areaName;
            dataSeries.Enabled = false;
            this.Series.Add(dataSeries);

            //Box Plot Series (Visuals)
            Series boxPlotSeries = new Series(boxPlotSeriesName);
            boxPlotSeries.ChartArea = areaName;
            boxPlotSeries.ChartType = SeriesChartType.BoxPlot;
            boxPlotSeries.BorderColor = Color.Black;
            boxPlotSeries.Color = Color.White;
            this.Series.Add(boxPlotSeries);

            this.Series[boxPlotSeriesName]["BoxPlotShowAverage"] = "false";
            this.Series[boxPlotSeriesName]["BoxPlotShowMedian"] = "true";
            this.Series[boxPlotSeriesName]["BoxPlotShowUnusualValues"] = "false";
            this.Series[boxPlotSeriesName]["BoxPlotWhiskerPercentile"] = "0";
            this.Series[boxPlotSeriesName]["BoxPlotPercentile"] = "20";
            this.Series[boxPlotSeriesName]["BoxPlotSeries"] = dataSeriesName;

            // Add Data to Box Plot Source series.
            double[] yValues = { lowerWhisker, upperWhisker, lowerBox, upperBox, average, median };
            this.Series[dataSeriesName].Points.DataBindY(yValues);
        }
    }
}
