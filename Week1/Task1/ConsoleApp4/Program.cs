using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static bool Prost(int a)
        {
            bool f = true;
            if (a != 1)
            {


                for (int i = 2; i < a; ++i)
                {
                    if (a % i == 0)
                    {
                        f = false;
                    }
                }
            }
            else f = false;
            return f;
        } /* внешняя функция которая проверяет число на простоту true - это простое число; false - не простое*/
       
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine()); // количество чисел
            int[] a = new int[num]; // массив целых чисел размерности num  
            string[] nums = Console.ReadLine().Split(new char[] { ',', ';', '#', ' ' }); // строка входных парметров, разделенное на массив элементов(делит на кусочки входныее данные. не берет строкой)

            int counter = 0; // счетчик для кол-ва простых
            string answer = "";// строка для выходных данных
            for (int i = 0; i < num; ++i)
            {
                //int number = Convert.ToInt32(Console.ReadLine());
                a[i] = int.Parse(nums[i]); // конверт в числа
                if (Prost(a[i])) // проверка на простоту
                {
                    counter++; // увеливать на 1
                    answer = answer  + a[i].ToString()+" "; // формирование строки входных параметров
                }
            }
              
        }
    }
}
