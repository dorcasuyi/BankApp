using DCity.Core.Implementation;
using DCity.Core.Model;
using DCity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Methods_Vallidators
{
    public class GoBack_Main_Login
    {
        public static void UiBack(Customer user)
        {
            Console.WriteLine("press 0 to go Back and 1 to go to the main Menu");
            string CustomerReply = Console.ReadLine();
            while (CustomerReply != "0" && CustomerReply != "1")
            {
                Console.WriteLine("Invalid Input, Try Again ");
                CustomerReply = Console.ReadLine();
            }
            if (CustomerReply == "0")
            {
                AccountUI.AccountUiDisply(user);
            }
            else
            {
                Main_Menu.MainMenu();
            }
        }
    }
}
