using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PatternsLab
{
    //Composite pattern
    
    internal abstract class Human
    {
        protected readonly string name;
        protected readonly string surname;

        public Human(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public abstract string ShowPartners();

        public virtual void AddPartner(Human human)
        {
            throw new NotImplementedException();
        }
        public virtual void RemovePartner(Human human)
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class Employee: Human
    {
        private List<Human> employeers = new List<Human>();

        public Employee(string name = "Somebody", string surname = "Somebody"):base(name, surname) { }
        public override string ShowPartners()
        {
            StringBuilder sbResult = new StringBuilder($"(Employee: {name} {surname} [");

            foreach(var employee in employeers)
            {
                sbResult.Append(employee.ShowPartners());
            }
            sbResult.Append("])");

            return sbResult.ToString();
        }

        public override void AddPartner(Human human)
        {
            this.employeers.Add(human);            
        }

        public override void RemovePartner(Human human)
        {
            this.employeers.Remove(human);
        }
    }

    internal sealed class JuniorEmployee: Human
    {
        public JuniorEmployee(string name = "Somebody", string surname = "Somebody"): base(name, surname) { }

        public override string ShowPartners()
        {
            return $"'Junior Employee: {name} {surname}'";
        }
    }


    //Adapter Pattern

    internal interface ISerialization
    {
        void DoXMLSerialization(ForSerialize objForSerialize);
    }

    internal class SeriazlizationJsonAdapter: ISerialization
    {
        private JsonSerialization _serialization;

        public SeriazlizationJsonAdapter()
        {
            _serialization = new JsonSerialization();
        }
        public void DoXMLSerialization(ForSerialize objForSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ForSerialize));

            using (FileStream fs = new FileStream(@"E:\Projects\text.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, objForSerialize);
            }
        }

        public void DoJsonSerialization(ForSerialize objForSerialize)
        {
            this._serialization.DoJsonSerialization(objForSerialize);
        }
    }

    internal class JsonSerialization
    {
        public void DoJsonSerialization(ForSerialize objForSerialize)
        {
            JsonSerializer jsonSerialization = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(@"E:\Projects\text.json"))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jsonSerialization.Serialize(jw, objForSerialize);
            }
        }
    }

    [Serializable]
    public class ForSerialize
    {
        public string name = "asd";
        public string surname = "asd";
        public int age = 123;

    }
}
