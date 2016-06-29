using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public class Program
    {
        public static void Main()//testing the rational struct
        {
            Rational rat1 = new Rational(3, 4);
            Rational rat2 = new Rational(5, 6);
            Rational rat3 = new Rational(6, 7);
            Rational rat4 = new Rational(5, 6);
            Rational rat5 = new Rational(5);

            Console.WriteLine(rat1.ToString());
            Console.WriteLine(rat2.ToString());
            Console.WriteLine(rat3.ToString());
            Console.WriteLine(rat5.ToString());
            Console.WriteLine("{0},{1},{2},{3}\n", rat1.GetAsDouble,rat2.GetAsDouble,rat3.GetAsDouble,rat5.GetAsDouble);
            Rational newRat = rat1.Add(rat2);
            Console.WriteLine(newRat.ToString());
            newRat.Reduce();
            Console.WriteLine("rational number after reduction {0}", newRat.ToString());
            Rational newRat2 = rat2.Mul(rat3);
            Console.WriteLine(newRat2.ToString());
            newRat2.Reduce();
            Console.WriteLine("rational number after reduction {0}", newRat2.ToString());
         
            if(rat2.Equals(rat4))
            {
                Console.WriteLine("the numbers are equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
        }
    }
}
