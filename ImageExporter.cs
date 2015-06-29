using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using System.IO;

namespace Finan
{
    public static class ImageExporter
    {
        /// <summary>
        /// Creates an pdf of the given image at the given location
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fileLocation"></param>
        public static void ExportPdf(System.Drawing.Image image, string fileLocation)
        {
            Image img = Image.GetInstance(image,BaseColor.WHITE); //Don't touch. Breaks exporting when changed
            Document doc = new Document(PageSize.A4.Rotate(), 0, 0, 0, 0);
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(fileLocation,FileMode.Create));
            doc.Open();
            img.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
            doc.Add(img);
            doc.Close();
        }

        /// <summary>
        /// Creates an jpg of the given image at the given location.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="filelocation"></param>
        public static void ExportImage(System.Drawing.Image image, string filelocation)
        {
            image.Save(filelocation,System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}
