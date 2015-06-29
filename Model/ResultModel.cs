using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Finan
{
    public class ResultModel
    {
        public int ID { get; set; }
        public string Gebruiker { get; set; }
        public int Verdunning { get; set; }
        public int Kolonies { get; set; }
        public string Behandeling { get; set; }
        private string voedingsBodem;
        public string Voedingsbodem 
        { 
            get {return voedingsBodem;}
            set { if (value.Length <= 30) voedingsBodem = value; }
        }
        public int Temperatuur { get; set; }
        public string Soort { get; set; }
        public string Strain { get; set; }
        public int Tijdsduur { get; set; }
        public string Medium { get; set; }
        public DateTime Datum { get; set; }
        public string Bron { get; set; }
        public Image ResultImage { get; set; }
        public string FilePath { get; set; }
        public int Index { get; set; }
        public bool Berekend { get; set; }

        public CustomPanelView panel;

        public List<ColonyModel> ColonyList;

        public ResultModel(Image image)
        {
            this.ResultImage = image;
            this.ColonyList = new List<ColonyModel>();
            this.panel = new CustomPanelView();
            this.panel.BackgroundImage = ResultImage;
            this.Berekend = false;
        }


        public ResultModel()
        {
            this.ColonyList = new List<ColonyModel>();
            this.panel = new CustomPanelView();
            this.panel.BackgroundImage = ResultImage;

            //this.Gebruiker = "Naam";
            //this.Verdunning = "Verdunning";
            //this.Behandeling = "Opmerking";
            //this.Voedingsbodem = "Voedingsbodem";
        }

        public string ColonyListToString()
        {
            var strB = "";

            foreach(var c in ColonyList)
            {
                strB += c.ToString();
            }
            return strB.ToString();
        }
    }
}
