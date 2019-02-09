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
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\D\1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            sr.Close();
            fs.Close();
            char[] str2 = str.ToCharArray();
           
            Array.Reverse(str2);
            string str3 = new string(str2);
            if (str == str3)
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");

            Console.ReadKey();
        }
    }
}
