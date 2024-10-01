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

        public Dictionary<string, Vloot> VlotenLijst { get; set; }

        public List<string> Havens { get; set; }

        public Rederij(string naam, Dictionary<string, Vloot> vlotenLijst, List<string> havens)
        {
            Naam = naam;
            VlotenLijst = vlotenLijst;
            Havens = havens;
        }

        public void HavenVerwijderen(List<string> havens, string teVerwijderenHaven)
        {
            if (havens.Contains(teVerwijderenHaven))
            {
                havens.Remove(teVerwijderenHaven);
            }
            else
            {
                Console.WriteLine("De haven die u wilt verwijderen bestaat niet.");
            }
        }

        public void VlootToevoegen(string id, Vloot vloot)
        {
            if (this.VlotenLijst.ContainsKey(id))
            {
                throw new Exception("vloot is al toegevoegd.");
            }
            else
            {
                VlotenLijst.Add(id, vloot);
            }
        }

        public void VlootVerwijderen(string id)
        {
            if (!this.VlotenLijst.ContainsKey(id))
            {
                throw new Exception("deze vloot zit niet in de lijst.");
            }
            else
            {
                VlotenLijst.Remove(id);
            }
        }

        public void ZoekVloot(string id)
        {
            if (this.VlotenLijst.ContainsKey(id))
            {
                Console.WriteLine(VlotenLijst.id);
            }
            else
            {
                throw new Exception("Deze vloot zit niet in de rederij.");
            }
        }
    }
}
