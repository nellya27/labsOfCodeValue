using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{

    public class FileFinder
    {
       private List<string> fileList = new List<string>();

        public List<string> FileListByPattern(string pathDirectory,string pattern)
        {
            try
            {
                foreach (string dir in Directory.GetFiles(pathDirectory))
                {
                    if (Path.GetFileName(dir).Contains(pattern))
                    {
                        fileList.Add(Path.GetFileName(dir));
                    }
                }
                foreach (string dir in Directory.GetDirectories(pathDirectory))
                {

                    FileListByPattern(dir, pattern);
                }
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return fileList;
        }

        public void PrintFilelist(List<string> fileList)
        {
            foreach(string item in fileList)
            {
                Console.WriteLine("The name of the file is: {0}",item);
                Console.WriteLine("The lengh of the file is:{0}",item.Length);
            }
        }

        public void GetFileList()
        {
            string path = string.Empty;
            string pattern = string.Empty;
            Console.WriteLine("Please write Enter a Directory path");
            path = Console.ReadLine();
            Console.WriteLine("Choose a pattern for your file search");
            pattern = Console.ReadLine();
            
            List<string> fileList = FileListByPattern(path, pattern);
            PrintFilelist(fileList);            
        }
    }
}
