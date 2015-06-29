using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System.Linq;

namespace Finan.Controller
{
    /// <summary>
    /// In the ColonyController the image in the PictureBox will be pasted through a filter.
    /// The remaining objects in de image will be checked if the shape is a circel.
    /// If that is the case the shape will be added to the CellList.
    /// </summary>
    public class ColonyController
    {
        public IntRange RangeRed { get; set; }
        public IntRange RangeGreen { get; set; }
        public IntRange RangeBlue { get; set; }
        public RGB ColonyColor { get; set; }

        public List<ColonyModel> CellList;
        private List<Blob> blobList;

        private PictureBox pictureBox;
        private Bitmap bitmap;
        private BitmapData bitmapData;
        private BlobCounter blobCounter;
        private SimpleShapeChecker shapeChecker;

        /// <summary>
        /// Constructor, the parameter mainController is needed for the use of other classes
        /// that are located in de MainController class.
        /// </summary>
        public ColonyController()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize the needed components for this class.
        /// </summary>
        public void Initialize()
        {
            this.shapeChecker = new SimpleShapeChecker();
            this.CellList = new List<ColonyModel>();
            this.blobList = new List<Blob>();

            // SET COLOR RANGE FOR BACKGROUND
            RangeRed = new IntRange(255,255);
            RangeGreen = new IntRange(255, 255);
            RangeBlue = new IntRange(255, 255);
        }

        /// <summary>
        /// Create a new instance of the BlobCounter and set the minimal size of a blob.
        /// Also the maximum height for a single blob is set.
        /// </summary>
        public void SetBlobCounter()
        {
            // CREATE NEW COUNTER
            this.blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;

            // SET MIN WIDTH + HEIGHT SIZE OF BLOB
            blobCounter.MinHeight = 3;
            blobCounter.MinWidth = 3;

            // SET MAX HEIGHT SO THE DISC IS NOT COUNTED
            blobCounter.MaxHeight = 75;
        }

        /// <summary>
        /// The ColorFilter is applied with the ColorRange from the background
        /// </summary>
        public void FilterImgBgSelect()
        {
            // CREATE NEW BITMAP IMAGE
            this.bitmap = new Bitmap((Bitmap)pictureBox.Image);

            // LOCK IMAGE
            this.bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // CREATE NEW FILTER
            ColorFiltering colorFilter = new ColorFiltering();

            // SET COLOR RANGE FOR BACKGROUND
            colorFilter.Red = RangeRed;
            colorFilter.Green = RangeGreen;
            colorFilter.Blue = RangeBlue;

            // DONT FILL OUTSIDE RANGE
            colorFilter.FillOutsideRange = false;

            // APPLY FILTER ON IMAGE
            colorFilter.ApplyInPlace(bitmapData);
        }

        /// <summary>
        /// The ColorFilter is applied with the ColorRange from the colony.
        /// </summary>
        public void FilterImgColonySelect()
        {
            // CREATE NEW BITMAP IMAGE
            this.bitmap = new Bitmap((Bitmap)pictureBox.Image);

            // LOCK IMAGE
            this.bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // CREATE NEW FILTER
            EuclideanColorFiltering filter = new EuclideanColorFiltering();

            // SET COLOR RANGE FOR BACKGROUND
            filter.CenterColor = ColonyColor;
            filter.Radius = 100;

            // APPLY FILTER ON IMAGE
            filter.ApplyInPlace(bitmapData);
        }

        /// <summary>
        /// The arrayListOfArrayLists of blobs is converted to a resultList.
        /// </summary>
        // BLOB COUNTER TO BLOB LIST
        private void BlobCounterToList(Blob[] blobs)
        {
            foreach (Blob b in blobs)
            {
                blobList.Add(b);
            }
        }

        /// <summary>
        /// The main methode for the shape detection in a PictureBox image.
        /// </summary>
        /// <param name="pb">PictureBox, the image is used to set the BitMap.</param>
        /// <param name="bgSelect">Selects the methode of filtering to use.</param>
        /// <returns>The complete resultList of blobs that where detected as circles.</returns>
        public List<ColonyModel> ProcessImage(PictureBox pb, bool bgSelect)
        {
            this.pictureBox = pb;

            var listOne = ProcessIMG(true);
            var listTwo = ProcessIMG(false);

            CellList.Clear();
            ProcessCellList(listOne, listTwo);
            //CellList = RemoveNoneAverage(CellList);

            return CellList;
        }

        /// <summary>
        /// COMPARE BOTH CELL LISTS AND CREATE ONE LIST
        /// </summary>
        /// <param name="one">FIRST LIST, MADE WITH BACKGROUND FILTER</param>
        /// <param name="two">SECOND LIST, MADE WITH COLONY FILTER</param>
        private void ProcessCellList(List<ColonyModel> one, List<ColonyModel> two)
        {
            Console.WriteLine("1: " + one.Count + " 2: " + two.Count);

            var listOne = one;
            var listTwo = two;

            if (one.Count < two.Count)
            {
                listOne = two;
                listTwo = one;
            }

            foreach (var b in listOne)
            {
                if (listTwo.Count > 0)
                {
                    foreach (var b2 in listTwo)
                    {
                        int x = Convert.ToInt32(b.Center.X);
                        int y = Convert.ToInt32(b.Center.Y);
                        if (ClickedOnColony(b, b2))
                        {
                            CellList.Add(b2);
                        }
                    }
                }
                else
                {
                    CellList.Add(b);
                }
            }
        }

        private List<ColonyModel> RemoveNoneAverage(List<ColonyModel> list)
        {
            float avg = 0;

            foreach (var i in list)
            {
                avg += i.Radius;
            }
            avg = avg / list.Count;

            var newList = new List<ColonyModel>();

            foreach (var i in list)
            {
                if (i.Radius < (avg + 5))
                    newList.Add(i);
            }

            return newList;
        }

        /// <summary>
        /// APPLY FILTER TO IMAGE
        /// </summary>
        /// <param name="bgSelect">TRUE, SET BACKGROUND FILTER. FALSE, SET COLONY FILTER</param>
        /// <returns></returns>
        private List<ColonyModel> ProcessIMG(bool bgSelect)
        {
            if (bgSelect)
            {
                // SET FILTER WITH BG COLOR
                FilterImgBgSelect();
            }
            else
            {
                // SET FILTER WITH COLONY COLOR
                FilterImgColonySelect();
            }

            // INIT BLOB COUNTER
            SetBlobCounter();

            blobCounter.ProcessImage(bitmapData);
            BlobCounterToList(blobCounter.GetObjectsInformation());
            bitmap.UnlockBits(bitmapData);

            // SET DISTORTION
            shapeChecker.MinAcceptableDistortion = 0.2f;
            shapeChecker.RelativeDistortionLimit = 0.2f;

            var cellLijst = new List<ColonyModel>();

            // DRAW CIRCLE AROUND BLOB
            for (int i = 0, n = blobList.Count; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobList[i]);

                AForge.Point center;
                float radius;

                // IF SHAPE IS CIRCLE
                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    // ADD COLONY TO LIST
                    cellLijst.Add(new ColonyModel(center, radius));
                }
            }
            this.blobList.Clear();
            return cellLijst;
        }
        
        /// <summary>
        /// Add a colony to the current ResultModel.
        /// </summary>
        /// <param name="x">Mouse X position.</param>
        /// <param name="y">Mouse Y position.</param>
        /// <param name="pictureBox">The current PictureBox that is used.</param>
        /// <param name="resultModel">The current used ResultModel.</param>
        /// // ADD COLONY TO RESULT MODEL
        public static void AddColony(int x, int y, PictureBox pictureBox, ResultModel resultModel)
        {
            try
            {
                // GET RELATIVE POSITION
                int realX = TranslateZoomMousePosition(new System.Drawing.Point(x, y), pictureBox).X;
                int realY = TranslateZoomMousePosition(new System.Drawing.Point(x, y), pictureBox).Y;

                // WITHIN PICTUREBOX
                if ((realX >= 0) && (realX <= pictureBox.Image.Width) && (realY >= 0) && (realY <= pictureBox.Image.Height))
                {
                    bool clicked = false;

                    // CHECK MOUSE LOCATION TO COLONY LOCATION
                    for (int i = 0; i < resultModel.ColonyList.Count; i++)
                    {
                        if (ClickedOnColony(realX, realY, resultModel.ColonyList[i]))
                        {
                            clicked = true;
                            break;
                        }
                    }

                    // IF MOUSE LOCATION IS NOT COLONY LOCATION, ADD NEW
                    if (!clicked)
                    {
                        resultModel.ColonyList.Add(new ColonyModel(new AForge.Point(realX, realY), GetAverageRadius(resultModel)));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Toevoegen is mislukt.");
            }
        }

        /// <summary>
        /// Will make new List<float> which will contain the all the colony radius from a colony resultList. Will return the average of this resultList.
        /// </summary>
        /// <returns>A float that is the average radius of the radius of a colony resultList.</returns>
        public static float GetAverageRadius(ResultModel resultModel)
        {
            List<float> averageColonyRadius = new List<float>();

            foreach (ColonyModel colony in resultModel.ColonyList)
            {
                averageColonyRadius.Add(colony.Radius);
            }
            return averageColonyRadius.Average();
        }

        /// <summary>
        /// Remove a colony from the current ResultModel.
        /// </summary>
        /// <param name="x">Mouse X position.</param>
        /// <param name="y">Mouse Y position.</param>
        /// <param name="pictureBox">The current PictureBox that is used.</param>
        /// <param name="resultModel">The current used ResultModel.</param>
        // REMOVE COLONY FROM RESULT MODEL
        public static void RemoveKolonie(int x, int y, PictureBox pictureBox, ResultModel resultModel)
        {
            try
            {
                // GET RELATIVE POSITION
                int realX = TranslateZoomMousePosition(new System.Drawing.Point(x, y), pictureBox).X;
                int realY = TranslateZoomMousePosition(new System.Drawing.Point(x, y), pictureBox).Y;

                // CHECK MOUSE LOCATION TO COLONY LOCATION
                for (int i = 0; i < resultModel.ColonyList.Count; i++)
                {
                    if (ClickedOnColony(realX, realY, resultModel.ColonyList[i]))
                    {
                        resultModel.ColonyList.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verwijderen is mislukt.");
            }
        }

        /// <summary>
        /// Check if the given position is equal to a existing colony.
        /// </summary>
        /// <param name="x">Mouse X position.</param>
        /// <param name="y">Mouse Y position.</param>
        /// <param name="c">Current used ColonyModel</param>
        /// <returns></returns>
        public static bool ClickedOnColony(int x, int y, ColonyModel c)
        {
            // CHECK IF GIVEN LOCATION IS NOT THE SAME AS LOCATION OF COLONY
            bool clicked = false;
            if (x >= c.Center.X - c.Radius && x <= c.Center.X + c.Radius)
            {
                if (y >= c.Center.Y - c.Radius && y <= c.Center.Y + c.Radius)
                {
                    clicked = true;
                }
            }
            return clicked;
        }

        public static bool ClickedOnColony(ColonyModel c1, ColonyModel c2)
        {
            // CHECK IF GIVEN LOCATION IS NOT THE SAME AS LOCATION OF COLONY
            bool clicked = false;
            if (c1.Center.X >= c2.Center.X - c2.Radius && c1.Center.X <= c2.Center.X + c2.Radius)
            {
                if (c1.Center.Y >= c2.Center.Y - c2.Radius && c1.Center.Y <= c2.Center.Y + c2.Radius)
                {
                    clicked = true;
                }
            }
            return clicked;
        }

        /// <summary>
        /// Set the color used in both filters.
        /// </summary>
        /// <param name="pb">Current used PictureBox.</param>
        /// <param name="e">Mouse events, used to get the location.</param>
        public void SetColorRange(PictureBox pb, MouseEventArgs e, bool bgselect)
        {
            try
            {
                // GET COLOR OF PIXEL
                Bitmap bitmap = new Bitmap((Bitmap)pb.Image);
                var loc = TranslateZoomMousePosition(e.Location, pb);
                var pixelcolor = bitmap.GetPixel(loc.X, loc.Y);

                if (bgselect)
                {
                    // SET COLOR RANGE
                    RangeRed = new IntRange(pixelcolor.R - 50, pixelcolor.R + 50);
                    RangeGreen = new IntRange(pixelcolor.G - 50, pixelcolor.G + 50);
                    RangeBlue = new IntRange(pixelcolor.B - 50, pixelcolor.B + 50);
                }
                else
                {
                    ColonyColor = new RGB(pixelcolor);
                }

                // DISPOSE OF BITMAP
                bitmap.Dispose();
            }
            catch (Exception) { }
        }

        public void SetColorRange(PictureBox pb, MouseEventArgs e, bool bgselect, Panel p)
        {
            try
            {
                // GET COLOR OF PIXEL
                Bitmap bitmap = new Bitmap((Bitmap)pb.Image);
                var loc = TranslateZoomMousePosition(e.Location, pb);
                var pixelcolor = bitmap.GetPixel(loc.X, loc.Y);

                if (bgselect)
                {
                    // SET COLOR RANGE
                    RangeRed = new IntRange(pixelcolor.R - 50, pixelcolor.R + 50);
                    RangeGreen = new IntRange(pixelcolor.G - 50, pixelcolor.G + 50);
                    RangeBlue = new IntRange(pixelcolor.B - 50, pixelcolor.B + 50);
                }
                else
                {
                    ColonyColor = new RGB(pixelcolor);
                }

                p.BackColor = pixelcolor;

                // DISPOSE OF BITMAP
                bitmap.Dispose();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Translate the given X and Y to the relative position in the shown PictureBox.
        /// </summary>
        /// <param name="coordinates">The X and Y Point.</param>
        /// <param name="pictureBox">The current used PictureBox.</param>
        /// <returns></returns>
        public static System.Drawing.Point TranslateZoomMousePosition(System.Drawing.Point coordinates, PictureBox pictureBox)
        {
            // test to make sure our image is not null
            if (pictureBox.Image == null) return coordinates;
            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0
            if (pictureBox.Width == 0 || pictureBox.Height == 0 || pictureBox.Image.Width == 0 || pictureBox.Image.Height == 0) return coordinates;
            // This is the one that gets a little tricky. Essentially, need to check 
            // the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)pictureBox.Image.Width / pictureBox.Image.Height;
            float controlAspect = (float)pictureBox.Width / pictureBox.Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, 
                // meaning the image fills up the entire control from left to right
                float ratioWidth = (float)pictureBox.Image.Width / pictureBox.Width;
                newX *= ratioWidth;
                float scale = (float)pictureBox.Width / pictureBox.Image.Width;
                float displayHeight = scale * pictureBox.Image.Height;
                float diffHeight = pictureBox.Height - displayHeight;
                diffHeight /= 2;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, 
                // meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)pictureBox.Image.Height / pictureBox.Height;
                newY *= ratioHeight;
                float scale = (float)pictureBox.Height / pictureBox.Image.Height;
                float displayWidth = scale * pictureBox.Image.Width;
                float diffWidth = pictureBox.Width - displayWidth;
                diffWidth /= 2;
                newX -= diffWidth;
                newX /= scale;
            }
            return new System.Drawing.Point((int)newX, (int)newY);
        }

    }
}
