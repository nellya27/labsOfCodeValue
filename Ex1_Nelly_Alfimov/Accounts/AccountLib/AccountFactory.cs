using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLib
{
    public static class AccountFactory
    {
        private static int s_AccountId = 0;

        public static Account CreateAccount(int i_BalanceInitial)//creating new account
        {
            s_AccountId++;
            Account newAccount = new Account(s_AccountId);
            newAccount.Deposit(i_BalanceInitial);
            return newAccount;
        }
    }
}
