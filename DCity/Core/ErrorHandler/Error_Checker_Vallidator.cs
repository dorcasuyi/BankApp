using DCity.Core.Colours;
using DCity.Core.Implementation;
using DCity.Core.Methods_Vallidators;
using DCity.Core.Model;
using DCity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.ErrorHandler
{
    public class Error_Checker_Vallidator
    {
        public static string Checkename(string input, string description)
        {
            while (true)
            {
                if (Regex_vallidator.CheckName(input))
                {
                    return input;
                }
                else
                {
                    DisplayColour.colourRed(description);
                    DisplayColour.colourRed("Try Again With Valid Format: ");
                    input = Console.ReadLine();
                }
            }
        }
        public static string Checkphonenumber(string input, string description)
        {
            while (true)
            {
                if (Regex_vallidator.CheckPoneNumber(input))
                {
                    return input;
                }
                else
                {
                    DisplayColour.colourRed(description);
                    DisplayColour.colourRed("Try Again With Valid Format: ");
                    input = Console.ReadLine();
                }
            }
        }
        public static string Checkemail(string input, string description)
        {
            while (true)
            {
                if (Regex_vallidator.CheckEmail(input))
                {
                    return input;
                }
                else
                {
                    DisplayColour.colourRed(description);
                    DisplayColour.colourRed("Try Again With Valid Format: ");
                    input = Console.ReadLine();
                }
            }
        }
        public static string Checkpassword(string input, string description)
        {
            while (true)
            {
                if (Regex_vallidator.CheckPassword(input))
                {
                    return input;
                }
                else
                {
                    DisplayColour.colourRed(description);
                    DisplayColour.colourRed("Try Again With Valid Format: ");
                    input = Console.ReadLine();
                }
            }
        }
        public static void Back(string type, string mail, string pass)
        {
            Console.WriteLine();
            Console.Write("press 0 to go back or 1 to Go to Main Menu: ");

            string back = Console.ReadLine();

            while (back != "0" && back != "1")
            {
                DisplayColour.colourRed("Invalid Input, Try Again: ");
                back = Console.ReadLine();
            }
            if (back == "0")
            {

            }
            else
            {
                Main_Menu.MainMenu();
            }
        }
        public static void Back2LoginMenu_DisplayMenu()
        {
            DisplayColour.colourRed("press 0 To go Back or 1 to Go To Main Menu");
            string answer = Console.ReadLine();
            while (answer != "0" && answer != "1")
            {
                DisplayColour.colourRed("Invalid Input Try Again");
                answer = Console.ReadLine();
            }
            if (answer == "0")
            {

            }
            else
            {
                Main_Menu.MainMenu();
            }
        }

        public static void Back2CreateMenu_DisplayMenu()
        {
            Console.Write("Press 0 to go back or 1 to go to Main Menu: ");
            string reply = Console.ReadLine();

            while (reply != "0" && reply != "1")
            {
                DisplayColour.colourRed("Inavlid input");
                Console.Write("TryAgain: ");
                reply = Console.ReadLine();
            }
            if (reply == "0")
            {
                Register_LoginMenu.Register();
            }
            else { Main_Menu.MainMenu(); }

        }

        public static string Amountchk(Customer accountUser)
        {
            string StartAmount = Console.ReadLine();
            int recieverAmount = 0;

            while (!int.TryParse(StartAmount, out recieverAmount))
            {
                DisplayColour.colourRed(" Amount Can Only Be Numbers.");
                StartAmount = Console.ReadLine();
            }
            while (recieverAmount < 1000)
            {
                DisplayColour.colourRed("An Error Occured, press 0 To Go back and Try Again");
                string reply = Console.ReadLine();
                {
                    while (reply != "0")
                    {
                        DisplayColour.colourRed("Inavlid Input, Press 0");
                        reply = Console.ReadLine();
                    }
                    if (reply == "1")
                    {
                        AccountUI.AccountUiDisply(accountUser);
                    }
                }
            }
            return StartAmount;
        }
        public static string Amountcheck(Customer accountUser)
        {
            string StartAmount = Console.ReadLine();
            int recieverAmount = 0;

            while (!int.TryParse(StartAmount, out recieverAmount))
            {
                DisplayColour.colourRed(" Amount Can Only Be Numbers.");
                StartAmount = Console.ReadLine();
            }
            while (recieverAmount < 0)
            {
                DisplayColour.colourRed("An Error Occured, press 0 To Go back and Try Again");
                string reply = Console.ReadLine();
                {
                    while (reply != "0")
                    {
                        DisplayColour.colourRed("Inavlid Input, Press 0");
                        reply = Console.ReadLine();
                    }
                    if (reply == "1")
                    {
                        AccountUI.AccountUiDisply(accountUser);
                    }
                }
            }
            return StartAmount;
        }
        public static string whitdrawCheck(List<CreateAccounts> _UserAccount, Customer accountUser, string WithdrawAcc)
        {
            string WithdrawAmount = Amountcheck(accountUser);


            foreach (var item in _UserAccount)
            {
                if (item.account.AccountNumber == WithdrawAcc)
                {
                    if (accountUser != null)
                    {
                        double AmountWithdrawn = Convert.ToDouble(WithdrawAmount);
                        double AccAmutType = item.account.AccountType == "SAVINGS" ? 1000 : 0;


                        if (AmountWithdrawn <= item.account.Balance - AccAmutType)
                        {
                            item.account.Balance -= AmountWithdrawn;
                            item.AddTransaction(AmountWithdrawn, $"{AmountWithdrawn} was Withdrawn by {accountUser.FirstName}");
                        }
                        else
                        {
                            DisplayColour.colourRed("Inavlid Transaction Savings Account Can not be Less than 1000 and Withdrawal Amount can not be Greater than Account Balance");
                            Console.Write("Press 0 to Go Back: ");
                            string reply = Console.ReadLine();
                            while (reply != "0")
                            {
                                Console.Write("Invalid Input , Press 0");
                            }
                            if (reply == "0")
                            {
                                AccountUI.AccountUiDisply(accountUser);
                            }
                        }
                    }
                }
            }
            return WithdrawAmount;
        }
        public static string RecieverNUm()
        {
            string recieverNum = Console.ReadLine();
            long recieverAmount = 0;

            while (!long.TryParse(recieverNum, out recieverAmount))
            {
                DisplayColour.colourRed(" Account Number Can Only Be Numbers.");
                recieverNum = Console.ReadLine();
            }
            while (recieverAmount < 0)
            {
                DisplayColour.colourRed("Account NUmber Can not be Negative");
                recieverNum = Console.ReadLine();
                recieverAmount = Convert.ToInt32(recieverNum);
            }
            return recieverNum;
        }
    }
}
