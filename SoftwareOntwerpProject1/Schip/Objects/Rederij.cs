using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public List<Vloot> VlotenLijst { get; set; }

        public List<string> Havens { get; set; }

        public Rederij(string naam, List<Vloot> vlotenLijst, List<string> havens)

        {
            Naam = naam;
            VlotenLijst = vlotenLijst;
            Havens = havens;
            VlotenLijst = new List<Vloot>();
        }

        public decimal totaleWaarde()
        {
            return VlotenLijst.Sum(vloot => vloot.TotaleVlootWaarde());
        }

        public int aantalPassagiers()
        {
            return VlotenLijst.Sum(vloot => vloot.TotaalPassagiersVloot());
        }

        // we gaan een nieuwe dictionary vullen met het tonnage met als key de vlootnaam
        public Dictionary<double, Vloot> TonnagePerVloot() 
        {
            Dictionary<double, Vloot> tonnagePerVloot = new Dictionary<double, Vloot>();

            foreach (var vloot in VlotenLijst)
            {
                double totaalTonnage = vloot.TotaalTonnageVloot();

                if (!tonnagePerVloot.ContainsKey(totaalTonnage))
                {
                    tonnagePerVloot.Add(totaalTonnage, vloot);
                }
            }

            return tonnagePerVloot;
        }

        public double TotaalVolume()
        {
            return VlotenLijst.Sum(vloot => vloot.TotaalVolume());
        }

        public int BeschikbareSleepboten()
        {
            return VlotenLijst.Sum(vloot => vloot.TotaalSleepbotenVloot());
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

        public void VlootToevoegen(Vloot vloot)
        {
            if (this.VlotenLijst.Contains(vloot))
            {
                throw new Exception("vloot is al toegevoegd.");
            }
            else
            {
                VlotenLijst.Add(vloot);
            }
        }

        public void VlootVerwijderen(Vloot vloot)
        {
            if (!this.VlotenLijst.Contains(vloot))
            {
                throw new Exception("deze vloot zit niet in de lijst.");
            }
            else
            {
                VlotenLijst.Remove(vloot);
            }
        }

        public Vloot ZoekVloot(string naam)
        {
            Dictionary<string, Vloot> vlootDictionary = new Dictionary<string, Vloot>();

            //dictionary opvullen volgens naam van de vloot
            foreach (var item in this.VlotenLijst)
            {
                vlootDictionary.Add(item.Naam, item);
            }

            if (vlootDictionary.TryGetValue(naam, out Vloot gevondenVloot))
            {
                Console.WriteLine($"Naam = {gevondenVloot.Naam} is gevonden.");
            }
            else
            {
                throw new Exception("Deze vloot zit niet in de rederij.");
            }

            return gevondenVloot;
        }

        // Verplaatst een schip van deze vloot naar een andere vloot
        public void VerplaatsSchip(string naamSchip, string startVloot, string eindVloot)
        {

            // Zoek het schip op basis van de naam
            Vloot vloot1 = ZoekVloot(startVloot);
            Vloot vloot2 = ZoekVloot(eindVloot);

            Schip gevondenSchip = vloot1.ZoekSchip(naamSchip);

            if (gevondenSchip != null)
            {
                vloot1.VerwijderSchip(gevondenSchip);
                vloot2.VoegSchipToe(gevondenSchip);
                Console.WriteLine("Verplaatsing gelukt!");
            }
            else
            {
                Console.WriteLine("Het te verplaatsen schip bestaat niet.");
            }
        }
    }
}
