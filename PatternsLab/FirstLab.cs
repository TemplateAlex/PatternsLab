using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PatternsLab
{
    [Serializable]
    internal sealed class TaxDeduction
    {
        private static TaxDeduction? _instance;

        public double OPV { get; set; }
        public double VOSMS { get; set; }
        public double OSMS { get; set; }
        public double MRP { get; set; }

        public double ipn;

        public double so;

        public double sn;

        public double salary;

        public double clearSalary;
        [JsonIgnore]
        public bool IsGPH { get; set; }
        private TaxDeduction()
        {

        }
        public static TaxDeduction GetInstance()
        {
            if (_instance == null) _instance = new TaxDeduction();

            return _instance;
        }

        public void SetTaxes(double opv, double vosms, double osms, double mrp, bool IsGPH, double salary)
        {
            this.OPV = opv;
            this.VOSMS = vosms;
            this.OSMS = osms;
            this.MRP = mrp;
            this.IsGPH = IsGPH;
            this.salary = salary;

            if (IsGPH)
            {
                this.ipn = 0.1 * (salary - OPV);
                clearSalary = salary - OPV - ipn - OSMS;
            }
            else
            {
                ipn = 0.1 * (salary - OPV - 14 * MRP - VOSMS);

                if (ipn < 0) throw new Exception("Vy padla!");

                clearSalary = salary - OPV - ipn - VOSMS;
                so = 0.035 * (salary - OPV);
                sn = 0.095 * (salary - OPV - VOSMS) - so;
            }
        }

    }
    abstract class Contract
    {
        public TaxDeduction? taxDeduction;

        protected void CreateOrConfigurateFile()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter writer = new StreamWriter(@"E:\Projects\config.json"))
            using (JsonWriter jw = new JsonTextWriter(writer))
            {
                serializer.Serialize(jw, taxDeduction);
            }
        }

        protected void GetObjectFromConfig()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader reader = new StreamReader(@"E:\Projects\config.json"))
            using (JsonReader jr = new JsonTextReader(reader))
            {
                serializer.Deserialize<TaxDeduction>(jr);
            }
        }

        public void SetNewTaxesForContract(double salary, double opv, double vosms, double osms, double mrp, bool IsGPH)
        {
            this.GetObjectFromConfig();

            if (taxDeduction == null) throw new Exception("We have a problem");

            taxDeduction.SetTaxes(opv, vosms, osms, mrp, IsGPH, salary);
            this.CreateOrConfigurateFile();

        }
 
    }
    class General: Contract
    {
        public General(double salary = -1, double opv = 0.1, double vosms = 0.02, double osms = 0.03, double mrp = 3063, bool IsGPH = false)
        {

            if (opv < 0 || vosms < 0 || osms < 0 || mrp < 0) throw new Exception("Vy padla!");


            if (salary > 0)
            {
                taxDeduction = TaxDeduction.GetInstance();
                taxDeduction.SetTaxes(opv, vosms, osms, mrp, IsGPH, salary);
                this.CreateOrConfigurateFile();
            } 
        }
    }

    class GPH: Contract
    {
        public GPH(double salary = -1, double opv = 0.1, double vosms = -1, double osms = 0.03, double mrp = -1, bool IsGPH = true)
        {
            if (opv < 0 || osms < 0) throw new Exception("We have a problem!");

            taxDeduction = TaxDeduction.GetInstance();
            taxDeduction.SetTaxes(opv, vosms, osms, mrp, IsGPH, salary);

            if (salary != -1)
            {
                taxDeduction = TaxDeduction.GetInstance();
                taxDeduction.SetTaxes(opv, vosms, osms, mrp, IsGPH, salary);
                this.CreateOrConfigurateFile();
            }
        }
    }
}
