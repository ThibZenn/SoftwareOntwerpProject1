﻿using System;
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
    }
}
