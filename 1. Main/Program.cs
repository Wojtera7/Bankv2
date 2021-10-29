using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankv2
{
    class Program
    {
        public static int loginId;
        public static bool loggedIn;
        public static string loginName;
        public static decimal loginBalance;

        //public static DateTime today = DateTime.Today;
        //public static string today = DateTime.Today.ToShortDateString();
        //public static string today = DateTime.Today.ToString("dd/MM/yyyy");
        //ToDo

        static void Main(string[] args)
        {
            MockDatabase mockDatabase = new MockDatabase();

            InterestService.UpdateInterest(mockDatabase);
            //InterestService.UpdateInterest(mockDatabase, DateTime.Today);

            while (true)
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

                        LoginService.Login(mockDatabase, login);
                        /*
                        var a = LoginService.Login(mockDatabase, login);
                        a[0] = loginId
                        a[1] = loginName;
                        a[2] = loginBalance;
                        */
                        break;


                    default:

                        break;
                }

                Run(mockDatabase);
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

                switch (Console.ReadLine())
                {
                    case "1":
                    case "Transfer funds":
                    case "Transfer":

                        Console.WriteLine("To whom?");
                        string toWhom = Console.ReadLine();
                        Console.WriteLine("How much?");
                        decimal howMuch = decimal.Parse(Console.ReadLine());

                        TransferService.Transfer(mockDatabase, loginId, toWhom, howMuch);

                        Console.WriteLine("Operation completed.");
                        Console.WriteLine();
                        break;


                    case "2":
                    case "View transfer history":
                    case "View":
                    case "history":

                        TransferService.TransferHistory(mockDatabase, loginId);

                        Console.WriteLine("Operation completed.");
                        Console.WriteLine();
                        break;


                    case "3":
                    case "Logout":

                        LoginService.Logout();

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
