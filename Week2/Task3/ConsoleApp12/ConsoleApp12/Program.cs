using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp12
{
    class Program
    {
        static void TraverseTree(string root)
        {

            Stack<string> dirs = new Stack<string>(20); // создание стэка из стрингов размером 20

            if (!System.IO.Directory.Exists(root)) // дайрекктори позволяет работать с каталогами exists определяет существует ли каталог данного пути
            { 
                throw new ArgumentException(); //генерируется, если в метод для параметра передается некорректное значение
            }
            dirs.Push(root); // уровень пути увеливачиваем, записывая в стак
            string[] mystring = root.Split('\\'); // уровень вложенности, хранится строкой, вложенность корневого каталога 

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop(); // удаляет проанализированные элементы
                string[] mystring2 = currentDir.Split('\\'); // адрес папки, когда мы погрузились во внутрь, отступы от края 
                string[] subDirs; // внутри каждой директории мы должны анализировать директории внутренние поддриктетории
                string space = "";
                for (int i = 0; i < (mystring2.Length - mystring.Length); i++) // разница длин вляет на отступ
                {
                    space = space + "     "; //отступы
                }

                System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo(currentDir); //Данный класс предоставляет функциональность для создания, удаления, перемещения и других операций с каталогами.
                Console.WriteLine(space + dirinfo.Name); // печать данного каталога
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir); // возвращает имена подкатологов
                }
                string[] files = null; //стринг файлов пустой

                {
                    files = System.IO.Directory.GetFiles(currentDir);  // файлс заполняет данной директорией
                }
                foreach (string file in files) // цикл для каждого файла (элемента)
                {
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(file); // предоставляет информарцию о файле 
                        Console.WriteLine(space + "     " + fi.Name);
                    }

                }

                foreach (string str in subDirs) // для каждого стринга  в субдиректори
                {
                    dirs.Push(str); // добавление стринги в директорию
                }

            }
        }

        static void Main(string[] args)
        {
            TraverseTree(@"C: \Users\asus\Documents\PP2\Week2");
            Console.ReadKey();
        }

    }
}
