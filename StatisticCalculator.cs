using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Finan
{

    /// <summary>
    /// This class is used to calculate statistics.
    /// </summary>
    public static class StatisticCalculator
    {
        /// <summary>
        /// Calculates the average from the resultList.
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static double Average(ArrayList list)
        {
            
            double average = 0;
            try
            {
                double sum = 0;
                
                foreach (var l in list)
                {
                    sum += Convert.ToInt32(l);
                }
                average = sum / list.Count;
                
            }
            catch (Exception) { average = -1; }
            return average;
        }

        /// <summary>
        /// Calculates the standard deviation (standaard afwijking). 
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static double StandardDeviation(ArrayList list)
        {
            double standardDeviation = 0;
            double standardDeviationRounded = 0;
            double average = Average(list);
            double sum = 0;
            try
            {
                double countMinusOne = list.Count - 1;

                foreach (var l in list)
                {
                    sum += ((Convert.ToDouble(l) - average) * (Convert.ToDouble(l) - average));
                }

                standardDeviation = Math.Sqrt(sum / countMinusOne);
                standardDeviationRounded = Math.Round(standardDeviation, 3);
            }
            catch (Exception) { standardDeviationRounded = -1; }
            return standardDeviationRounded;
        }

        /// <summary>
        /// This returns the smallest value of a resultList.
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static int SmallestValue(ArrayList list)
        {
            //Smallest is -1 so that the first if statement is always true!
            int smallest = -1;
            try
            {
                foreach (var i in list)
                {
                    if (smallest == -1 || Convert.ToInt32(i) < smallest)
                    {
                        smallest = Convert.ToInt32(i);
                    }
                }
            }
            catch (Exception) { smallest = -1; }

            return smallest;
        }

        /// <summary>
        /// Returns the biggest value of a resultList.
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static int BiggestValue(ArrayList list)
        {
            int biggest = -1;
            try
            {
                foreach (var i in list)
                {
                    if (Convert.ToInt32(i) > biggest)
                    {
                        biggest = Convert.ToInt32(i);
                    }
                }
            }
            catch (Exception) { biggest = -1; }
            return biggest;
        }

        /// <summary>
        /// Calculates the first quartile. 
        /// positionRounded is used to check if the position variable is a decimal.
        /// if positionRounded - position is bigger than 0 and smaller than 1, it meants that position is a decimal.
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static double FirstQuartile(ArrayList list)
        {
            double firstQ = -1;
            double position = (0.25 * (list.Count +1 ));
            double positionRounded = Math.Ceiling(position);

            List<int> l = ConvertToList(list);
            l.Sort();

            try
            {
                if (positionRounded - position > 0.00 && positionRounded - position < 1)
                {
                    int Value1;
                    int Value2;
                    if (list.Count == 6)
                    {
                        Value1 = Convert.ToInt32(l[(int)positionRounded]);
                        Value2 = Convert.ToInt32(l[((int)positionRounded - 1)]);
                    }
                    else
                    {
                        Value1 = Convert.ToInt32(l[(int)positionRounded - 1]);
                        Value2 = Convert.ToInt32(l[((int)positionRounded - 2)]);
                    }
                    
                    firstQ = Value1 + Value2;
                    firstQ = firstQ / 2;
                }
                else
                {
                    firstQ = Convert.ToInt32(l[(int)position - 1]);
                }
            }
            catch (Exception) { firstQ = -1; }

            return firstQ;
        }

        /// <summary>
        /// Calculates the Median. 
        /// positionRounded is used to check if the position variable is a decimal.
        /// if positionRounded - position is bigger than 0 and smaller than 1, it meants that position is a decimal.
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <returns></returns>
        public static double Median(ArrayList list) 
        {
            double Median = -1;
            double position = (0.50 * (list.Count + 1));
            double positionRounded = Math.Ceiling(position);

            List<int> l = ConvertToList(list);
            l.Sort();

            try
            {
                if (positionRounded - position > 0.00 && positionRounded - position < 1)
                {
                    int Value1 = Convert.ToInt32(l[(int)positionRounded - 1]);
                    int Value2 = Convert.ToInt32(l[((int)positionRounded - 2)]);
                    Median = Value1 + Value2;
                    Median = Median / 2;
                }
                else
                {
                    Median = Convert.ToInt32(l[((int)positionRounded - 1)]);
                }
            }
            catch (Exception) { Median = -1; }

            return Median;
        }

        /// <summary>
        /// Calculates the third quartile. 
        /// positionRounded is used to check if the position variable is a decimal.
        /// if positionRounded - position is bigger than 0 and smaller than 1, it meants that position is a decimal.
        /// When something goes wrong, return -1 so this can be displayed the right way in the label!(i.e string selected)
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static double ThirdQuartile(ArrayList list)
        {
            double thirdQ = -1;
            double position = (0.75 * (list.Count + 1));
            double positionRounded = Math.Ceiling(position);

            List<int> l = ConvertToList(list);
            l.Sort();

            try
            {
                if (positionRounded - position > 0.00 && positionRounded - position < 1)
                {
                    int Value1 = Convert.ToInt32(l[((int)positionRounded - 1)]);
                    int Value2 = Convert.ToInt32(l[((int)positionRounded - 2)]);
                    thirdQ = Value1 + Value2;
                    thirdQ = thirdQ / 2;
                }
                else
                {
                    thirdQ = Convert.ToInt32(l[((int)positionRounded - 1)]);
                }
            }
            catch (Exception) { thirdQ = -1; }

            return thirdQ;
        }

        /// <summary>
        /// Converts the arraylist to a int resultList. this is done so you can sort the resultList.
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public static List<int> ConvertToList(ArrayList list)
        {
            List<int> p = new List<int>();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int k = Convert.ToInt32(list[i]);
                    p.Add(k);
                }
            }
            catch (Exception) 
            {
                p = new List<int>();
                p.Add(-1);
            }
            return p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static double getGradient(ArrayList[] points)
        {
            double gradient = -1, gradientTeller = -1, gradientNoemer = -1;
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

                    gradientTeller = sumXY - ((((double)1) / ((double)points[0].Count)) * sumX * sumY);
                    gradientNoemer = sumX2 - ((((double)1) / ((double)points[0].Count)) * sumX * sumX);
                    gradient = gradientTeller / gradientNoemer;
                }
                catch (Exception)
                {

                }
            }
            return gradient;
        }
    }
}
