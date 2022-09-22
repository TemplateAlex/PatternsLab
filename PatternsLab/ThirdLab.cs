using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab
{
    interface IStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PreferencesUniversity { get; set; }
        public string PreferencesKafedra { get; set; }
    }

    class Student : IStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PreferencesUniversity { get; set; }
        public string PreferencesKafedra { get; set; }

    }
    //Abstract Factory
    internal interface IMathStudent 
    { 
        void DoMathTask();
        string Name { get; set; }
        string Surname { get; set; }
    }
    internal interface IComputerScienceStudent
    {
        void DoCSTask();
        string Name { get; set; }
        string Surname { get; set; }
    }
    internal interface IUniversity 
    {
        IMathStudent CreateMathStudent(IStudent student);
        IComputerScienceStudent CreateComputerScienceStudent(IStudent student);
    }

    internal class KazNUFactory: IUniversity
    {
        public IMathStudent CreateMathStudent(IStudent student)
        {
            return new MathKazNUStudent(student.Name, student.Surname);
        }

        public IComputerScienceStudent CreateComputerScienceStudent(IStudent student)
        {
            return new ComputerScienceKazNUStudent(student.Name, student.Surname);
        }
    }

    internal class PolytechFactory: IUniversity
    {
        public IMathStudent CreateMathStudent(IStudent student)
        {
            return new MathPolytechStudent(student.Name, student.Surname);
        }

        public IComputerScienceStudent CreateComputerScienceStudent(IStudent student)
        {
            return new ComputerSciencePolytechStudent(student.Name, student.Surname);
        }
    }

    internal class MathPolytechStudent: IMathStudent
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public MathPolytechStudent(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public void DoMathTask()
        {
            Console.WriteLine($"Polytech Math Student: {Name} {Surname}");
        }
    }

    internal class MathKazNUStudent: IMathStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public MathKazNUStudent(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public void DoMathTask()
        {
            Console.WriteLine($"KazNU Math Student: {Name} {Surname}");
        }
    }

    internal class ComputerSciencePolytechStudent: IComputerScienceStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ComputerSciencePolytechStudent(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public void DoCSTask()
        {
            Console.WriteLine($"Polytech Computer Science Student: {Name} {Surname}");
        }
    }

    internal class ComputerScienceKazNUStudent: IComputerScienceStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ComputerScienceKazNUStudent(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public void DoCSTask()
        {
            Console.WriteLine($"KazNU Computer Science Student: {Name} {Surname}");
        }
    }
}
