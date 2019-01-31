using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int howmany = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= howmany; ++i)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("[*]");


                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            
        }
    }
}
