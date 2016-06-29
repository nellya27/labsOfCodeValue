using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloPerson
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello,{0}", userName);
            Console.WriteLine("Please Enter a number in a rage of 1-10");
            int userNumber = int.Parse(Console.ReadLine());
            for(int i=0;i<userNumber;i++)
            {
                for(int j=0;j<i;j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("{0}", userName);              
            }
        }
    }
}
