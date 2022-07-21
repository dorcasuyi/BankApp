using DCity.Core.Colours;
using DCity.Core.Implementation;
using DCity.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Methods_Vallidators
{
    public class Account_numbers
    {
        public static string Accountnumbers(List<CreateAccounts> _UserAccount, Customer accountUser)
        {
            Console.Clear();
            DisplayColour.BankColou("DCity BANK");

            Console.WriteLine($"Accounts Linked To {accountUser.FirstName}, {accountUser.LastName}");
            int i = 1;

            foreach (var s in _UserAccount)
            {
                if (s.account.Email == accountUser.Email)
                {
                    Console.WriteLine($"{i}: Account Number: {s.account.AccountNumber}\t Type Of Account: {s.account.AccountType}");
                    i++;
                }
            }
            Console.WriteLine("Select an Account");
            string Reply = Console.ReadLine();
            int counts;

            while (!int.TryParse(Reply, out counts))
            {
                Console.WriteLine("Inavlid Reply, Try Again with a Valid Reply");
                Reply = Console.ReadLine();
            }
            foreach (var item in _UserAccount)
            {
                accountUser.Id = counts - 1;
            }
            return _UserAccount[accountUser.Id].account.AccountNumber;
        }
    }
}
