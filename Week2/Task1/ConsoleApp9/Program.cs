using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp9
{
    class Program

    {
        static bool CheckPalindrome(string inputString)
        {

            int length = inputString.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (inputString[i] != inputString[length - 1 - i])
                {
                    return false;
                }
            }

            return true;

        } // внешняя функция для определения слова палиндром или нет через проверку первого и последнего символов и так далее
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\D\1.txt", FileMode.Open, FileAccess.Read); // файлстрим позволяет считывать из файлф и записывать в файл
            StreamReader sr = new StreamReader(fs); // класс, позволяет  считывать тесктовое содержимое(текстб или строку)
            string str = sr.ReadLine(); // считывает строку 
            sr.Close(); // закрывает считываемый файл и освобождает ресупсы 
            fs.Close(); // зыкрывает поток считывания самого файла и освобождает ресурсы
            
            if (CheckPalindrome(str)) // вопрос на палиндромность 
            {
                Console.WriteLine("Yes"); // ели да
            }
            else
                Console.WriteLine("No"); // если нет

            Console.ReadKey();
        }
    }
}
