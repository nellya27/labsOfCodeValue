using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqObject
{
    public class Program
    {


        public static void Main()
        {
            QueryBuilder newQueryBuilder = new QueryBuilder();
            newQueryBuilder.DisplayInterfacesAndMethods();
            newQueryBuilder.DisplayProcesses();
            newQueryBuilder.DisplayProcessExtended();
            newQueryBuilder.DisplayTotalNumberOfThreads();

                      
            string source = "bC";
            ExmpClass dest = new ExmpClass();
            source.CopyTo(dest);
            Console.WriteLine(dest.GetA);
           
        }
    }
             
}