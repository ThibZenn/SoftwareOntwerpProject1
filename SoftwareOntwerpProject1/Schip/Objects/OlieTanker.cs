using ScheepvaartBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class OlieTanker : Tanker
    {
        public OlieEnum Lading { get; set; }

        public OlieTanker(double lengte, double breedte, double tonnage, string naam, decimal cargoWaarde, double volume, OlieEnum lading) : base(lengte, breedte, tonnage, naam, cargoWaarde, volume)
        {
            Lading = lading;
        }
    }
}
