using System;
using Newtonsoft.Json;

namespace PatternsLab
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Choose your value: GPH - 1, General - 2");
            int value = Convert.ToInt32(Console.ReadLine());

            if (value == 1)
            {
                GPH gph;
                double opv;
                double osms;

                Console.WriteLine("Do you want to choose default settings? Write '1' if yes, else '0'");
                int chooseValue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write your salary:");
                int salary = Convert.ToInt32(Console.ReadLine());

                if (chooseValue == 1) gph = new GPH(salary);
                else
                {
                    Console.WriteLine("Write your OPV");
                    opv = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your OSMS");
                    osms = Convert.ToDouble(Console.ReadLine());
                    gph = new GPH(salary: salary, opv: opv, osms: osms);
                }

                while (true)
                {
                    Console.WriteLine("Okay, we are have your config file. Let's check");
                    using (StreamReader reader = new StreamReader(@"E:\Projects\config.json"))
                    using (JsonReader jr = new JsonTextReader(reader))
                    {
                        string jsonValue = jr.ToString();
                    }
                    Console.WriteLine("Do you want to change taxes[1], or exit from programm[2]");
                    int tmpVal = Convert.ToInt32(Console.ReadLine());

                    if (tmpVal == 2) break;

                    Console.WriteLine("Use new taxes and salary");
                    Console.WriteLine("Write your salary:");
                    salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Write your OPV");
                    opv = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your OSMS");
                    osms = Convert.ToDouble(Console.ReadLine());
                    gph.SetNewTaxesForContract(salary: salary, opv: opv, osms: osms, vosms: 0, mrp: 0, IsGPH: true);
                }
            }
            else if (value == 2)
            {
                General general;
                double opv;
                double vosms;
                double osms;
                double mrp;

                Console.WriteLine("Do you want to choose default settings? Write '1' if yes, else '0'");
                int chooseValue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write your salary:");
                int salary = Convert.ToInt32(Console.ReadLine());

                if (chooseValue == 1) general = new General(salary);
                else
                {
                    Console.WriteLine("Write your OPV:");
                    opv = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your VOSMS:");
                    vosms = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your OSMS:");
                    osms = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your MRP");
                    mrp = Convert.ToDouble(Console.ReadLine());
                    general = new General(salary: salary, opv: opv, vosms: vosms, osms: osms, mrp: mrp, IsGPH: false);

                }

                while (true)
                {
                    Console.WriteLine("Okay, we are have your config file. Let's check");
                    using (StreamReader reader = new StreamReader(@"E:\Projects\config.json"))
                    using (JsonReader jr = new JsonTextReader(reader))
                    {
                        string json = jr.ToString();
                    }

                    Console.WriteLine("Do you want to change taxes[1], or exit from programm[2]");
                    int tmpVal = Convert.ToInt32(Console.ReadLine());

                    if (tmpVal == 2) break;

                    Console.WriteLine("Use new taxes and salary");
                    Console.WriteLine("Write your salary:");
                    salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Write your OPV");
                    opv = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your VOSMS");
                    vosms = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your OSMS");
                    osms = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Write your MRP");
                    mrp = Convert.ToDouble(Console.ReadLine());
                    general.SetNewTaxesForContract(salary: salary, opv: opv, vosms: vosms, osms: osms, mrp: mrp, IsGPH: false);

                }
            }
            else
            {
                throw new Exception("We have a problem!");
            }
        }
    }
}
