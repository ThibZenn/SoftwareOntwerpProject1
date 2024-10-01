﻿using System;
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

		public List<Schip> SchepenLijst { get; set; }

		public Vloot(string naam, List<Schip> schepenLijst)
        {       
            Naam = naam;
            SchepenLijst = schepenLijst;
        }

		// Er moet van elke vloot apart een waarde worden berekent, anders kan de rederij niet aan de juiste informatie.

		public decimal TotaleVlootWaarde()
		{
			// SchepenLijst.Values -> Zorgt dat de objectwaarden worden getarget in plaats van enkel de strings die als sleutel worden gebruikt.
			// .OfType(CargoSchip) -> Definiëren dat het enkel in objecten met type CargoSchip gevonden kan worden.
			decimal total = 0;

			total += SchepenLijst.OfType<RoRoSchip>().Sum(roroSchip => roroSchip.CargoWaarde);
			total += SchepenLijst.OfType<ContainerSchip>().Sum(containerSchip => containerSchip.CargoWaarde);
			total += SchepenLijst.OfType<OlieTanker>().Sum(olieTanker => olieTanker.CargoWaarde);
            total += SchepenLijst.OfType<GasTanker>().Sum(gasTanker => gasTanker.CargoWaarde);

			return total;

        }

		// idem voor TotaalPassagiers

		public int TotaalPassagiersVloot()
		{
            int total = 0;

            total += SchepenLijst.OfType<CruiseSchip>().Sum(cruiseSchip => cruiseSchip.AantalPassagiers);
            total += SchepenLijst.OfType<Veerboot>().Sum(veerBoot => veerBoot.AantalPassagiers);            

            return total;            
		}

		// idem voor TonnagePervloot, moet gewoon in een Dictionary teruggegeven worden

		public double TotaalTonnageVloot()
		{
			return SchepenLijst.Sum(schip => schip.Tonnage);
		}

		// idem voor totaal aantal volume

		public double TotaalVolume ()
		{
            double total = 0;

            total += SchepenLijst.OfType<OlieTanker>().Sum(olieTanker => olieTanker.Volume);
            total += SchepenLijst.OfType<GasTanker>().Sum(gasTanker => gasTanker.Volume);

            return total;
        }

		// idem voor aantal sleepboten (keren dat het type Sleepboot voorkomt)

		public int TotaalSleepbotenVloot()
		{
			return SchepenLijst.OfType<Sleepboot>().Count();
		}

		public void VoegSchipToe(Schip toeTeVoegenSchip)
		{
			if (!this.SchepenLijst.Contains(toeTeVoegenSchip))
			{
				this.SchepenLijst.Add(toeTeVoegenSchip);
			}
			else
			{
                Console.WriteLine("Het schip dat u wilt toevoegen bestaat al.");
			}
		}

		public void VerwijderSchip(Schip toeTeVoegenSchip)
		{
            if (this.SchepenLijst.Contains(toeTeVoegenSchip))
            {
                this.SchepenLijst.Remove(toeTeVoegenSchip);
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
