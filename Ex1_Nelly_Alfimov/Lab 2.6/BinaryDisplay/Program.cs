using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int numOfUser = int.Parse(Console.ReadLine());
            string binaryNum = Convert.ToString(numOfUser, 2);//converting to binary
            Console.WriteLine("Binary represntation : {0} ", binaryNum);
            
            int numOfBits = 0;
            int currentInput = numOfUser;
            while (currentInput != 0)//counting 1's bits
            {
                if ((currentInput & 1) == 1)
                {
                    numOfBits++;
                }
                currentInput =currentInput>> 1;
              
            }
            Console.WriteLine("The number of 1's in the binary number: {0}",numOfBits);
        }
    
        }
    }

