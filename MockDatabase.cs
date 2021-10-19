using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2
{
    class MockDatabase
    {
        public List<Client> clientList = new List<Client>();
        public List<Account> accountList = new List<Account>();
        public List<Transfer> transferList = new List<Transfer>();
        public List<ClientAccount> clientAccountList = new List<ClientAccount>();
        public List<AccountTransfer> accountTransferList = new List<AccountTransfer>();
        


        public MockDatabase()
        {
            Client client1 = new Client();
            client1.clientName = "Jan Kowalski";
            client1.clientId = 1;
            client1.accountId.Add(1);
            clientList.Add(client1);
            Account account1 = new Account();
            account1.accountBalance = 420.00m;
            account1.accountId = 1;
            account1.clientId.Add(1);
            accountList.Add(account1);
            ClientAccount clientaccount1 = new ClientAccount();
            clientaccount1.clientId = client1.clientId;
            clientaccount1.accountId = account1.accountId;
            clientAccountList.Add(clientaccount1);
            

            Client client2 = new Client();
            client2.clientName = "Anita Nowak";
            client2.clientId = 2;
            client2.accountId.Add(2);
            clientList.Add(client2);
            Account account2 = new Account();
            account2.accountBalance = 6969.6969m;
            account2.accountId = 2;
            account2.clientId.Add(2);
            accountList.Add(account2);
            ClientAccount clientaccount2 = new ClientAccount();
            clientaccount2.clientId = client2.clientId;
            clientaccount2.accountId = account2.accountId;
            clientAccountList.Add(clientaccount2);
            

            Client client3 = new Client();
            client3.clientName = "Szaba Daba";
            client3.clientId = 3;
            client3.accountId.Add(3);
            clientList.Add(client3);
            Account account3 = new Account();
            account3.accountBalance = 777.07m;
            account3.accountId = 3;
            account3.clientId.Add(3);
            accountList.Add(account3);
            ClientAccount clientaccount3 = new ClientAccount();
            clientaccount3.clientId = client3.clientId;
            clientaccount3.accountId = account3.accountId;
            clientAccountList.Add(clientaccount3);
            

            Client client4 = new Client();
            client4.clientName = "test";
            client4.clientId = 4;
            client4.accountId.Add(4);
            clientList.Add(client4);
            Account account4 = new Account();
            account4.accountBalance = 1m;
            account4.accountId = 4;
            account4.clientId.Add(4);
            accountList.Add(account4);
            ClientAccount clientaccount4 = new ClientAccount();
            clientaccount4.clientId = client4.clientId;
            clientaccount4.accountId = account4.accountId;
            clientAccountList.Add(clientaccount4);
            

        }
    }
}
