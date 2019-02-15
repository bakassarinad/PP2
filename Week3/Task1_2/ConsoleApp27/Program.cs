using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp27
{

    class Layer 
    {
        public FileSystemInfo[] Content // создание контент клсса работы с файлами 
        {//управление к перменной 
            get; // возвращение значения поля
            set; // установление значения 
        }
        private int selectedItem; 
        public int SelectedItem
        {
            get // считывание переменной 
            {
                return selectedItem; // управление доступом к переменной 
            }
            set // управление переменной селектедайтем 
            { // возвращение выбранного элемента циклически в списке
                if (value >= Content.Length)  // если выбранный элемент стоит на последнем либо больше, тогда 
                {
                    selectedItem = 0; // возвращение на первый выбранный элемент

                }
                else if (value<=0) // если выбранный элемент на првом месте, то возвращаем выбранностьа последний стоящий элемент
                {
                    selectedItem = Content.Length - 1;
                }
                else // если не последнее, то просто валью выбранный элемент
                {
                    selectedItem = value;
                }
            }
        }

        public void Draw() // метод дра рисование
        {
            Console.BackgroundColor = ConsoleColor.Black; // фон черный 
            Console.Clear(); // очищение консоли 

            for (int i = 0; i < Content.Length; ++i) // цикл, пробегающиц по контенту файлов 
            {
                if (i == SelectedItem) // если выбранный элемент
                {
                    Console.BackgroundColor = ConsoleColor.Blue; // фон синий
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black; // если не выбранный, то черный 
                }
                if (Content[i].GetType() == typeof(DirectoryInfo)) // если тип элемента дайректори, то 
                {
                    Console.ForegroundColor = ConsoleColor.White; // список белый 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // если файл, желтый 
                }
                Console.WriteLine(i + 1 + ". " + Content[i].Name); // вывод имен контента
            }
        }
    }
    enum ViewMode // перечисление 
    {
        ShowDirectory, // дайректори 
        ShowFile // файл

    }
    class Program

    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\английский"); // передача контента файлов с помощью дайректориинфо
            Stack<Layer> history = new Stack<Layer>(); // создание стека 
            history.Push(
                new Layer
                {
                    Content = dir.GetFileSystemInfos() // возвращает массив каталога 
                } // закидываем контент в стек 
            );

            ViewMode viewMode = ViewMode.ShowDirectory; // формат отображения в списке
            bool esc = false; // пока ескейп равно фолс 
            while (!esc)
            {
                if (viewMode == ViewMode.ShowDirectory) // если дайректория 
                {
                    history.Peek().Draw(); // выполняем метод 
                }
                ConsoleKeyInfo key = Console.ReadKey(); // подключение клавиатуры 
                switch (key.Key) // переключатель на выбор кнопки
                {
                    case ConsoleKey.F2: // нажатие ф2 
                        Console.BackgroundColor = ConsoleColor.Black; // фон черный 
                        Console.Clear(); // очищение консоли
                        string name = Console.ReadLine(); // стринг имени ввод имени 
                        int x3 = history.Peek().SelectedItem; // выборный объект 
                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3]; // элемент выбранный объект 
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo)) // если  элемент директория
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo; // записываем переменную элемента как директорию
                            Directory.Move(fileSystemInfo3.FullName, Directory.GetParent(directoryInfo.FullName) + "/" + name); //  директория перемещает файл, то есть создает новый путь с именем, который мы ввели
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos(); // возвращение на предыдущий уровень
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo3 as FileInfo; // если файл, то преобразуем считывание как файл
                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name); // переименование файла
                            history.Peek().Content =fileInfo.Directory.GetFileSystemInfos(); // возвращение на предыдущий уровень 
                        }
                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem; // создание переменной x2как селектед айтем 
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2]; // создание файлсистеминфо для работы с контентом x2
                        history.Peek().SelectedItem--; // уходим на одну вниз
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo)) // если файлсистеинфо = директория 
                        {
                            DirectoryInfo directoryInfo =fileSystemInfo2 as DirectoryInfo; // запись как директория 
                            Directory.Delete(directoryInfo.FullName, true); // удаление
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos(); //получение контента пути на уровень выше 
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo2 as FileInfo; // установление как файл инфо
                            File.Delete(fileInfo.FullName); // удаление файла 
                            history.Peek().Content = fileInfo.Directory.Parent.GetFileSystemInfos(); // получение пути до файла 
                        }
                        break;
                    case ConsoleKey.UpArrow: // стрелка вверх
                        history.Peek().SelectedItem--; // счетчик мньше становится 
                        break;
                    case ConsoleKey.DownArrow: // счетчик вверх
                        history.Peek().SelectedItem++; // счетчик больше становится 
                        break;
                    case ConsoleKey.Enter: // ентер 
                        int x = history.Peek().SelectedItem; //создание переменной селектед айтем x 
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x]; // создание класса Файлсистеминфо для работы с элементом
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo)) // если директория 
                        {
                            viewMode = ViewMode.ShowDirectory; // то перечисление равно директория 
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo; // перезаписываем файлсистеминфо как директорию
                            history.Push(new Layer { Content = directoryInfo.GetFileSystemInfos() }); // кидаем в новый список элементов
                        }
                        else
                        {
                            viewMode = ViewMode.ShowFile; // иначе файл 
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read)) // открытие, чтение
                            {
                                using (StreamReader sr = new StreamReader(fs)) // используем класс чтение из файла 
                                {
                                    Console.BackgroundColor = ConsoleColor.White; // фон белый 
                                    Console.Clear();// очищение консоли
                                    Console.ForegroundColor = ConsoleColor.Black; // текст черный 
                                    Console.WriteLine(sr.ReadToEnd()); // выписать содержимое 
                                }
                            }

                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (viewMode == ViewMode.ShowDirectory) // если директория 
                        {
                            history.Pop(); // удаление хистори
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black; // перекрас в черный фон
                            Console.Clear(); // очищение
                            Console.ForegroundColor = ConsoleColor.White; // цвет текста белый 
                            viewMode = ViewMode.ShowDirectory; // показать директорию 
                        }
                        break;
                    case ConsoleKey.Escape: // закрытие программы
                        esc = true;
                        break;



                }
            }
        }
    }
}
