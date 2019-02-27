using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp39
{
    public class Mark
    {
        public double point { get; set; }
        //  public string Letter { get; set; }

        public Mark(double n) {
            point = n;
        }
        public string getLetter()
        {
            string letter = "";
            if (point >= 95 && point <= 100) letter = "A";
            if (point >= 90 && point <= 94) letter = "A-";
            if (point >= 85 && point <= 89) letter = "B+";
            if (point >= 80 && point <= 84) letter = "B";
            if (point >= 75 && point <= 79) letter = "B-";
            if (point >= 70 && point <= 74) letter = "C+";
            if (point >= 65 && point <= 69) letter = "C";
            if (point >= 60 && point <= 64) letter = "C-";
            if (point >= 55 && point <= 59) letter = "D+";
            if (point >= 50 && point <= 54) letter = "D-";
            if (point >= 25 && point <= 49) letter = "FX";
            if (point >= 0 && point <= 24) letter = "F";
            return letter;

        }
        public override string ToString()
        {
            return point + " " + getLetter();
        }

        public Mark()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            F2();

            //Console.WriteLine(m.point);
           // Console.WriteLine(m.getLetter());
            Console.ReadKey();
        }
        static void F1()
        {   List<Mark> marks = new List<Mark>();
            Random r = new Random();
            for (int i=0; i < 10; i++)
            {
                marks.Add(new Mark(r.Next(0, 100)));
            }
           
            /*Mark m = new Mark(56);
            Mark m2 = new Mark(78);
            Mark m3 = new Mark(99);
            
            marks.Add(m);
            marks.Add(m2);
            marks.Add(m3);*/

            FileStream fs = new FileStream("1.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            xs.Serialize(fs, marks);
            fs.Close();
        }
        static void F2()
        {
            FileStream fs = new FileStream("1.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> marks = xs.Deserialize(fs) as List<Mark>;
            fs.Close();
            foreach(Mark mark in marks)
            {
                Console.WriteLine(mark.ToString());
            }
            


        }
    }
}
