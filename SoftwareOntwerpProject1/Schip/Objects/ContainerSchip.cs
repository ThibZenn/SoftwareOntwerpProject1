using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class ContainerSchip : CargoSchip
    {
		private int _aantalContainers;

        public int AantalContainers
		{
			get { return _aantalContainers; }
			set 
			{ 
				if (_aantalContainers < 0) { throw new Exception("Aantal containers kan niet negatief zijn."); }
				_aantalContainers = value; 
			}
		}

        public ContainerSchip(double lengte, double breedte, double tonnage, string naam, decimal cargoWaarde, int aantalContainers) : base(lengte, breedte, tonnage, naam, cargoWaarde)
        {
			AantalContainers = aantalContainers;
        }
    }
}
