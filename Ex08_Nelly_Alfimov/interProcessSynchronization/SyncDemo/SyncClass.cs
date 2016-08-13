using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    public class SyncClass
    {

        public void SycInitialization()
        {
            Mutex syncFileMutex = new Mutex(false,"mutexFile");
            
            for (int i=0;i<1000;i++)
            {
                try
                {
                    syncFileMutex.WaitOne();
                    StreamWriter dataWriter = File.AppendText("c:\\Temp\\data.txt");
                    string currentProcees = Process.GetCurrentProcess().ProcessName;
                    dataWriter.WriteLine(currentProcees);
                    dataWriter.Close();
                   
                }
                catch(AbandonedMutexException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    syncFileMutex.ReleaseMutex();
                }
            }           
            syncFileMutex.Dispose();
        }
    }
}
