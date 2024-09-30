using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class CargoSchip : Schip
    {
		private decimal _cargoWaarde;

        public decimal CargoWaarde
		{
			get { return _cargoWaarde; }
			set 
			{ 
				if (_cargoWaarde < 0) { throw new Exception("Cargowaarde kan niet negatief zijn."); }
				_cargoWaarde = value; 
			}
		}

        public CargoSchip(double lengte, double breedte, double tonnage, string naam, decimal cargoWaarde) : base(lengte, breedte, tonnage, naam)
        {
			CargoWaarde = cargoWaarde;
        }
    }
}
