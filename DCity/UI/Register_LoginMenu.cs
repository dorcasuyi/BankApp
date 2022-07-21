using DCity.Core.Colours;
using DCity.Core.ErrorHandler;
using DCity.Core.Implementation;
using DCity.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.UI
{
    public class Register_LoginMenu
    {
        static readonly List<Customer> User = new();
        public static void Register()
        {
            Console.Clear();
            DisplayColour.BankColou("WELCOME TO DCITY BANK");
            DisplayColour.BankYellow("THE BANK FOR YOU");
            Console.WriteLine();
            Console.WriteLine("Input First Name: ");
            string firstName = Console.ReadLine();
            Error_Checker_Vallidator.Checkename(firstName, "Name should begin with a capital letter");

            Console.WriteLine("Input Last Name: ");
            string lastName = Console.ReadLine();
            Error_Checker_Vallidator.Checkename(lastName, "Name should begin with a capital letter");

            Console.WriteLine("Input Email Address: ");
            string email = Console.ReadLine();
            Error_Checker_Vallidator.Checkemail(email, "Invalid Email Format");

            Console.WriteLine("Input Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Error_Checker_Vallidator.Checkphonenumber(phoneNumber, "Invalid phone number format");

            Console.WriteLine("Input Password");
            string passWord = Console.ReadLine();
            Error_Checker_Vallidator.Checkpassword(passWord, "Password should be a mixture of numbers,alphabets and special characters");

            Customer customer = new Customer();
            {
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.Email = email;
                customer.PhoneNumber = phoneNumber;
                customer.PassWord = passWord;
            };
            User.Add(customer);
            Console.WriteLine("Customer has been Registerd Successfully");

            Console.WriteLine("press 1 to go back");
            string reply = Console.ReadLine();

            while (reply != "1")
            {
                Console.WriteLine("Invalid Input");
                reply = Console.ReadLine();
            }

            if (reply == "1")
            {
                Main_Menu.MainMenu();
            }
        }
        public static void Login()
        {
            Console.Clear();
            DisplayColour.BankColou("WELCOME TO DCITY BANK");
            DisplayColour.BankYellow("THE BANK FOR YOU");
            Console.WriteLine();

            Console.WriteLine("Input Email Address: ");
            string email = Console.ReadLine();
            Error_Checker_Vallidator.Checkemail(email, "Invalid Email Format");

            Console.WriteLine("Input Password");
            string passWord = Console.ReadLine();
            Error_Checker_Vallidator.Checkpassword(passWord, "Password should be a mixture of numbers,alphabets and special characters");

            Customer LoginUser = LoginCheck(User, email, passWord);

            if (LoginUser != null)
            {
                Console.Clear();
                DisplayColour.BankColou("Welcome To DCity Bank");
                AccountUI.AccountUiDisply(LoginUser);
            }
            else
            {
                DisplayColour.colourRed("No customer Exist With Such Detail.");
                DisplayColour.colourRed("press 1 To go back and Try Again With Different Login Details or register a customer.");
                string reply = Console.ReadLine();
                while(reply != "1")
                {
                    Console.Write("Inavlid Input, Try Again: ");
                    reply= Console.ReadLine();
                }
                if(reply == "1")
                {
                    Main_Menu.MainMenu();
                }
            }
        }

        public static Customer LoginCheck(List<Customer> user, string email, string passWord)
        {
            foreach (var customer in user)
            {
                if (customer.Email == email && customer.PassWord == passWord)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
