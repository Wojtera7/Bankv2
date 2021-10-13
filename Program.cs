using System;
using System.Collections.Generic;

namespace Bankv2
{
    class Program
    {

        public static List<string> clientNames = new List<string>();
        public static List<double> clientBalances = new List<double>();
        public static string input;
        public static int loginIndex;
        public static DateTime today = DateTime.Today;

        static void Main(string[] args)
        {
            Client client1 = new Client();
            client1.name = "Jan Kowalski";
            client1.balance = 420.00;
            clientNames.Add(client1.name);
            clientBalances.Add(client1.balance);
            Client client2 = new Client();
            client2.name = "Anita Nowak";
            client2.balance = 6969.6969;
            clientNames.Add(client2.name);
            clientBalances.Add(client2.balance);
            Client client3 = new Client();
            client3.name = "Szaba Daba";
            client3.balance = 777.07;
            clientNames.Add(client3.name);
            clientBalances.Add(client3.balance);
            Client client4 = new Client();
            client4.name = "test";
            client4.balance = 1.00;
            clientNames.Add(client4.name);
            clientBalances.Add(client4.balance);


            while (true)
            {
                Console.WriteLine(today);
                Console.WriteLine("Please Login");
                bool loggedIn = false;
                bool loggingIn = true;

                while (loggingIn)
                {
                    input = Console.ReadLine();

                    if (clientNames.Contains(input))
                    {
                        loginIndex = clientNames.IndexOf(input);
                        Console.WriteLine("Account: {0}", clientNames[loginIndex]);
                        Console.WriteLine("Balance: {0}", clientBalances[loginIndex]);
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
                    bool selectedNotExistingOperation = true;

                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Transfer funds");
                    Console.WriteLine("2. Logout");
                    Console.WriteLine();
                    input = Console.ReadLine();

                    if (input == "1" || input == "Transfer funds")
                    {
                        selectedNotExistingOperation = false;
                        Console.WriteLine("To whom?");
                        bool transfering = true;

                        while (transfering)
                        {
                            string input1 = Console.ReadLine();

                            if (clientNames.Contains(input1))
                            {
                                Console.WriteLine("How much?");

                                while (transfering)
                                {
                                    string input2 = Console.ReadLine();

                                    if (double.Parse(input2) > clientBalances[loginIndex])
                                    {
                                        Console.WriteLine("Not enough available funds. Try again.");
                                        Console.WriteLine("Your balance is {0}", clientBalances[loginIndex]);
                                    }
                                    else
                                    {
                                        clientBalances[loginIndex] = clientBalances[loginIndex] - double.Parse(input2);
                                        int targetIndex = clientNames.IndexOf(input1);
                                        clientBalances[targetIndex] = clientBalances[targetIndex] + double.Parse(input2);

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
