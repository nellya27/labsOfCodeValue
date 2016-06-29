using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountLib;

namespace Test
{
    public class Program
    {
      private enum eActiomMenu//the actions that you can do with the account
        {
            Deposit=1,
            Withdraw,
            Balance,
        }

        public static void Main(string[]args)
        {
            Program test = new Program();
            Account newAccount = AccountFactory.CreateAccount(40);
            Console.WriteLine("Please choose from the menu below");
            test.PrintMenu();
            test.GetUserChoise(newAccount);
            Account AnotherAccount = AccountFactory.CreateAccount(50);
            newAccount.Transfer(AnotherAccount,-50);
            Console.WriteLine("the account balance after transfer: {0}\n", newAccount.GetBalance);
           
        }

        public void PrintMenu()//printing the options for the user
        {
            StringBuilder menuBuilder = new StringBuilder();
            menuBuilder.Append("1.Deposit Money to your account");
            menuBuilder.AppendLine();
            menuBuilder.Append("2.WithDraw money from your account");
            menuBuilder.AppendLine();
            menuBuilder.Append("3.Show account balance");
            menuBuilder.AppendLine();
            Console.WriteLine(menuBuilder);
        }

        public void GetUserChoise(Account i_NewAccount)
        {
            int userChoise = int.Parse(Console.ReadLine());
            int userInput = 0;
            eActiomMenu menuChoise = (eActiomMenu)userChoise;
            switch(menuChoise)
            {
                case eActiomMenu.Deposit:
                    {
                        try
                        {
                            Console.WriteLine("Please Enter the amount of the money you want to deposit\n");
                            userInput = int.Parse(Console.ReadLine());
                            i_NewAccount.Deposit(userInput);
                           
                        }
                        catch(ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case eActiomMenu.Withdraw:
                    {
                        try
                        {
                            Console.WriteLine("Please enter the amount of money you want to withdraw\n");
                            userInput = int.Parse(Console.ReadLine());
                            i_NewAccount.WithDraw(userInput);
                        }
                        catch(InsufficientFundsException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    }
                case eActiomMenu.Balance:
                    {
                        Console.WriteLine("Your account balance:{0}\n", i_NewAccount.GetBalance);
                        break;
                    }
            }
        }

       

    }
}
