using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Model
{
    public class Account
    {
        public string AccountName { get; set; }

        public double Balance { get; set; }
        public string Email { get; set; }

        public string AccountNumber { get; set; }

        public string AccountType { get; set; }

        public List<AccountTransactions> Transactions { get; set; }
    }
}
