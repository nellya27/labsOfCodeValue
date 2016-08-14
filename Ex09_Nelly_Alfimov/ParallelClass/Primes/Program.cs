using System;
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


            List<int> listOfPrimes = CalcPrimes(2000000, 30000000);
                Console.WriteLine("numbers before stop:");
                foreach (int prime in listOfPrimes)
                {
                    Console.WriteLine("{0}",prime);
                }
            
        }

        public static List<int> CalcPrimes(int firstNumber,int lastNumber)
        {
            Random randomNumber = new Random();
            List<int> claculationResult =new List<int>();

           var loopResult= Parallel.For(firstNumber, lastNumber,(i,loopState) =>
              {
                 if(randomNumber.Next(10000000)==0)
                  {
                      loopState.Stop();
                      return;
                  }
                  bool isPrime = true;             
                      for (int j = 2; j < i; j++)
                      {

                          if (i % j == 0)
                          {
                              isPrime = false;
                              break;
                          }
                      }

                  if (isPrime)
                  {
                     
                    claculationResult.Add(i);
                      
                  }
              });
            return claculationResult;
        }


    }
}
