using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultBoard
{
    class Program
    {
        private const int k_NumOfRow = 10;
        private const int k_NumOfCol = 10;
        public static void Main(string[] args)
        {
            StringBuilder multResult = new StringBuilder();
           for (int i=1;i<=k_NumOfRow;i++)
            {
                for(int j=1;j<=k_NumOfCol;j++)
                {
                    multResult.AppendFormat("{0,4}",i*j);
                }

                multResult.AppendLine();
            }

            Console.WriteLine(multResult);
        }
       
    }
}
