using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PatternsLab
{
    public class Program
    {
        public static void Main()
        {
            TarrificationFactory? tarrificationFactory;
            List<Appartament> appartaments = new List<Appartament>();

            appartaments.Add(new Appartament() { Electricity = 2000, TypeTarrification = 1 });
            appartaments.Add(new Appartament() { Electricity = 1500, TypeTarrification = 2 });
            appartaments.Add(new Appartament() { Electricity = 3000, TypeTarrification = 3 });
            appartaments.Add(new Appartament() { Electricity = 500, TypeTarrification = 2 });
            appartaments.Add(new Appartament() { Electricity = 250, TypeTarrification = 1 });

            for(int i = 0; i < appartaments.Count; i++)
            {
                if (appartaments[i].TypeTarrification == 1) tarrificationFactory = new FirstTarrificationFactory();
                else if (appartaments[i].TypeTarrification == 2) tarrificationFactory = new SecondTarifficationFactory();
                else if (appartaments[i].TypeTarrification == 3) tarrificationFactory = new ThirdTarrificationFactory();
                else throw new Exception("We have a problem with tarrification");

                Console.WriteLine($"{i + 1} - appartment");
                tarrificationFactory.SetTarrification();
                Console.WriteLine(tarrificationFactory.GetPriceForElectricity(appartaments[i].Electricity));
            }

        }
    }
}
