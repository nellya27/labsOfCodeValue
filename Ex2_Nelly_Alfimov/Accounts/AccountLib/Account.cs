using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLib
{
    public class Account
    {
        private int m_AccountId;
        private int m_Balance;

        internal Account(int i_AccountId)
        {
            this.m_AccountId = i_AccountId;
        }

        public int GetId//displaying the account id
        {
            get { return m_AccountId; }
        }

        public int GetBalance//displaing the account balance
        {
            get { return m_Balance; }
        }

        public void Deposit(int i_MoneyAmount)//depositing money to accout
        {
            if (i_MoneyAmount > 0)
            {
                this.m_Balance += i_MoneyAmount;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public void WithDraw(int i_MoneyAmount)//taking money from the account
        {
            if(i_MoneyAmount<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            else if (this.m_Balance-i_MoneyAmount>=0)
            {
                this.m_Balance -= i_MoneyAmount;
            }
            else
            {
                throw new InsufficientFundsException("you cant withdraw this amount of mouney it will cause an overdraft");
            }
        }

        public void Transfer(Account i_AnotherAccount,int i_MoneyAmount)//transfering money from one account to enother
        {
            int currentBalance = this.m_Balance;
            try
            {
                this.WithDraw(i_MoneyAmount);
                i_AnotherAccount.Deposit(i_MoneyAmount);
            }
            catch(InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Transfer atempt has been made");
                Console.WriteLine("The balance before the transfer: {0}", currentBalance);
                Console.WriteLine("The balnce after transfer: {0}", this.m_Balance);
            }
        }
    }
}
