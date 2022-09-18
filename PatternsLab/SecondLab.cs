using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab
{
    class Appartament
    {
        public double Electricity { get; set; }

        public int TypeTarrification { get; set; }
    }
    interface ITarrification
    {
        double CountPrice(double elictricity);
    }

    class FirstTarrification: ITarrification
    {
        public double CountPrice(double electricity)
        {
            return electricity * 19.75;
        }
    }

    class SecondTarrification: ITarrification
    {
        public double CountPrice(double electricity)
        {
            return electricity * 15;
        }
    }

    class ThirdTariffication : ITarrification
    {
        public double CountPrice(double electricity)
        {
            return electricity * 10;
        }
    }

    abstract class TarrificationFactory
    {
        protected ITarrification? _tarrification;

        public abstract void SetTarrification();

        public double GetPriceForElectricity(double electricity)
        {
            if (_tarrification == null) throw new Exception("We have a problem!");

            return _tarrification.CountPrice(electricity);
        }
    }
    
    class FirstTarrificationFactory: TarrificationFactory
    {
        public override void SetTarrification()
        {
            _tarrification = new FirstTarrification();
        }
    }

    class SecondTarifficationFactory: TarrificationFactory
    {
        public override void SetTarrification()
        {
            _tarrification = new SecondTarrification();
        }
    }

    class ThirdTarrificationFactory: TarrificationFactory
    {
        public override void SetTarrification()
        {
            _tarrification = new ThirdTariffication();
        }
    }
}
