using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Drawing;
using System.Windows.Forms;

namespace Finan.Controller
{
    public static class FtpController
    {
        private static string host = @"ftp://ellenlangelaar.nl/";
        private static string user = "u652636903.windesheim";
        private static string pass = "windesheim";
        private static FtpWebRequest ftpRequest = null;
        private static FtpWebResponse ftpResponse = null;

        /* Construct Object */
        static FtpController() { }

        public static string SaveImage(Image image)
        {
            var fileName = "IMG_" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + "_" + 
                DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".jpg";
            string localFile = Application.StartupPath + @"\" +  fileName;
            image.Save(localFile);

            try
            {
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(host + fileName);
                ftp.Credentials = new NetworkCredential(user, pass);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(localFile);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bestand is niet opgelagen.");
            }
            return fileName;
        }

        public static Image GetImage(string path)
        {
            FtpWebRequest reqFTP;
            string localFile = Application.StartupPath + @"\" + path;
            Image img = new Bitmap(2, 2);

            try
            {
                //filePath = <<The full path where the 
                //file is to be created. the>>, 
                //fileName = <<Name of the file to be createdNeed not 
                //name on FTP server. name name()>>
                FileStream outputStream = new FileStream(localFile, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(host + path));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(user, pass);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                img = new Bitmap(outputStream);

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bestand is niet gevonden.");
            }

            return img;
        }

        /* Delete File */
        public static void DeleteFile(string deleteFile)
        {
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(host + deleteFile));

                reqFTP.Credentials = new NetworkCredential(user, pass);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bestand is niet verwijderd.");
            }
        }
    }
}
