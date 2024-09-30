using ScheepvaartBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class GasTanker : Tanker
    {
        public GasEnum Lading { get; set; }

        public GasTanker(double lengte, double breedte, double tonnage, string naam, decimal cargoWaarde, double volume, GasEnum lading) : base(lengte, breedte, tonnage, naam, cargoWaarde, volume)
        {
            Lading = lading;
        }
    }
}
