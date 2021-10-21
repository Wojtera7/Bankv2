using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankv2
{
    class Program
    {
        public static string input;
        public static int loginIndex;
        public static bool loggedIn;
        public static DateTime today = DateTime.Today;
        //public static string today = DateTime.Today.ToShortDateString();
        
        //public static string today = DateTime.Today.ToString("dd/MM/yyyy");
        //ToDo
        //funkcjonalnosc historia tranzakcji, 
        static void Main(string[] args)
        {
            MockDatabase mockDatabase = new MockDatabase();

            while (true)
            {
                UpdateInterest(mockDatabase);

                Login(mockDatabase);

                Run(mockDatabase);

            }
            
        }


        private static void Login(MockDatabase mockDatabase)
        {
            Console.WriteLine("Please Login");
            loggedIn = false;
            bool loggingIn = true;

            while (loggingIn)
            {
                input = Console.ReadLine();
                /*
                var loginExists = from work1 in mockDatabase.clientList
                                  where work1.clientName == input
                                  select work1.clientId;
                */
                var loginExists = (from work1 in mockDatabase.clientList
                                   where work1.clientName == input
                                   select work1).FirstOrDefault();

                //if (loginExists.FirstOrDefault() != 0)
                if (loginExists.clientId != 0)
                {
                    Console.WriteLine("Account: {0}", loginExists.clientName);

                    var loginBalance = (from account in mockDatabase.accountList
                                        where account.clientIdList.Contains(loginExists.clientId)
                                        select account.accountBalance).FirstOrDefault();

                    loginIndex = loginExists.clientId;

                    Console.WriteLine("Balance: {0:F}", loginBalance);
                    Console.WriteLine();
                    loggedIn = true;
                    loggingIn = false;
                }
                else
                {
                    Console.WriteLine("No account with that name. Try again.");
                }
            }
        }

        private static void Run(MockDatabase mockDatabase)
        {
            while (loggedIn)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Options:");
                Console.WriteLine("1. Transfer funds");
                Console.WriteLine("2. View transfer history");
                Console.WriteLine("3. Logout");
                Console.WriteLine();
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                    case "Transfer funds":
                    case "Transfer":

                        TransferFunds(mockDatabase);
                        break;


                    case "2":
                    case "View transfer history":
                    case "View":
                    case "history":

                        ViewTransferHistory();
                        break;


                    case "3":
                    case "Logout":

                        Logout();
                        break;


                    default:

                        Console.WriteLine("No such operation. Try again.");
                        Console.WriteLine();
                        break;
                }

                

            }
        }


        private static void TransferFunds(MockDatabase mockDatabase)
        {
            Console.WriteLine("To whom?");
            bool transfering = true;

            while (transfering)
            {
                string input1 = Console.ReadLine();

                var clientExists = from work1 in mockDatabase.clientList
                                   where work1.clientName == input1
                                   select work1.clientName;

                if (clientExists.FirstOrDefault() != string.Empty || clientExists.FirstOrDefault() != null)
                {
                    Console.WriteLine("How much?");

                    while (transfering)
                    {
                        string input2 = Console.ReadLine();

                        var amountExists = from account in mockDatabase.accountList
                                           where account.clientIdList.Contains(loginIndex)
                                           select account.accountBalance;

                        if (decimal.Parse(input2) > amountExists.FirstOrDefault())
                        {
                            Console.WriteLine("Not enough available funds. Try again.");
                            Console.WriteLine("Your balance is {0}", amountExists.FirstOrDefault());
                        }
                        else
                        {
                            int sourceIndex = mockDatabase.accountList.IndexOf((from account in mockDatabase.accountList
                                                                                where account.accountBalance == amountExists.FirstOrDefault()
                                                                                select account).FirstOrDefault());//== loginIndex

                            mockDatabase.accountList[sourceIndex].accountBalance -= decimal.Parse(input2);

                            int targetIndex = mockDatabase.accountList.IndexOf((from account in mockDatabase.accountList
                                                                                from client in mockDatabase.clientList
                                                                                where client.clientName == clientExists.FirstOrDefault()
                                                                                where account.clientIdList.Contains(client.clientId)
                                                                                select account).FirstOrDefault());

                            mockDatabase.accountList[targetIndex].accountBalance += decimal.Parse(input2);
                            Console.WriteLine("Operation completed.");
                            Console.WriteLine();
                            transfering = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No account with that name. Try again.");
                }

            }
        }


        private static void Logout()
        {
            Console.WriteLine("Logged out");
            Console.WriteLine();
            loggedIn = false;
        }

        private static void ViewTransferHistory()
        {
            


        }


        private static void UpdateInterest(MockDatabase mockDatabase)
        {
            var sthf = from account in mockDatabase.accountList
                       select account;

            foreach (var item in sthf)
            {
                if (item.accountLastUpdate.Day != 1)
                {
                    item.accountLastUpdate = item.accountLastUpdate.AddDays(1 - item.accountLastUpdate.Day);
                }


                while (item.accountLastUpdate.Year < today.Year)
                {
                    item.accountBalance *= 1.1m;

                    item.accountLastUpdate = item.accountLastUpdate.AddMonths(1);
                }


                while (item.accountLastUpdate.Month != today.Month)
                {
                    item.accountBalance *= 1.1m;

                    item.accountLastUpdate = item.accountLastUpdate.AddMonths(1);
                }
            }
        }
    }
}
