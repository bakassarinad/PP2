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
           
            Stack<string> dirs = new Stack<string>(20);
            
            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);
            string[] mystring = root.Split('\\');

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] mystring2 = currentDir.Split('\\');
                string[] subDirs;
                string space = "";
                for (int i = 0; i < (mystring2.Length - mystring.Length); i++)
                {
                    space = space + "     ";
                }

                System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo(currentDir);
                Console.WriteLine(space+ dirinfo.Name);
               
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
               
                string[] files = null;
              
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

            
                foreach (string file in files)
                {
                   
                    {
                        
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        Console.WriteLine(space+"     " + fi.Name);
                    }
                    
                }
               

                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                    
                }
                

            } 
        }
    
    static void Main(string[] args)
        {
            //string path = Console.ReadLine(); 
          
                 TraverseTree(@"C: \Users\asus\Documents\PP2\Week2");
            //Console.WriteLine("Press any key");
            Console.ReadKey();
        }

    }
}
