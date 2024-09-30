using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    internal class Veerboot : PassagierSchip
    {
		private string _havenA;

		public string HavenA
		{
			get { return _havenA; }
			set { if (string.IsNullOrWhiteSpace(value)) throw new Exception("Haven A is leeg."); }
		}

        private string _havenB;

        public string HavenB
        {
            get { return _havenB; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new Exception("Haven B is leeg."); }
        }

        public Veerboot(double lengte, double breedte, double tonnage, string naam, int aantalPassagiers, string havenA, string havenB) : base(lengte, breedte, tonnage, naam, aantalPassagiers)
        {
            HavenA = havenA;
            HavenB = havenB;
        }
    }
}
