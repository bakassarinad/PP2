using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Student
    {
        int id;
        string name;
        int year;

        public Student(int id, string name)
        {
            this.name = name;
            this.id = id;
            this.year = DateTime.Now.Year;

        }
        public void GetData()
        {
            Console.WriteLine(id + " " + name + " " + year);
        }
        public void IncreamentYear()
        {
            year++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student(1360090, "Gena");
            s.GetData();
            s.IncreamentYear();
            s.GetData();
            Console.ReadKey();
        }
    }
}
