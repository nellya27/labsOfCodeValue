using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public class Program
    {
        public static void Main()
        {
            AssemblyAnalaizer analaizer = new AssemblyAnalaizer();
            Assembly newAssembly = Assembly.GetExecutingAssembly();
            bool approved=analaizer.AnalaizeAssembly(newAssembly);
            if (approved)
            {
                Console.WriteLine("All the reviews are approved");
            }
            else
                Console.WriteLine("Not all the reviews are approved");
        }
    }
}
