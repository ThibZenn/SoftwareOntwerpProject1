using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class Tanker : CargoSchip
    {
		private double _volume;

        public double Volume
		{
			get { return _volume; }
			set 
			{
				if (value < 0) { throw new Exception("Volume moet positief zijn."); }
				_volume = value; 
			}
		}

        public Tanker(double lengte, double breedte, double tonnage, string naam, decimal cargoWaarde, double volume) : base(lengte, breedte, tonnage, naam, cargoWaarde)
        {
			Volume = volume;
        }
    }
}
