using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Model
{
    public class AccountTransactions
    {
        public DateTime DateTime { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public double OutAmount { get; set; }

        public string Id { get; set; }

        public double balance { get; set; }

        public string AccountNumber { get; set; }


    }
}
