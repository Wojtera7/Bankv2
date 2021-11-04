using Bankv2.Database;
using Bankv2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2.Services
{
    class SigninService
    {
        internal static void Signin(MockDatabase mockDatabase, string clientName)
        {
            Client client = new Client();
            client.clientName = clientName;
            client.clientId = mockDatabase.clientIdIterator++;

            Account account = new Account();
            account.accountBalance = 0m;
            account.accountId = mockDatabase.accountIdIterator++;
            account.accountLastUpdate = DateTime.UtcNow;

            client.accountIdList.Add(account.accountId);
            account.clientIdList.Add(client.clientId);


            mockDatabase.clientList.Add(client);
            mockDatabase.accountList.Add(account);
        }
    }
}
