using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("please write two numbers");
            int firstNumber, secondNumber;
            bool firstResult = int.TryParse(Console.ReadLine(),out firstNumber);
            bool secondResult = int.TryParse(Console.ReadLine(),out secondNumber);

            if (firstResult && secondResult)
            {
                if (firstNumber <=0 || secondNumber <=0)
                {
                    Console.WriteLine("you can't use negative numbers or 0 to calculate primes");
                }
                else
                {
                    int[] primeInRange = CalcPrimes(firstNumber, secondNumber);
                    foreach (int prime in primeInRange)
                    {
                        Console.WriteLine("*{0}{1}", prime, System.Environment.NewLine);
                    }
                }
            }
            else
            {
                Console.WriteLine("Your input is Invalid");
            }
        }

        public static int [] CalcPrimes(int i_FirstNum,int i_SecondNum)
        {
            ArrayList primeList = new ArrayList();

            for(int i=i_FirstNum;i<i_SecondNum;i++)//2,3,4
            {
                bool isPrime = true;

                for (int j=2;j<i;j++)
                {
                    if(i%j==0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime)
                {
                    primeList.Add(i);
                }
            }

            int[] primeArray = new int[primeList.Count];
            primeList.CopyTo(primeArray);
            return primeArray;
        }
    }

}
