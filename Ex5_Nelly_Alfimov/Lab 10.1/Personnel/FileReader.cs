using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{

    public class FileReader
    {
        List<string> listOfPersonnel = new List<string>();

        public List<string> GetPersonnelList(string fileName)
        {
            try
            {
                using (StreamReader streamreader = new StreamReader(fileName))
                {
                   
                    string line=string.Empty;
                    while((line=streamreader.ReadLine())!=null)
                    {
                        listOfPersonnel.Add(line);
                    }
                    streamreader.Close();
                }

            }
            catch(IOException exep)
            {
                Console.WriteLine("The file cannot be open");
                Console.WriteLine(exep.Message);
            }

            return listOfPersonnel;
        }

    }
}
