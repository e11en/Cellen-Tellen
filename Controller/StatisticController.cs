using Finan.Model;
using Finan.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finan.Controller
{
    public class StatisticController
    {
        //Attributes & properties
        MainController mainController;
        StatisticModel sm;
        public List<StatisticModel> statisticsList;
        /// <summary>
        /// the selected column that contains strings
        /// </summary>
        int stringArrayIndex = 0;
        List<string> distinctList;


        //Constructor
        public StatisticController(MainController mc)
        {
            this.mainController = mc;
        }

        static public double getTrend(ArrayList[] points)
        {
            double trend = -1, beta = -1, betaTeller = -1, betaNoemer = -1;
            double sumXY = 0, sumX = 0, sumY = 0, sumX2 = 0;
            if (points.Length < 3 && points.Length > 0 && points[0].Count > 0 && points[1].Count > 0 && points[0].Count == points[1].Count)
            {
                try
                {
                    for (int i = 0; i < points[0].Count; i++)
                    {
                        sumXY += (Convert.ToInt32(points[0][i]) * Convert.ToInt32(points[1][i]));
                        sumX += Convert.ToInt32(points[0][i]);
                        sumY += Convert.ToInt32(points[1][i]);
                        sumX2 += (Convert.ToInt32(points[0][i]) * Convert.ToInt32(points[0][i]));
                    }

                    betaTeller = sumXY - ((((double)1) / ((double)points[0].Count)) * sumX * sumY);
                    betaNoemer = sumX2 - ((((double)1) / ((double)points[0].Count)) * sumX * sumX);
                    beta = betaTeller / betaNoemer;
                }
                catch (Exception)
                {

                }

            }

            return trend;
        }

        /// <summary>
        /// Clear controls and create a new boxplots.
        /// Also adjusts the table column size so it all scales well.
        /// </summary>
        public void CreateBoxPlots(List<StatisticModel> statisticList)
        {
            mainController.statisticView.chartTable.Controls.Clear();

            //Value to set the ColumnCount
            int columns = 0;

            for (int index = 0; index < statisticList.Count; index++)
            {
                columns++;

                double lowerWhisker = statisticList[index].KleinsteWaarde;
                double upperWhisker = statisticList[index].GrootsteWaarde;
                double lowerBox = statisticList[index].EersteKwartiel;
                double upperBox = statisticList[index].DerdeKwartiel;
                double average = statisticList[index].Gemiddelde;
                double median = statisticList[index].Mediaan;

                BoxPlotModel boxPlot = new BoxPlotModel(lowerWhisker, upperWhisker, lowerBox, upperBox, average, median, distinctList[index]);
                mainController.statisticView.chartTable.Controls.Add(boxPlot);
                mainController.statisticView.chartTable.ColumnStyles.Add(new ColumnStyle());
            }

            mainController.statisticView.chartTable.ColumnCount = columns;

            //Value used to calculate proper table scaling
            float percent = 100f / columns;

            TableLayoutColumnStyleCollection styles = mainController.statisticView.chartTable.ColumnStyles;
            foreach (ColumnStyle style in styles)
            {
                style.SizeType = SizeType.Percent;
                style.Width = percent;
            }
        }

        /// <summary>
        /// Returns true or false depending on if a string is detected in a array list of arrayLists. used by GetSelectedData().
        /// </summary>
        /// <param name="arrayListOfArrayLists"></param>
        /// <returns></returns>
        public bool StringDetection(ArrayList[] arrayListOfArrayLists)
        {
            try
            {
                //If a string is detected in a selectedColumn. Set bool stringDetected to true
                for (int columnIndex = 0; columnIndex < arrayListOfArrayLists.Length; columnIndex++)
                {
                    try
                    {
                        if (StatisticCalculator.ConvertToList(arrayListOfArrayLists[columnIndex])[0] == -1)//-1 == string
                        {
                            stringArrayIndex = columnIndex;
                            return true;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return false;
                    }

                }
            }
            catch (NullReferenceException nRe)
            {
                throw nRe;
            }
            return false;
        }

        /// <summary>
        /// Create a staticModel from a given array list. used by GetSelectedData().
        /// </summary>
        /// <param name="arrayList"></param>
        public StatisticModel CreateStatisticModelFromArrayList(ArrayList arrayList)
        {
            //Calculate data
            double average = Math.Round(StatisticCalculator.Average(arrayList), 2);
            double standardDeviation = Math.Round(StatisticCalculator.StandardDeviation(arrayList), 2);
            int lowerWhisker = StatisticCalculator.SmallestValue(arrayList);
            double lowerBox = StatisticCalculator.FirstQuartile(arrayList);
            double median = StatisticCalculator.Median(arrayList);
            double upperBox = StatisticCalculator.ThirdQuartile(arrayList);
            int upperWhisker = StatisticCalculator.BiggestValue(arrayList);

            //Create statisticsModel and return it.
            return new StatisticModel(average, standardDeviation, lowerWhisker, lowerBox, median, upperBox, upperWhisker);
        }

        /// <summary>
        /// returns a arrayList with different arraylists. Each containing data (int) from different strings. used by GetSelectedData.
        /// </summary>
        /// <param name="selectedColumns"></param>
        /// <returns></returns>
        public List<List<int>> getResultList(ArrayList[] selectedColumns)
        {
            List<List<int>> resultList = new List<List<int>>();

            //Set the column that contains intergers
            int intComlumn = 1 - stringArrayIndex;

            //Distinct all strings
            distinctList = new HashSet<string>(selectedColumns[stringArrayIndex].Cast<string>().ToList()).ToList();

            foreach (string uniqueName in distinctList)
            {
                List<int> tempName = new List<int>();

                for (int valueIndex = 0; valueIndex < selectedColumns[stringArrayIndex].Count; valueIndex++)
                {
                    string selectedString = (string)selectedColumns[stringArrayIndex][valueIndex];
                    if (selectedString == uniqueName)
                    { 
                        tempName.Add(Convert.ToInt32(selectedColumns[intComlumn][valueIndex]));
                    }
                }
                resultList.Add(tempName);
            }
            return resultList;
        }


        /// <summary>
        /// Get the selected data from the result screen and calculate the data for it (median, first third quartile etc.)
        /// </summary>
        public void GetSelectedData()
        {
            statisticsList = new List<StatisticModel>();
            //Contains the two selected colomns. selectedColomn[0] = first selected, selectedColomn[1] is the second selected colomn.
            ArrayList[] selectedColumns = mainController.resultController.getResultSelection(mainController.resultView.dataView);

            try
            {
                bool stringDetected = StringDetection(selectedColumns);

                //Start string method
                if (stringDetected)
                {
                    //New total list
                    List<List<int>> resultList = getResultList(selectedColumns);

                    //Create statistics models for each result
                    foreach (List<int> result in resultList)
                    {
                        StatisticModel sm = CreateStatisticModelFromArrayList(new ArrayList(result));
                        statisticsList.Add(sm);
                        mainController.statisticView.SetData(new StatisticModel(), 1);
                        mainController.statisticView.SetData(new StatisticModel(), 2);
                    }
                    mainController.statisticView.scatterButton.Enabled = false;
                }
                //Start int method
                else
                {
                    distinctList = new List<string>();
                    distinctList.Add("");
                    distinctList.Add("");

                    //Generate models
                    for (int i = 0; i < selectedColumns.Length; i++)
                    {
                        if (selectedColumns.Length > 0 && selectedColumns[i].Count > 1 && selectedColumns[i] != null)
                        {
                            StatisticModel sm = CreateStatisticModelFromArrayList(new ArrayList(selectedColumns[i]));
                            mainController.statisticView.SetData(sm, i + 1);
                            statisticsList.Add(sm);
                        }
                        else
                        {
                            mainController.statisticView.SetData(new StatisticModel(), 2);
                        }
                    }
                    mainController.statisticView.scatterButton.Enabled = true;
                }
                mainController.mainView.tabPanels.SelectedIndex = 2;
            }
            catch (NullReferenceException) { };
            
        }

        /// <summary>
        /// Creates and sets a plotter
        /// </summary>
        public void setPlotter()
        {
            PlotterController plotterController = new PlotterController();
            ArrayList[] selectedColums = mainController.resultController.getResultSelection(mainController.resultView.dataView);
            if (selectedColums[1].Count > 1)
            {
                plotterController.AddPoints(selectedColums);
                PlotterView plotterView = new PlotterView();
                plotterView.setPlotter(plotterController);
                plotterView.Show();
            }
        }

        public void ExporteerButtonClick()
        {
            ArrayList[] selectedColums = mainController.resultController.getResultSelection(mainController.resultView.dataView);
            if (selectedColums[1].Count > 1)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image (*.jpg)|*.jpg|PDF (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string extension = System.IO.Path.GetExtension(sfd.FileName);
                    Bitmap bmp = new Bitmap(mainController.statisticView.Width, mainController.statisticView.Height);
                    mainController.statisticView.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    switch (extension)
                    {
                        case ".pdf":
                            ImageExporter.ExportPdf(bmp, sfd.FileName);
                            break;
                        case ".jpg":
                            ImageExporter.ExportImage(bmp, sfd.FileName);
                            ImageExporter.ExportImage(bmp, sfd.FileName);
                            break;
                    }
                }


            }
        }
    }
}
