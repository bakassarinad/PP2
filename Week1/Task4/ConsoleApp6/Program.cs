using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int howmany = Convert.ToInt32(Console.ReadLine()); // вводим количество строк из звездочек
            string[,] arr = new string[howmany, howmany]; // объявляем двойной массив

                for (int i = 0; i < howmany; ++i) // фориком пробегаемся по строке
                {
                    for (int j = 0; j <= i; j++) // фориком пробегаемся по столбцу
                    {

                      arr[i, j] = "[*]"; // записываем символы
                    Console.Write(arr[i, j]); // выводим в консоль символы
                     }
                    Console.WriteLine(); // переходим на новую строку
                }
                Console.ReadKey(); // консоль не закрывается 
            
        }
    }
}
