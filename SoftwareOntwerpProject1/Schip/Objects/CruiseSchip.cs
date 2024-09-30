using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    public class CruiseSchip : PassagierSchip
    {
        private List<string> _traject { get; set; }

        public List<string> Traject
        {
            get { return _traject; }
            set 
            {
                if (value.Count() < 2) throw new Exception("Het traject moet uit minstens 2 havens bestaan.");
            }
        }


        public CruiseSchip(double lengte, double breedte, double tonnage, string naam, int aantalPassagiers, List<String> traject) : base(lengte, breedte, tonnage, naam, aantalPassagiers)
        {
            Traject = traject;
        }
    }
}
