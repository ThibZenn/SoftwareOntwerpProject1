using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    public class PassagierSchip : Schip
    {
        public int AantalPassagiers { get; set; }

        public PassagierSchip(double lengte, double breedte, double tonnage, string naam, int aantalPassagiers) : base(lengte, breedte, tonnage, naam)
        {
            AantalPassagiers = aantalPassagiers;
        }
    }
}
