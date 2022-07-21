using DCity.Core.Colours;
using DCity.Methods_Vallidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.UI
{
    public class Main_Menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            DisplayColour.BankColou("WELCOME TO DCITY BANK");
            DisplayColour.BankYellow("THE BANK FOR YOU");
            Console.WriteLine();

            Console.WriteLine("Choose From The Options Below");
            Console.WriteLine();
            Console.WriteLine("1: Register Customer");
            Console.WriteLine("2: Sign In/Setup");
            Console.WriteLine("3: Exit");

            string Reply = Menu_Methods.Invalid_Inputs();

            if (Reply == "1")
            {
                Register_LoginMenu.Register();
            }
            else if (Reply == "2")
            {
                Register_LoginMenu.Login();
                
            }
            else
            {
                Environment.Exit(0);
            }

        }
    }
}
