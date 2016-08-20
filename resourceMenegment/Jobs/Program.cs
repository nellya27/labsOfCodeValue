using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Jobs {
	class Program {

        static void Main(string[] args)
        {
            try
            {
                Job newJob = new Job("claculator");
                newJob.AddProcessToJob(Process.Start(new ProcessStartInfo("Notepad.exe")));
                Console.ReadLine();
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    newJob.Kill();
                }
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                
                for (int i=0;i<20;i++)
                {
                    Job newJob = new Job(i.ToString());
                    
                }
                Console.ReadLine();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
           
		}
	}
}
