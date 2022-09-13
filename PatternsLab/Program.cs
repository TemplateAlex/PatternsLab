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

            appartaments.Add(new Appartament() { Electricity = 2000 });
            appartaments.Add(new Appartament() { Electricity = 1500 });
            appartaments.Add(new Appartament() { Electricity = 3000 });
            appartaments.Add(new Appartament() { Electricity = 500 });
            appartaments.Add(new Appartament() { Electricity = 250 });

            for(int i = 0; i < appartaments.Count; i++)
            {
                if (appartaments[i].Electricity < 500) tarrificationFactory = new FirstTarrificationFactory();
                else if (appartaments[i].Electricity < 1600) tarrificationFactory = new SecondTarifficationFactory();
                else tarrificationFactory = new ThirdTarrificationFactory();

                Console.WriteLine($"{i + 1} - appartment");
                tarrificationFactory.SetTarrification();
                Console.WriteLine(tarrificationFactory.GetPriceForElectricity(appartaments[i].Electricity));
            }

        }
    }
}
