using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        public enum eOperatorType//operation option for the user
        {
            Mult=1,
            Div,
            Sub,
            Add,
            Or,
        }

        public static void Main(string [] args)
        {
            string displayString = string.Empty;
            Console.WriteLine("Please enter two numbers:");
            double firstUserInput = double.Parse(Console.ReadLine());
            double secondUserInput = double.Parse(Console.ReadLine());
            Console.WriteLine("Please choose an operation for the 2 numbers");
            Program operatorMenu = new Program();
            operatorMenu.PrintOperatorOptions();
            int userOperation =int.Parse(Console.ReadLine());
            eOperatorType operatorOptions = (eOperatorType)userOperation;

            switch (operatorOptions)
            {
                case eOperatorType.Mult://multiplying the two numbers
                    {
                        displayString = string.Format("{0}*{1}={2}\n", firstUserInput, secondUserInput, firstUserInput * secondUserInput);
                        break;
                    }
                case eOperatorType.Sub://substructing the two numbers
                    {
                        if (firstUserInput > secondUserInput)
                        {
                            displayString = string.Format("{0}-{1}={2}\n", firstUserInput, secondUserInput, firstUserInput - secondUserInput);
                        }
                        else
                            displayString = string.Format("{0}-{1}={2}\n", secondUserInput, firstUserInput, secondUserInput - firstUserInput);
                        
                        break;
                    }
                case eOperatorType.Add://adding two numbers
                    {
                        displayString = string.Format("{0}+{1}={2}\n", firstUserInput, secondUserInput, firstUserInput + secondUserInput);
                        break;
                    }
                case eOperatorType.Div://dividing the two numbers
                    {
                        displayString = string.Format("{0}/{1}={2}\n", firstUserInput, secondUserInput, firstUserInput / secondUserInput);
                        break;
                    }
                case eOperatorType.Or://implementing the or operation
                    {
                        displayString = string.Format("{0}|{1}={2}\n", firstUserInput, secondUserInput,(byte)firstUserInput | (byte)secondUserInput);
                        break;
                    }
                default://if was chosen an operator that not in the list
                    {
                        displayString = string.Format("You Can't use this operator\n");
                        break;
                    }
            }

            Console.WriteLine(displayString);          
        }

        public void PrintOperatorOptions()//displaying options in console
        {
            StringBuilder operatorMenu = new StringBuilder();
            operatorMenu.Append("1.*");
            operatorMenu.AppendLine();
            operatorMenu.Append("2.|");
            operatorMenu.AppendLine();
            operatorMenu.Append("3.+");
            operatorMenu.AppendLine();
            operatorMenu.Append("4.-");
            operatorMenu.AppendLine();
            operatorMenu.Append("5./");
            Console.WriteLine(operatorMenu);
        }
    }
}
