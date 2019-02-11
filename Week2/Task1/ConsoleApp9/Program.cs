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

        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\D\1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            sr.Close();
            fs.Close();
            
            if (CheckPalindrome(str))
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");

            Console.ReadKey();
        }
    }
}
