using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Methods_Vallidators
{
    public class Menu_Methods
    {
        public static string Invalid_Inputs()
        {
            string Reply = Console.ReadLine();

            while (true)
            {
                if (Reply != "1" && Reply != "2" && Reply != "3")
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Try Again (Choose between 1,2,3): ");
                    Reply = Console.ReadLine();
                }
                else
                {
                    return Reply;
                }
            }
        }
    }
}
