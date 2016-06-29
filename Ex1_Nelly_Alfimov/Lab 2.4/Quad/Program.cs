using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double a = 0, b = 0, c = 0;
            Console.WriteLine("Please enter the a coeficient");//getting input from user
            bool isADouble = double.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Please enter the b coeficient");
            bool isBDouble = double.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("Please enter the c coeficient");
            bool isCDouble = double.TryParse(Console.ReadLine(), out c);

            if(isADouble && isBDouble && isCDouble)//if the parcing was successeful calculate the equation
            {
                Program calculation = new Program();
                calculation.CalculateEquation(a, b, c);
            }
            else//case the input was invalid
            {
                Console.WriteLine("Not Valid Input");
            }

            


        }

        public void CalculateEquation(double i_ACoef,double i_BCoef,double i_CCoef)
        {
            double xFirst = 0, xSecond = 0;
            double discriminant =(i_BCoef*i_BCoef)-(4*i_ACoef*i_CCoef);
            string equationResult = string.Empty;
            if(discriminant>0)//case the equation have two result
            {
                xFirst = (-i_BCoef + Math.Sqrt(discriminant)) /( 2 * i_ACoef);
                xSecond = (-i_BCoef - Math.Sqrt(discriminant)) /( 2 * i_ACoef);
                equationResult = string.Format("{0}^2+{1}x+{2}=\n", i_ACoef, i_BCoef, i_CCoef);
                equationResult += string.Format("X1={0} , X2={1}", xFirst, xSecond);
            } 
            else if(discriminant==0)//case the equation has only one result
            {
                xFirst = -i_BCoef / (2 * i_ACoef);
                equationResult = string.Format("{0}^2+{1}x+{2}={3}\n", i_ACoef, i_BCoef, i_CCoef,xFirst);
            }
            else //case the equation has no result
            {
                equationResult = string.Format("No Solution!!");
            }

            Console.WriteLine(equationResult);
        }
    }
}
