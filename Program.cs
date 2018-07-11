using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string OriginalPath = args[0];
            string TargetPath = args[1];
            
            List<string> OriginalFileNames = new List<string>();
            List<string> TargetFileNames = new List<string>();
            //List<string> DifferentFiles = new List<string>();

            DirectorySearch(OriginalPath,OriginalFileNames,OriginalPath);
            DirectorySearch(TargetPath, TargetFileNames,TargetPath);
            var SameFiles = OriginalFileNames.Intersect(TargetFileNames);
            var DifferentFiles = SameFiles.Except(OriginalFileNames);
            var FirstDifferent = OriginalFileNames.Except(SameFiles);
            var SecondDifferent = TargetFileNames.Except(OriginalFileNames);
            Console.WriteLine("Files only in first path");
            foreach (var i in FirstDifferent)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Files only in second path");
            foreach (var i in SecondDifferent)
            {
                Console.WriteLine(i);
            }



            Console.ReadKey();
        }


        public static void DirectorySearch(string dir, List<string>files,string prefix)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    //Console.WriteLine(f);
                    //Console.WriteLine(f.Replace(dir,""));
                    files.Add(f.Replace(prefix, ""));
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    //Console.WriteLine(Path.GetFileName(d));
                    DirectorySearch(d,files,prefix);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
