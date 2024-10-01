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

		public void VoegSchipToe(List<Schip> schepenLijst, Schip toeTeVoegenSchip)
		{
			if (!schepenLijst.Contains(toeTeVoegenSchip))
			{
				schepenLijst.Add(toeTeVoegenSchip);
			}
			else
			{
                Console.WriteLine("Het schip dat u wilt toevoegen bestaat al.");
			}
		}

		public void VerwijderSchip(List<Schip> schepenLijst, Schip toeTeVoegenSchip)
		{
            if (schepenLijst.Contains(toeTeVoegenSchip))
            {
                schepenLijst.Remove(toeTeVoegenSchip);
            }
            else
            {
                Console.WriteLine("Het schip dat u wilt verwijderen bestaat niet.");
            }
        }

        // Retourneert het Schip || indien niet gevonden => null
        public Schip ZoekSchip(string naamSchip)
        {
            // Controleer of het schip in de dictionary zit
            if (SchepenLijst.ContainsKey(naamSchip))
            {
                Console.WriteLine($"Schip {naamSchip} gevonden.");
                return SchepenLijst[naamSchip];
            }
            else
            {
                Console.WriteLine($"Schip {naamSchip} niet gevonden in vloot {Naam}.");
                return null;  // Retourneer null als het schip niet bestaat
            }
        }


        public void ToonSchepen()
        {
            // Controleer of er schepen in de vloot zijn
            if (SchepenLijst.Count == 0)
            {
                Console.WriteLine($"Er zijn geen schepen in de vloot {Naam}.");
            }
            else
            {
                Console.WriteLine($"Schepen in vloot {Naam}:");
                foreach (var schip in SchepenLijst.Values)
                {
                    //Schip klasse ToString()
                    Console.WriteLine(schip);
                }
            }
        }

        // Verplaatst een schip van deze vloot naar een andere vloot
        public void VerplaatsSchip(string naamSchip, Vloot nieuweVloot)
        {
            // Zoek het schip op basis van de naam
            Schip schip = ZoekSchip(naamSchip);

            if (schip != null && VerwijderSchip(naamSchip)) 
            {
                nieuweVloot.VoegSchipToe(schip);
                Console.WriteLine($"Schip {naamSchip} is verplaatst van vloot {Naam} naar vloot {nieuweVloot.Naam}");
            }
            else
            {
                Console.WriteLine($"Verplaatsing mislukt, schip {naamSchip} niet gevonden.");
            }
        }
    }
}
