using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"path/2.txt", FileMode.Create, FileAccess.Write); // запыскаем файлстрим для создания файла и возможноти писать в файле
            StreamWriter sw = new StreamWriter(fs); //  запись в самом файле
            sw.WriteLine("adada"); // операция проводится 
            sw.Close(); // закрытие стримрайтера
            fs.Close();            // закрыие файлстрима
            File.Copy(@"path/2.txt", @"path1/2.txt"); // копирование файла
            File.Delete(@"path/2.txt"); // удаление файла из предыдущей папки
            Console.ReadKey();
        }
    }
}
