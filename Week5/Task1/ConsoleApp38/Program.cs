using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp38
{
    public class ComplexNumber
    {
        public int a { get; set; }
        public int b { get; set; }
        
        public ComplexNumber()
        {

        }
        
        public void Print()
        {
            Console.WriteLine("{0}+{1}*i", a, b);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.a = Convert.ToInt32(Console.ReadLine());
            cn.b = Convert.ToInt32(Console.ReadLine());

            cn.Print();
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));
            FileStream fs = new FileStream("1.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, cn);
            fs.Close();

            FileStream fs2 = new FileStream("1.xml", FileMode.Open, FileAccess.Read);
            ComplexNumber cn2 = (ComplexNumber)xs.Deserialize(fs2);
            fs2.Close();
            cn2.Print();
            


            Console.ReadKey();
        }
    }
}
