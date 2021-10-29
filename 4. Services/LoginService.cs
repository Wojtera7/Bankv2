using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2
{
    class LoginService
    {
        public static void Login(MockDatabase mockDatabase, string login)
        {
            try
            {
                var loginName = (from work1 in mockDatabase.clientList
                                 where work1.clientName == login
                                 select work1).FirstOrDefault();


                var loginBalance = (from account in mockDatabase.accountList
                                    where account.clientIdList.Contains(loginName.clientId)
                                    select account.accountBalance).FirstOrDefault();


                Program.loginId = loginName.clientId;
                Program.loginName = loginName.clientName;
                Program.loginBalance = loginBalance;
                Program.loggedIn = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void Logout()
        {
            Program.loggedIn = false;
        }









        public static void MakeLogin(MockDatabase mockDatabase)
        {
            Console.WriteLine("Please Login");
            Program.loggedIn = false;
            bool loggingIn = true;

            while (loggingIn)
            {
                string input = Console.ReadLine();
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

                    Program.loginId = loginExists.clientId;

                    Console.WriteLine("Balance: {0:F}", loginBalance);
                    Console.WriteLine();
                    Program.loggedIn = true;
                    loggingIn = false;
                }
                else
                {
                    Console.WriteLine("No account with that name. Try again.");
                }
            }
        }


        public static void MakeLogout()
        {
            Console.WriteLine("Logged out");
            Console.WriteLine();
            Program.loggedIn = false;
        }
    }
}
