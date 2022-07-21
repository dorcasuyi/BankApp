using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.ErrorHandler
{
    public class ErroCheckers
    {
        public static double AmountCheck(double amount)
        {
            while (true)
            {
                if (amount < 0)
                {
                    Console.WriteLine("Enter a Valid Amount: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    return amount;
                }
            }
        }
    }
}
