using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    class Program
    {
        private const string k_DollarSign = "$";
        public static void Main(string[] args)
        {
            StringBuilder stairsBuilder = new StringBuilder();
            Console.WriteLine("Please choose number of stairs");
            int numOfStairs = int.Parse(Console.ReadLine());
            for(int i=0;i<=numOfStairs;i++)//printing $
            {
                for(int j=0;j<i;j++)
                {
                    stairsBuilder.Append(k_DollarSign);
                }
                stairsBuilder.AppendLine();
            }

            Console.WriteLine(stairsBuilder);
        }
    }
}
