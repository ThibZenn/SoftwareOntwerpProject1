using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    public class Schip
    {
        private double _lengte;

        public double Lengte
        {
            get { return _lengte; }
            set 
            {
                if (value <= 0) throw new Exception("Lengte mag niet <= 0 zijn.");
                _lengte = value; 
            }
        }

        private double _breedte;

        public double Breedte
        {
            get { return _breedte; }
            set
            {
                if (value <= 0) throw new Exception("Breedte mag niet <= 0 zijn.");
                _breedte = value;
            }
        }

        public double Tonnage { get; set; }

        public string Naam { get; set; }

        public Schip(double lengte, double breedte, double tonnage, string naam)
        {
            Lengte = lengte;            
            Breedte = breedte;
            Tonnage = tonnage;
            Naam = naam;
        }
    }
}
