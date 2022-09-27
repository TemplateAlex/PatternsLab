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
            //For Composite Pattern

            Human firstEmp = new Employee("Alex", "Sanych");
            Human secondEmp = new Employee();
            Human thirdEmp = new Employee("Max", "Verstappen");
            Human fourthEmp = new Employee("Charles", "Leclerc");
            Human fLeafEmp = new JuniorEmployee("Nicholas", "Latifi");
            Human sLeafEmp = new JuniorEmployee("Sebastian", "Vettel");
            Human sThirdEmp = new JuniorEmployee("Baltteri", "Vottas");

            fourthEmp.AddPartner(fLeafEmp);
            thirdEmp.AddPartner(fourthEmp);
            thirdEmp.AddPartner(sLeafEmp);
            secondEmp.AddPartner(sThirdEmp);
            firstEmp.AddPartner(thirdEmp);
            firstEmp.AddPartner(secondEmp);

            Console.WriteLine(firstEmp.ShowPartners());

            //For Adapter Pattern

            ForSerialize tmp = new ForSerialize();
            SeriazlizationJsonAdapter seriazlizationJsonAdapter = new SeriazlizationJsonAdapter();
            seriazlizationJsonAdapter.DoXMLSerialization(tmp);
            seriazlizationJsonAdapter.DoJsonSerialization(tmp);
        }
    }
}
