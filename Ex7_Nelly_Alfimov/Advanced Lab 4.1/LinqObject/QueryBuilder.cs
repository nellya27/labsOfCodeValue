using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqObject
{
    public class QueryBuilder
    {

        public void DisplayInterfacesAndMethods()
        {
            Assembly assembly = Assembly.Load("mscorlib");
            var interfacePublicList = from a in assembly.GetTypes()
                                      where a.IsInterface && a.IsPublic
                                      orderby a.Name
                                      select new { Name = a.Name, methodCount = a.GetMethods().Count() };



            foreach (var t in interfacePublicList)
            {
                Console.WriteLine(t);
            }
        }

        public void DisplayProcesses()
        {
            LinqHelper func = new LinqHelper();
            var processList = from p in Process.GetProcesses()
                              where p.Threads.Count < 5 && func.CheckProcess(p)
                              orderby p.Id
                              select new { Name = p.ProcessName, Pid = p.Id, StartTime = p.StartTime.ToString()};


            foreach (var item in processList)
            {
                Console.WriteLine(item);
            }
        }

        public void DisplayProcessExtended()
        {
            LinqHelper func = new LinqHelper();
            var processList = from p in Process.GetProcesses()
                              where p.Threads.Count < 5 && func.CheckProcess(p)
                              orderby p.Id
                              group p by p.BasePriority
                              into newGroup
                              select new { Key = newGroup.Key, Value = newGroup };

            foreach(var item in processList)
            {
                Console.WriteLine(item.Key);
                foreach(var value in item.Value)
                {
                    Console.WriteLine(value.ProcessName);
                }

            }
                              
        }

        public void DisplayTotalNumberOfThreads()
        {
            var ThreadNumber = from t in Process.GetProcesses()
                               select new { ThreadsNumber = t.Threads.Count};
            int TotalThread = 0;
            
            foreach(var item in ThreadNumber)
            {
                TotalThread += item.ThreadsNumber;
            }

            Console.WriteLine("The total number of threads is: {0}",TotalThread);
        }
    }
}
