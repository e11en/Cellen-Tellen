using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Finan.Controller
{
    /// <summary>
    /// The controller related to files
    /// </summary>
    public class FileController
    {

        //VARIABLES______________________________________________________________________
        public OpenFileDialog openFileDialog;
        public Image image;
        private FolderBrowserDialog folderDialog;
        public MainController mainController;
        public DateTime selectedDate;

        //CONSTRUCTORS___________________________________________________________________
        public FileController(MainController mc)
        {
            this.openFileDialog = new OpenFileDialog();
            this.folderDialog = new FolderBrowserDialog();
            this.mainController = mc;
        }

        //METHODS________________________________________________________________________

        /// <summary>
        /// Opens a dialog where you can select multiple pictures. Selected pictures will then be loaded in to the program,
        /// and will be displayed in the multi view.
        /// </summary>
        public void SelectPicture()
        {
            //Set a filter to select pictures only
            openFileDialog.Filter = "Afbeeldingen (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.Multiselect = true;
            //Set startup destionation to default folder
            //If config.txt exists
            if (File.Exists(Application.StartupPath + "/Config.txt"))
            {
                openFileDialog.InitialDirectory = ReadStandardFolderLocation();
            }
            //If dialog result is OK, send image
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Set loading cursor while this method is running
                mainController.mainView.Cursor = Cursors.WaitCursor;
                
                //This is for multiple files
                LoadPictures(openFileDialog.FileNames);

                //Restore cursor
                mainController.mainView.Cursor = Cursors.Default;
            }
            //File.Create(Application.StartupPath + "/Config.txt").Close();
        }

        //Loadpicture from an arrayListOfArrayLists of filenames
        public void LoadPictures(string[] fileNames)
        {
            //String for failed files
            string faultyitems = "";

            foreach (string name in fileNames)
            {
                try
                {
                    image = new Bitmap(name);
                    ResultModel result = new ResultModel(image);
                    result.FilePath = name;
                    result.Index = mainController.resultModelList.Count;
                    //mainController.resultModelList.Insert(0, result);
                    mainController.resultModelList.Add(result);
                    mainController.inleesView.inleesImageView = new CustomPanelView();
                    result.panel.Click += new System.EventHandler(mainController.inleesViewController.panel_Click);
                }
                //Fills string with the path name of the failed file
                catch (ArgumentException)
                {
                   faultyitems = faultyitems + name + "\n";
                }
           }

            mainController.inleesViewController.AddPicture();

            //If there was an error it returns a messagebox with an string of the failed files and then restarts the method
            if(faultyitems != "")
            {
                MessageBox.Show("De volgende bestanden waren geen foto of waren corrupt: \n " + faultyitems);
                SelectPicture();
            }
            //File.Create(Application.StartupPath + "/Config.txt").Close();
        }

        //Loadpicture from an resultList of filenames
        public void LoadPictures(List<string> fileNames)
        {
            //String for failed files
            string faultyitems = "";

            foreach (string name in fileNames)
            {
                try
                {
                    if (!CheckIfPicLoaded(name))
                    {
                        image = new Bitmap(name);
                        ResultModel result = new ResultModel(image);
                        result.FilePath = name;
                        result.Index = mainController.resultModelList.Count;
                        //mainController.resultModelList.Insert(0, result);
                        mainController.resultModelList.Add(result);
                        mainController.inleesView.inleesImageView = new CustomPanelView();
                        result.panel.Click += new System.EventHandler(mainController.inleesViewController.panel_Click);

                    }
                }
                //Fills string with the path name of the failed file
                catch (ArgumentException)
                {
                    faultyitems = faultyitems + name + "\n";
                }
            }
            mainController.inleesViewController.AddPicture();
            //If there was an error it returns a messagebox with an string of the failed files and then restarts the method
            if (faultyitems != "")
            {
                MessageBox.Show("De volgende bestanden waren geen foto of waren corrupt: \n " + faultyitems);
                SelectPicture();
            }
            //File.Create(Application.StartupPath + "/Config.txt").Close();
        }

        private bool CheckIfPicLoaded(string imagePath)
        {
            bool check = false;

            foreach (var result in mainController.resultModelList)
            {
                if(result.FilePath.Equals(imagePath))
                    check = true;                
            }

            return check;
        }

        //Read first line of config.txt and check where the default path is.
        public string ReadStandardFolderLocation()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "/Config.txt");
            string path = file.ReadLine();
            file.Close();
            return path;
        }

        public void SelectDefaultFolder()
        {
            //Weergeef dialoog
            DialogResult result = folderDialog.ShowDialog();

            string path;

            //Wanneer er op OK wordt gedrukt
            if (result == DialogResult.OK)
            {
                path = folderDialog.SelectedPath;

                //Lokaal Config.txt aanmaken en hier gekozen path plaatsen.
                File.WriteAllText(Application.StartupPath + "/Config.txt", path);
            }
        }

        //When user selects 'Standaard map uitladen' this method is called.
        public void LoadDefaultFolder()
        {
            //Set loading cursor while this method is running
            mainController.mainView.Cursor = Cursors.WaitCursor;
            
            //If config.txt exsists in root folder
            if (File.Exists(Application.StartupPath + "/Config.txt"))
            {
                //Get the selected date from Month Calender in dialog
                selectedDate = mainController.loadMapView.monthCalender.SelectionRange.Start;

                string[] allImages;

                //get default folder
                String path = ReadStandardFolderLocation();

                //Add image file names from default folder to this arrayListOfArrayLists.
                allImages = Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                .Where(s => ((Path.GetExtension(s).ToLower() == ".jpg" || Path.GetExtension(s).ToLower() == ".jpeg" 
                    || Path.GetExtension(s).ToLower() == ".jpe" || Path.GetExtension(s).ToLower() == ".jfif" 
                    || Path.GetExtension(s).ToLower() == ".png" ))).ToArray();

                //images of which the modified date is later than selected date will be added to this.
                //This will be done in the next foreach 
                List<string> laterThanSelectedDate = new List<string>();

                foreach (var foto in allImages)
                {

                    FileInfo i = new FileInfo(foto);
                    if (i.LastWriteTime >= selectedDate)
                    {
                        laterThanSelectedDate.Add(foto);
                    }
                }
                //Load the images
                LoadPictures(laterThanSelectedDate);
            }
            //If there is no default folder selected at all give error.
            else
            {
                MessageBox.Show("U heeft geen standaard map geselecteerd, doe dit a.u.b. eerst.");
            }

            //Restore cursor
            mainController.mainView.Cursor = Cursors.Default;
        }

        //Saves image in file storage and returns a string of the file path
        public static string SaveOnStorage(string fileStorage, ResultModel currentModel)
        {
            string folderPath = fileStorage + "" + currentModel.Gebruiker + "_" + currentModel.Datum.Year + currentModel.Datum.Month + currentModel.Datum.Day + currentModel.Datum.Minute + currentModel.Datum.Second + ".jpg";
            Bitmap tmpBitmap = currentModel.ResultImage as Bitmap;
            //New bitmap so program can save it.
            Bitmap newBitMap = new Bitmap(tmpBitmap);
            newBitMap.Save(folderPath, ImageFormat.Jpeg);
            newBitMap.Dispose();
            return folderPath;
        }

    }
}
