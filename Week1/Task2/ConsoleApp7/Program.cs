using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Student
    {
        string id;
        string name;
        int year = 1;

        public Student(string id, string name) // параметры 
        {
            this.name = name;
            this.id = id; 
            //конструкторы
        }
        public void GetData()
        {
            Console.WriteLine(id + " " + name + " " + year);
        }
        public void IncreamentYear()
        {
            year++;
        } // 2 метода
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("18BD12345", "Radmiiiir");
            s.GetData();
            s.IncreamentYear();
            s.GetData();
            Console.ReadKey();
        }
    }
}
