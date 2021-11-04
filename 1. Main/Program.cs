using Bankv2.Database;
using Bankv2.Entities;
using Bankv2.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankv2.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            MockDatabase mockDatabase = new MockDatabase();
            //IDatabase database = new MockDatabase();
            //IDatabase database = new RealDatabase();

            InterestService.UpdateInterest(mockDatabase);

            LoggedInUser loggedInUser = new LoggedInUser();

            Run1(mockDatabase, loggedInUser);
        }


        private static void Run1(MockDatabase mockDatabase, LoggedInUser loggedInUser)
        {
            while (true)
            {
                SignIn(mockDatabase, loggedInUser);

                Run2(mockDatabase, loggedInUser);
            }
        }


        private static void SignIn(MockDatabase mockDatabase, LoggedInUser loggedInUser)
        {
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Log In");

            switch (Console.ReadLine())
            {
                case "1":

                    Console.WriteLine("Client Name");
                    string clientName = Console.ReadLine();

                    SigninService.Signin(mockDatabase, clientName);
                    break;


                case "2":

                    Console.WriteLine("Please Login");
                    string login = Console.ReadLine();

                    loggedInUser = LoginService.Login(mockDatabase, login);

                    break;


                default:

                    break;
            }
        }


        private static void Run2(MockDatabase mockDatabase, LoggedInUser loggedInUser)
        {
            while (loggedInUser.isLoggedIn)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Options:");
                Console.WriteLine("1. Transfer funds");
                Console.WriteLine("2. View transfer history");
                Console.WriteLine("3. Logout");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                    case "Transfer funds":
                    case "Transfer":

                        Console.WriteLine("To whom?");
                        string toWhom = Console.ReadLine();
                        Console.WriteLine("How much?");
                        decimal howMuch = decimal.Parse(Console.ReadLine());

                        TransferService.Transfer(mockDatabase, loggedInUser.loginId, toWhom, howMuch);

                        Console.WriteLine("Operation completed.");
                        Console.WriteLine();
                        break;


                    case "2":
                    case "View transfer history":
                    case "View":
                    case "history":

                        TransferService.TransferHistory(mockDatabase, loggedInUser.loginId);

                        Console.WriteLine("Operation completed.");
                        Console.WriteLine();
                        break;


                    case "3":
                    case "Logout":

                        LoginService.Logout(loggedInUser);

                        Console.WriteLine("Logged out");
                        Console.WriteLine();
                        break;


                    default:

                        Console.WriteLine("No such operation. Try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
