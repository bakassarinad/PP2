using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp11
{
    class Program
    {
        static bool IsPrime(int x)
        {
            bool IsPrime = true;
            if (x != 1)
            {

                for (int i = 2; i < x; i++)
                    if (x % i == 0)
                    {
                        IsPrime = false;
                    }
            }
             else IsPrime = false;
            return IsPrime;
                
       
        } // внешняя функция определяет число просое или нет
        static bool IsPrimeString(string s)
        {
            return IsPrime(int.Parse(s));
        } // преобразует в числа

        static void Main(string[] args)
        {
            List<string> res = new List<string>(); // создание массив лист чисел результата
            FileStream fs = new FileStream(@"C:\Users\asus\Desktop\PP2\text.txt", FileMode.Open, FileAccess.Read); // файлстрим для чтения файлов
            StreamReader sr = new StreamReader(fs); // для считывания строк в файлах
            string line = sr.ReadLine(); // создание стринга, который состоит из строки, считанной из файла
            string[] nums = line.Split(' '); // массив стринга, который каждое значение берет в массив 
            foreach (var x in nums) // цикл форич берет каждый элемент массива
            {
                if (IsPrimeString(x)) // проверка на прстое 
                {
                    res.Add(x); // добавление чисел в новое выходных данных
                }
            }

                sr.Close();
                fs.Close();

                FileStream fs2 = new FileStream(@"C:\Users\asus\Desktop\PP2\result.txt", FileMode.Create, FileAccess.Write); // создаие чтения файла
                StreamWriter sw = new StreamWriter(fs2);//чтение данных в файле
                foreach (var x in res)// цикл для чтения в массиве выходных данных
                {
                sw.Write(x + " "); // пишет ответ в поток через пробел, 
                Console.Write(x + " "); // выходные данные
                }
                sw.Close(); // закрывает поток стримрайтер
                fs2.Close(); // закрывает поток файлстрим 
            
        }
    }
}
