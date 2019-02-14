using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void DoubleA(int[] a)
        {
            int num = a.Length; // массив количеством числа а;
            int[] a2 = new int[num * 2]; // массив выходных данных
            

            for (int i = 0; i < num; ++i) // перебираем исходный массив
            {
                
                a2[i * 2] = a[i]; // перезаписывание на две позиции (1 позиция)
                a2[i * 2 + 1] = a[i]; // 2 позиция
                Console.Write(a2[i * 2] + " " + a2[i * 2 + 1] + " "); // вывод на экран
            }
        }
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());  // длина исходного массива
            int[] a = new int[num]; // массив входных данных
            string[] nums = Console.ReadLine().Split(new char[] { ',', ';', '#', ' ' }); // строка входных парметров, разделенное на массив элементов(делит на кусочки входныее данные. не берет строкой)
            for (int i = 0; i < num; ++i)
            {
                a[i] = Convert.ToInt32(nums[i]); // конвертируем из массива строк в исходный массив чисел
            }
            DoubleA(a);

           
            Console.ReadKey();
        }
    }
}
