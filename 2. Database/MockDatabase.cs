using Bankv2.Entities;
using Bankv2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2.Database
{
    class MockDatabase : IDatabase
    {
        public List<Client> clientList = new List<Client>();
        public List<Account> accountList = new List<Account>();
        public List<TransferService> transferServiceList = new List<TransferService>();
        public List<Transfer> transferList = new List<Transfer>();

        public int clientIdIterator = 5;
        public int accountIdIterator = 5;


        public MockDatabase()
        {
            Client client1 = new Client();
            client1.clientName = "Jan Kowalski";
            client1.clientId = 1;
            client1.accountIdList.Add(1);
            clientList.Add(client1);
            Account account1 = new Account();
            account1.accountBalance = 420.00m;
            account1.accountId = 1;
            account1.accountLastUpdate = DateTime.Today;
            account1.clientIdList.Add(1);
            accountList.Add(account1);


            Client client2 = new Client();
            client2.clientName = "Anita Nowak";
            client2.clientId = 2;
            client2.accountIdList.Add(2);
            clientList.Add(client2);
            Account account2 = new Account();
            account2.accountBalance = 6969.6969m;
            account2.accountId = 2;
            account2.accountLastUpdate = DateTime.Parse("01.09.2021");
            account2.clientIdList.Add(2);
            accountList.Add(account2);


            Client client3 = new Client();
            client3.clientName = "Szaba Daba";
            client3.clientId = 3;
            client3.accountIdList.Add(3);
            clientList.Add(client3);
            Account account3 = new Account();
            account3.accountBalance = 777.07m;
            account3.accountId = 3;
            account3.accountLastUpdate = DateTime.Parse("21.08.2021");
            account3.clientIdList.Add(3);
            accountList.Add(account3);


            Client client4 = new Client();
            client4.clientName = "test";
            client4.clientId = 4;
            client4.accountIdList.Add(4);
            clientList.Add(client4);
            Account account4 = new Account();
            account4.accountBalance = 1m;
            account4.accountId = 4;
            account4.accountLastUpdate = DateTime.Today;
            account4.clientIdList.Add(4);
            accountList.Add(account4);


            Transfer transfer1 = new Transfer(transferList.Count, 1, 2, 12, DateTime.Parse("10.10.2010 10:10:10"));
            transferList.Add(transfer1);
            accountList[0].transferList.Add(transfer1);
            accountList[1].transferList.Add(transfer1);

            Transfer transfer2 = new Transfer(transferList.Count, 2, 1, 21, DateTime.Parse("11.11.2011 11:11:11"));
            transferList.Add(transfer2);
            accountList[1].transferList.Add(transfer2);
            accountList[0].transferList.Add(transfer2);

            Transfer transfer3 = new Transfer(transferList.Count, 1, 3, 13, DateTime.Parse("13.03.2013 13:13:13"));
            transferList.Add(transfer3);
            accountList[0].transferList.Add(transfer3);
            accountList[2].transferList.Add(transfer3);

            Transfer transfer4 = new Transfer(transferList.Count, 3, 2, 32, DateTime.Parse("01.01.2001 08:08:08"));
            transferList.Add(transfer4);
            accountList[2].transferList.Add(transfer4);
            accountList[1].transferList.Add(transfer4);

            Transfer transfer5 = new Transfer(transferList.Count, 3, 4, 34, DateTime.Parse("02.02.2002 09:09:09"));
            transferList.Add(transfer5);
            accountList[2].transferList.Add(transfer5);
            accountList[3].transferList.Add(transfer5);

            Transfer transfer6 = new Transfer(transferList.Count, 4, 1, 41, DateTime.Parse("14.04.2014 14:14:14"));
            transferList.Add(transfer6);
            accountList[3].transferList.Add(transfer6);
            accountList[0].transferList.Add(transfer6);

            Transfer transfer7 = new Transfer(transferList.Count, 4, 2, 42, DateTime.Parse("24.04.2014 15:15:15"));
            transferList.Add(transfer7);
            accountList[3].transferList.Add(transfer7);
            accountList[1].transferList.Add(transfer7);

            Transfer transfer8 = new Transfer(transferList.Count, 4, 3, 43, DateTime.Parse("04.04.2014 16:16:16"));
            transferList.Add(transfer8);
            accountList[3].transferList.Add(transfer8);
            accountList[2].transferList.Add(transfer8);
        }
    }
}
