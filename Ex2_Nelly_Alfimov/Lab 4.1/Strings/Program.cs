using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Program
    {
       public static void Main()
        { 
            Program program = new Program();
            string userInput = string.Empty;

            Console.WriteLine("Please enter a sentance");
            userInput = Console.ReadLine();

            while (userInput!=string.Empty)
            {
            
                string[] sentance = userInput.Split(' ');
                Console.WriteLine("the number of words in the sentance is{0}\n", sentance.Length);
                sentance.Reverse();
                Console.WriteLine("The reversed sentace");
                foreach (string word in sentance)
                {
                    Console.WriteLine("{0},{1}", word, System.Environment.NewLine);
                }
                Array.Sort(sentance);
                Console.WriteLine("Sorted words");
                foreach (string word in sentance)
                {
                    Console.WriteLine("{0}{1}", word, System.Environment.NewLine);
                }
           
                Console.WriteLine("Please enter a sentance");
                userInput = Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
