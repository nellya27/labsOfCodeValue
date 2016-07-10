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

            Console.WriteLine(rat1.ToString());
            Console.WriteLine(rat2.ToString());
            Console.WriteLine(rat3.ToString());

            Rational rat5 = rat1 + rat2;
            Rational rat6 = rat2 * rat3;
            Rational rat7 = rat3 / rat4;
            Rational rat8 = rat4 - rat1;

            Console.WriteLine(rat5.ToString());
            Console.WriteLine(rat6.ToString());
            Console.WriteLine(rat7.ToString());
            Console.WriteLine(rat8.ToString());

            Rational rat9 = new Rational(2, 4);
            Rational rat10 = new Rational(1, 2);

            if (rat9.Equals(rat10))
            {
                Console.WriteLine("the numbers are equal");
            }
            else
            {
                Console.WriteLine("the numbers are not equal");
            }


            Console.WriteLine("{0},{1},{2},{3}\n", rat1.GetAsDouble, rat2.GetAsDouble, rat3.GetAsDouble, rat5.GetAsDouble);


        }
    }
}
