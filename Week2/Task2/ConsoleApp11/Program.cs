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
                
       
        }
        static bool IsPrimeString(string s)
        {
            return IsPrime(int.Parse(s));
        }

        static void Main(string[] args)
        {
            List<string> res = new List<string>();
            FileStream fs = new FileStream(@"C:\Users\asus\Desktop\PP2\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            string[] nums = line.Split(' ');
            foreach (var x in nums)
            {
                if (IsPrimeString(x))
                {
                    res.Add(x);
                }
            }

                sr.Close();
                fs.Close();

                FileStream fs2 = new FileStream(@"C:\Users\asus\Desktop\PP2\result.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs2);
                foreach (var x in res)
                {
                sw.Write(x + " ");
                Console.Write(x + " ");
                }
                sw.Close();
                fs2.Close();
            
        }
    }
}
