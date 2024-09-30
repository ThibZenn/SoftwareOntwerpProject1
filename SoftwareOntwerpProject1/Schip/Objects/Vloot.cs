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


		// Er moet van elke vloot apart een waarde worden berekent, anders kan de rederij niet aan de juiste informatie.

		public decimal TotaleVlootWaarde()
		{
			// SchepenLijst.Values -> Zorgt dat de objectwaarden worden getarget in plaats van enkel de strings die als sleutel worden gebruikt.
			// .OfType(CargoSchip) -> Definiëren dat het enkel in objecten met type CargoSchip gevonden kan worden.

			return SchepenLijst.Values.OfType<CargoSchip>().Sum(cargoSchip => cargoSchip.CargoWaarde);
		}

		// idem voor TotaalPassagiers

		public int TotaalPassagiersVloot()
		{
			return SchepenLijst.Values.OfType<PassagierSchip>().Sum(passagiersSchip => passagiersSchip.AantalPassagiers);
		}

		// idem voor TonnagePervloot, moet gewoon in een Dictionary teruggegeven worden

		public double TotaalTonnageVloot()
		{
			return SchepenLijst.Values.Sum(schip => schip.Tonnage);
		}

		// idem voor totaal aantal volume

		public double TotaalVolume ()
		{
			return SchepenLijst.Values.OfType<Tanker>().Sum(tanker => tanker.Volume);
		}

		// idem voor aantal sleepboten (keren dat het type Sleepboot voorkomt)

		public int TotaalSleepbotenVloot()
		{
			return SchepenLijst.Values.OfType<Sleepboot>().Count();
		}
    }
}
