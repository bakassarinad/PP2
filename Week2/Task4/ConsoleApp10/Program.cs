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
            FileStream fs = new FileStream(@"path/2.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("adada");
            sw.Close();
            fs.Close();            
            File.Copy(@"path/2.txt", @"path1/2.txt");
            File.Delete(@"path/2.txt");
            Console.ReadKey();
        }
    }
}
