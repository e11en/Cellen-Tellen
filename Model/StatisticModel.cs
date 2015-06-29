using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finan
{
    public class StatisticModel
    {
        public double Gemiddelde { get; set; }
        public double Standaardafwijking { get; set; }
        public int KleinsteWaarde { get; set; }
        public double EersteKwartiel { get; set; }
        public double Mediaan { get; set; }
        public double DerdeKwartiel { get; set; }
        public int GrootsteWaarde { get; set; }
        

        /// <summary>
        /// Create a fake statistics model
        /// </summary>
        public StatisticModel()
        {
            this.Gemiddelde = -1;
            this.Standaardafwijking = -1;
            this.KleinsteWaarde = -1;
            this.EersteKwartiel = -1;
            this.Mediaan = -1;
            this.DerdeKwartiel = -1;
            this.GrootsteWaarde = -1;
        }

        public StatisticModel(double gem, double stand, int kleinste, double eersteKwartiel, double mediaan, double derdeKwartiel, int grootste)
        {
            this.Gemiddelde = gem;
            this.Standaardafwijking = stand;
            this.KleinsteWaarde = kleinste;
            this.EersteKwartiel = eersteKwartiel;
            this.Mediaan = mediaan;
            this.DerdeKwartiel = derdeKwartiel;
            this.GrootsteWaarde = grootste;
        }
    }
}
