using DCity.Core.Colours;
using DCity.Core.ErrorHandler;
using DCity.Core.Methods_Vallidators;
using DCity.Core.Model;
using DCity.Core.Table_Prints;
using DCity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Implementation
{

    public class AccountUI
    {
        public static readonly List<CreateAccounts> _UserAccount = new();


        public static void AccountUiDisply(Customer accountUser)
        {
            Console.Clear();
            DisplayColour.BankColou("WELCOME TO DCITY BANK");
            DisplayColour.BankYellow("THE BANK FOR YOU");
            Console.WriteLine();
            Console.WriteLine("1. Set up account");
            Console.WriteLine("2: Check balance");
            Console.WriteLine("3: Deposit");
            Console.WriteLine("4: Withdraw");
            Console.WriteLine("5: Transfer");
            Console.WriteLine("6: Account Details");
            Console.WriteLine("7: Account Statement");
            Console.WriteLine("8: LogOut");
            Console.WriteLine();

            Console.Write("Put In a Valid Reply: ");
            string reply = Console.ReadLine();

            while (reply != "1" && reply != "2" && reply != "3" && reply != "4" && reply != "5" && reply != "6" && reply != "7" && reply != "8")
            {
                Console.WriteLine("Invalid Input");
                reply = Console.ReadLine();
            }


            if (reply == "1")
            {
                Console.Clear();
                DisplayColour.BankColou("WELCOME TO DCITY BANK");
                DisplayColour.BankYellow("THE BANK FOR YOU");
                Console.WriteLine();
                Console.WriteLine("Press 1: To Setup a SAVINGS Account\nPress 2: To Setup a CURRENT Acccount");
                string SetupAcc = Console.ReadLine();
                string AccountType;

                while (SetupAcc != "1" && SetupAcc != "2")
                {
                    Console.WriteLine("Inavlid Input, Try Again With A valid Input");
                    SetupAcc = Console.ReadLine();
                }
                if (SetupAcc == "1")
                {
                    AccountType = "SAVINGS";
                } 
                else
                {
                    AccountType = "CURRENT";
                }

                Console.Clear();
                Console.WriteLine("How Much Would you like Start Your Account With(Can not be less than 1000)");

                string amount1 = Error_Checker_Vallidator.Amountchk(accountUser);

                double saveAmount = Convert.ToDouble(amount1);



                var Customer_Account = new CreateAccounts(accountUser.FirstName, accountUser.LastName, AccountType, saveAmount, accountUser.Email);
                _UserAccount.Add(Customer_Account);
                Console.WriteLine($"Bank Account Added!\n Your Account Number is: {Customer_Account.account.AccountNumber}");

                GoBack_Main_Login.UiBack(accountUser);
            }
            else if (reply == "2")
            {
                string CheckAcc = Account_numbers.Accountnumbers(_UserAccount, accountUser);

                var table = new PrintTable("Account Name", "Acccount Numb", "Account Type", "Account Balance");
                foreach (var s in _UserAccount)
                {
                    if (s.account.AccountNumber == CheckAcc)
                    {
                        table.AddRow(s.account.AccountName, s.account.AccountNumber, s.account.AccountType, s.account.Balance.ToString());
                        table.prints();
                    }
                }
                GoBack_Main_Login.UiBack(accountUser);
            }
            else if (reply == "3")
            {
                Console.Clear();
                DisplayColour.BankColou("DCity BANK");
                DisplayColour.BankYellow("THE BANK FOR YOU");
                Console.WriteLine();

                string DepositAcc = Account_numbers.Accountnumbers(_UserAccount, accountUser);

                Console.WriteLine("How much would you like to deposit to");

                string depositAmount = Error_Checker_Vallidator.Amountcheck(accountUser);
                double deposit;
                while (!double.TryParse(depositAmount, out deposit))
                {
                    Console.WriteLine("Inavlid Transaction. Amount must be positive number.");
                    depositAmount = Console.ReadLine();
                }
                double AmountDeposited = ErroCheckers.AmountCheck(deposit);

                foreach (var item in _UserAccount)
                {
                    if (item.account.AccountNumber == DepositAcc)
                    {
                        if (accountUser != null)
                        {
                            item.account.Balance += AmountDeposited;
                            Console.WriteLine($"Successfully Deposited {AmountDeposited} into {DepositAcc}");
                            item.AddTransaction(AmountDeposited, $"{AmountDeposited} was Deposited by {accountUser.FirstName}");
                        }                      
                    }
                }
                GoBack_Main_Login.UiBack(accountUser);
            }
            else if (reply == "4")
            {
                Console.Clear();
                DisplayColour.BankColou("DCity BANK");
                DisplayColour.BankYellow("THE BANK FOR YOU");
                Console.WriteLine();
                string WithdrawAcc = Account_numbers.Accountnumbers(_UserAccount, accountUser);

                Console.WriteLine("How much would you like to Withdraw");
                Error_Checker_Vallidator.whitdrawCheck(_UserAccount, accountUser, WithdrawAcc);
                Console.WriteLine($"Successfully Withdrew from {WithdrawAcc}");

                GoBack_Main_Login.UiBack(accountUser);
            }
            else if (reply == "5")
            {
                Console.Clear();
                DisplayColour.BankColou("DCity BANK");
                DisplayColour.BankYellow("THE BANK FOR YOU");
                Console.WriteLine();
                string SenderAcc = Account_numbers.Accountnumbers(_UserAccount, accountUser);

                Console.WriteLine("How much would you like to Transfer");

                string TransferAmount = Error_Checker_Vallidator.whitdrawCheck(_UserAccount, accountUser, SenderAcc);
                double Amounttransfered = Convert.ToDouble(TransferAmount);


                Console.WriteLine("Enter Receivers Account Number: ");
                string RecieverNumber = Error_Checker_Vallidator.RecieverNUm();
                long Reciever = Convert.ToInt64(RecieverNumber);

                foreach (var item in _UserAccount)
                {
                    if (item.account.AccountNumber == RecieverNumber)
                    {
                        if (accountUser != null)
                        {
                            item.account.Balance += Amounttransfered;
                            item.AddTransaction(Amounttransfered, $"Recieved {Amounttransfered} from {SenderAcc}");
                        }
                    }
                }
                Console.WriteLine($"Successfully Transfered {TransferAmount} from {SenderAcc} to {RecieverNumber}");
                GoBack_Main_Login.UiBack(accountUser);
            }
            else if (reply == "6")
            {
                Console.Clear();
                DisplayColour.BankColou("DCity BANK");
                DisplayColour.BankYellow("THE BANK FOR YOU");
                Console.WriteLine();
                var Table = new PrintTable("Account Number", "Account Name", "Account Type", "Account Balance");
                Console.WriteLine($"ACCOUNT DETAILS FOR {accountUser.FirstName}, {accountUser.LastName}, Contact number : {accountUser.PhoneNumber}");

                foreach (var item in _UserAccount)
                {
                    if (accountUser.Email == item.account.Email)
                    {
                        Table.AddRow(item.account.AccountNumber, item.account.AccountName, item.account.AccountType, item.account.Balance.ToString());
                    }

                }
                Table.prints();
                GoBack_Main_Login.UiBack(accountUser);
            }
            else if (reply == "7")
            {
                Console.Clear();
                DisplayColour.BankColou("DCity BANK");
                DisplayColour.BankYellow("THE BANK FOR YOU");
                Console.WriteLine();

                string AccountStatement = Account_numbers.Accountnumbers(_UserAccount, accountUser);

                Console.WriteLine($"ACCOUNT STATEMENT FOR {_UserAccount[accountUser.Id].account.AccountNumber}");

                foreach (var item in _UserAccount)
                {
                    if (item.account.AccountNumber == AccountStatement)
                    {
                        var TablePrint = new PrintTable("Date", "Description", "Amount", "Balance");
                        var TransactionStament = item.account.Transactions;
                        foreach (var t in TransactionStament)
                        {
                            if (t.AccountNumber == AccountStatement)
                            {
                                TablePrint.AddRow(t.DateTime.ToString(), t.Description, t.OutAmount.ToString(), t.balance.ToString());
                            }
                        }
                        TablePrint.prints();
                    }
                }
                GoBack_Main_Login.UiBack(accountUser);
            }
            else
            {
                Main_Menu.MainMenu();
            }
        }
    }
}
