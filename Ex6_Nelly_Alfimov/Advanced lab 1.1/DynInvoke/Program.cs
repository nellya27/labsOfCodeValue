using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    public class Program
    {
        public static void Main()
        {
            
            A aClass = new A();
            B bClass = new B();
            C cClass = new C();

            InvokeHello(aClass, "Nelly");
            InvokeHello(bClass, "Nelly");
            InvokeHello(cClass, "Nelly");
        }

        public static void InvokeHello(object obj,string input)
        {
            try
            {
                obj = obj.GetType().InvokeMember("Hello", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { input });
                Console.WriteLine(obj.ToString());
            }
            catch(MissingMethodException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(System.Reflection.TargetException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
