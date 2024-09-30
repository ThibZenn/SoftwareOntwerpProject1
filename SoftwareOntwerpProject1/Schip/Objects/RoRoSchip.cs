using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class RoRoSchip : CargoSchip
    {
        private int _aantalAutos;

        public int AantalAutos
        {
            get { return _aantalAutos; }
            set
            {
                if (_aantalAutos < 0) { throw new Exception("Aantal autos kan niet negatief zijn."); }
                _aantalAutos = value;
            }
        }

        private int _aantalTrucks;

        public int AantalTrucks
        {
            get { return _aantalTrucks; }
            set
            {
                if (_aantalTrucks < 0) { throw new Exception("Aantal trucks kan niet negatief zijn."); }
                _aantalTrucks = value;
            }
        }

        public RoRoSchip(double lengte, double breedte, double tonnage, string naam, decimal cargoWaarde, int aantalAutos, int aantalTrucks) : base(lengte, breedte, tonnage, naam, cargoWaarde)
        {
            AantalAutos = aantalAutos;
            AantalTrucks = aantalTrucks;
        }
    }
}
