using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObject
{
    public class LinqHelper
    {
       private int b;


        public bool CheckProcess(Process p)
        {
            try
            {
                var StartTime = p.StartTime;
                return true;
            }
            catch(Win32Exception e)
            {
                return false;
            }
        }

        public int Getb
        {
            get { return b; }
        }
    }
}
