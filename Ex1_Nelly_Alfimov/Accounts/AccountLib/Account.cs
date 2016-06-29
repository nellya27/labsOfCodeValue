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
            this.m_Balance += i_MoneyAmount;
        }

        public void WithDraw(int i_MoneyAmount)//taking money from the account
        {
            if (i_MoneyAmount > this.m_Balance)
            {
                Console.WriteLine("you cant withdraw this amount of money");
            }
            else
            {
                this.m_Balance -= i_MoneyAmount;
            }
        }

        public void Transfer(Account i_AnotherAccount)//transfering money from one account to enother
        {
            this.m_Balance += i_AnotherAccount.GetBalance;
        }
    }
}
