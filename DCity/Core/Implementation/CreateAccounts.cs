using DCity.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Implementation
{
    public class CreateAccounts
    {
        public readonly Account account = new Account();

        public CreateAccounts(string FirstName, string Lastname, string accountType, double balance, string email)
        {
            account.AccountName = FirstName + ", " + Lastname;
            account.AccountType = accountType;
            account.Balance = balance;
            account.Transactions = new List<AccountTransactions>();
            account.AccountNumber = accNumGenerator(6);
            account.Email = email;
        }

        public void AddTransaction(double amount, string description)
        {
            AccountTransactions transact = new AccountTransactions()
            {
                AccountNumber = account.AccountNumber,
                balance = account.Balance,
                OutAmount = amount,
                Description = description
            };
            if (transact != null)
            {
                account.Transactions.Add(transact);
            }
        }

        public static string accNumGenerator(int num)
        {
            Random random = new Random();

            string s = "";
            for (int i = 0; i < num; i++)
            {
                s = string.Concat(s, random.Next(6)).ToString();
            }
            return "4293" + s;
        }
    }
}
