using Bankv2.Database;
using Bankv2.Entities;
using Bankv2.Main;
using System;
using System.Linq;

namespace Bankv2.Services
{
    class LoginService
    {
        internal static LoggedInUser Login(MockDatabase mockDatabase, string login)
        {
            var loginClient = (from work1 in mockDatabase.clientList
                               where work1.clientName == login
                               select work1).FirstOrDefault();


            var loginBalance = (from account in mockDatabase.accountList
                                where account.clientIdList.Contains(loginClient.clientId)
                                select account.accountBalance).FirstOrDefault();


            LoggedInUser loggedInUser = new LoggedInUser
            {
                loginId = loginClient.clientId,
                loginName = loginClient.clientName,
                loginBalance = loginBalance,
                isLoggedIn = true
            };

            return loggedInUser;
        }


        public static void Logout(LoggedInUser loggedInUser)
        {
            loggedInUser.isLoggedIn = false;
        }
    }
}
