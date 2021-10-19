using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankv2
{
    class Program
    {

        //public static List<string> clientNames = new List<string>();
        //public static List<double> clientBalances = new List<double>();
        //public static List<Client> clientList = new List<Client>();
        public static string input;
        public static int loginIndex;
        //public static DateTime today = DateTime.Today;
        //public static string today = DateTime.Today.ToShortDateString();
        public static string today = DateTime.Today.ToString("dd/MM/yyyy");
        //ToDo List<client>, siwtch insted if, 
        //funkcjonalnosc historia tranzakcji, 
        //databaseMock.cs
        static void Main(string[] args)
        {
            MockDatabase mockDatabase = new MockDatabase();
            

            while (true)
            {
                Console.WriteLine(today);//////////////////////////////////////////////////////////////////

                Console.WriteLine("Please Login");
                bool loggedIn = false;
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
                                           where account.clientId.Contains(loginExists.clientId)
                                           select account.accountBalance).FirstOrDefault();

                        loginIndex = loginExists.clientId;

                        Console.WriteLine("Balance: {0}", loginBalance);
                        Console.WriteLine();
                        loggedIn = true;
                        loggingIn = false;
                    }
                    else
                    {
                        Console.WriteLine("No account with that name. Try again.");
                    }
                }

                while (loggedIn)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Transfer funds");
                    Console.WriteLine("2. Logout");
                    Console.WriteLine();
                    bool selectedNotExistingOperation = true;
                    input = Console.ReadLine();

                    if (input == "1" || input == "Transfer funds")
                    {
                        selectedNotExistingOperation = false;
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
                                                       where account.clientId.Contains(loginIndex)
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
                                                                                            where account.clientId.Contains(client.clientId)
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


                    if (input == "2" || input == "Logout")
                    {
                        selectedNotExistingOperation = false;
                        Console.WriteLine("Logged out");
                        Console.WriteLine();
                        loggedIn = false;
                    }


                    if (selectedNotExistingOperation)
                    {
                        Console.WriteLine("No such operation. Try again.");
                        Console.WriteLine();
                    }
                }
            }
            































            
        }


        public void UpdateInterest()
        {



        }


    }
}
