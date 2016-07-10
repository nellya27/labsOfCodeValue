using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    public class Program
    {
       public static void Main()
        {
            FileReader personnelFile = new FileReader();
            List<string> listOfPersonnel = personnelFile.GetPersonnelList("Personnel.txt");
            foreach(string item in listOfPersonnel)
            {
                Console.WriteLine("{0}{1}", item, System.Environment.NewLine);
            }
        }
    }
}
