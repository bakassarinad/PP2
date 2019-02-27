using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Student // описаниемобъекта можно назвать классом, то есть шаблон
    {
        string id;
        string name;
        int year = 1;

        public Student(string id, string name) // параметры 
        {
            this.name = name; // this - ссылка на текущий экземпляр
            this.id = id; 
            //конструкторы - выполняют инициализацию объекта
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
            Student s = new Student("18BD12345", "Radmiiiir");// создание объекта, используя новую операция класс, создает память для объекта
            s.GetData(); // вывод данных с year = 1;
            s.IncreamentYear(); // увелчиваем year на 1, используя метод
            s.GetData(); // вывод данных с year = 1 +1;
            Console.ReadKey();
        }
    }
}
