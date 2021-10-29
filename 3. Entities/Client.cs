using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2
{
    class Client
    {
        public string clientName;
        public int clientId;
        public List<int> accountIdList = new List<int>();

        public Client() { }
        public Client(MockDatabase mockDatabase, string clientName)
        {
            this.clientName = clientName;
            this.clientId = mockDatabase.clientIdIterator++;
            accountIdList.Add(clientId);

            Account account = new Account(mockDatabase, clientId);
            /*
            Account account = new Account
            {
                accountBalance = 0m,
                accountId = mockDatabase.accountList.Count,
                accountLastUpdate = DateTime.UtcNow,
            };
            account.clientIdList.Add(this.clientId);
            */

            mockDatabase.clientList.Add(this);
            mockDatabase.accountList.Add(account);
        }

    }
}
