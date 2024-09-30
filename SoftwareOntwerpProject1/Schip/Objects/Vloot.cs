using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    public class Vloot
    {
		private string _naam;

		public string Naam
		{
			get { return _naam; }
			set 
			{ 
				if (string.IsNullOrWhiteSpace(value)) { throw new Exception("Naam moet ingevuld zijn."); }
				_naam = value; 
			}
		}

		public Dictionary<string, Schip> SchepenLijst { get; set; }

		public Vloot(string naam, Dictionary<string, Schip> schepenLijst)
        {       
            Naam = naam;
            SchepenLijst = schepenLijst;
        }
    }
}
