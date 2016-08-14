using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    public class ProjectBuilder
    {

      public void SequentialBuild()
     {
            var project1 = Task.Factory.StartNew(() => BuildProject(1));
            Thread.Sleep(1000);
            var project2 = Task.Factory.StartNew(() => BuildProject(2));
            Thread.Sleep(1000);
            var project3 = Task.Factory.StartNew(() => BuildProject(3));
            Thread.Sleep(1000);
            var project4 = Task.Factory.StartNew(() => {
                Task.WaitAll(project1);
                BuildProject(4);
            });
            Thread.Sleep(1000);
            var project5 = Task.Factory.StartNew(() =>
            {
                Task.WaitAll(project1, project2, project3);
                BuildProject(5);
            }).ContinueWith((p) => BuildProject(8));
            Thread.Sleep(1000);
            var project6 = Task.Factory.StartNew(() =>
            {                
                Task.WaitAll(project4, project3);
                BuildProject(6);
            });
            Thread.Sleep(1000);
            var project7 = Task.Factory.StartNew(() =>
            {            
                Task.WaitAll(project6, project5);
                BuildProject(7);
            });
     }    

        public void BuildProject(int numberOfProject)
        {            
            Console.WriteLine("{0} was Build",numberOfProject);
        }

    }
}
