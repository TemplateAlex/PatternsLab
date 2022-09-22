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
            List<IStudent> students = new List<IStudent>();
            List<List<IMathStudent>> mathStudentsMatrix = new List<List<IMathStudent>>();
            List<List<IComputerScienceStudent>> computerScienceMatrix = new List<List<IComputerScienceStudent>>();
            PolytechFactory polytechFactory = new PolytechFactory();
            KazNUFactory kazNUFactory = new KazNUFactory();

            students.Add(new Student() { Name = "Somebody", Surname = "Somebody", PreferencesUniversity = "polytech", PreferencesKafedra = "math" });
            students.Add(new Student() { Name = "Klim", Surname = "Sanych", PreferencesUniversity = "kaznu", PreferencesKafedra = "math" });
            students.Add(new Student() { Name = "Max", Surname = "Verstappen", PreferencesUniversity = "polytech", PreferencesKafedra = "cs" });
            students.Add(new Student() { Name = "Nicholas", Surname = "Latifi", PreferencesUniversity = "polytech", PreferencesKafedra = "math" });
            students.Add(new Student() { Name = "Carlos", Surname = "Sainz", PreferencesUniversity = "kaznu", PreferencesKafedra = "cs" });

            List<IMathStudent> polytechMathStudents = new List<IMathStudent>();
            List<IMathStudent> kaznuMathStudents = new List<IMathStudent>();
            List<IComputerScienceStudent> polytechCSStudents = new List<IComputerScienceStudent>();
            List<IComputerScienceStudent> kaznuCSStudents = new List<IComputerScienceStudent>(); 

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].PreferencesKafedra == "math" && students[i].PreferencesUniversity == "polytech")
                {
                    polytechMathStudents.Add(polytechFactory.CreateMathStudent(students[i]));
                }
                else if (students[i].PreferencesKafedra == "math" && students[i].PreferencesUniversity == "kaznu")
                {
                    kaznuMathStudents.Add(kazNUFactory.CreateMathStudent(students[i]));
                }
                else if (students[i].PreferencesUniversity == "polytech")
                {
                    polytechCSStudents.Add(polytechFactory.CreateComputerScienceStudent(students[i]));
                }
                else
                {
                    kaznuCSStudents.Add(kazNUFactory.CreateComputerScienceStudent(students[i]));
                }
            }

            mathStudentsMatrix.Add(polytechMathStudents);
            mathStudentsMatrix.Add(kaznuMathStudents);
            computerScienceMatrix.Add(polytechCSStudents);
            computerScienceMatrix.Add(kaznuCSStudents);

            for (int i = 0; i < 2; i++)
            {
                if (i == 0) Console.WriteLine("---Polytect Math Students---");
                if (i == 1) Console.WriteLine("\n---KazNU Math Students---");

                for (int j = 0; j < mathStudentsMatrix[i].Count; j++)
                {
                    mathStudentsMatrix[i][j].DoMathTask();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0) Console.WriteLine("\n---Polytech Computer Science Students---");
                if (i == 1) Console.WriteLine("\n---KazNU Computer Science Students---");

                for (int j = 0; j < computerScienceMatrix[i].Count; j++)
                {
                    computerScienceMatrix[i][j].DoCSTask();
                }
            }
        }
    }
}
