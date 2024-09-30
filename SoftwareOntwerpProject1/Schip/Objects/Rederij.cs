using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Objects
{
    public class Rederij
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

        public Dictionary<string, Schip> VlotenLijst { get; set; }

        public List<string> Havens { get; set; }

        public Rederij(string naam, Dictionary<string, Schip> schepenLijst, List<string> havens)
        {
            Naam = naam;
            VlotenLijst = schepenLijst;
            Havens = havens;
        }
    }
}
