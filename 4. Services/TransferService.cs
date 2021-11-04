using Bankv2.Database;
using Bankv2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankv2.Services
{
    class TransferService
    {
        public static void Transfer(MockDatabase mockDatabase, int fromWhomId, string toWhomId, decimal howMuch)
        {
            try
            {
                int sourceIndex = mockDatabase.accountList.IndexOf((from account in mockDatabase.accountList
                                                                    where account.accountId == fromWhomId
                                                                    //where account.clientIdList.Contains(Program.loginIndex)
                                                                    select account).FirstOrDefault());

                mockDatabase.accountList[sourceIndex].accountBalance -= howMuch;

                int targetIndex = mockDatabase.accountList.IndexOf((from account in mockDatabase.accountList
                                                                    from client in mockDatabase.clientList
                                                                    where client.clientName == toWhomId
                                                                    where account.clientIdList.Contains(client.clientId)
                                                                    select account).FirstOrDefault());

                mockDatabase.accountList[targetIndex].accountBalance += howMuch;



                /*
                Transfer transfer = new Transfer
                {
                    transferId = mockDatabase.transferList.Count,
                    transferAmount = howMuch,
                    transferDate = DateTime.Today,
                };
                */
                Transfer transfer = new Transfer(mockDatabase.transferList.Count, 
                                                mockDatabase.accountList[sourceIndex].accountId, 
                                                mockDatabase.accountList[targetIndex].accountId, 
                                                howMuch, 
                                                DateTime.UtcNow);
                //Transfer transfer = new Transfer(mockDatabase, mockDatabase.accountList[sourceIndex].accountId, mockDatabase.accountList[targetIndex].accountId, howMuch, DateTime.UtcNow);
                mockDatabase.transferList.Add(transfer);
                mockDatabase.accountList[sourceIndex].transferList.Add(transfer);
                mockDatabase.accountList[targetIndex].transferList.Add(transfer);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            if (true)
            {
                throw new ArgumentException("Invalid login");
            }
            */

        }


        public static void TransferHistory(MockDatabase mockDatabase, int whoseId)
        {
            try
            {
                var transferList = (from account in mockDatabase.accountList
                                    where account.accountId == whoseId
                                    select account.transferList).FirstOrDefault();


                /*
                foreach (var item in transferList)
                {
                    WriteTransfer(mockDatabase, item);
                }
                */
                WriteTransfers(mockDatabase, transferList, whoseId);

                /*
                public static List<Transfer> TransferHistory(MockDatabase mockDatabase, int whoseId)




                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /*
        private static void WriteTransfers(MockDatabase mockDatabase, Transfer item)
        {
            Console.WriteLine("Transfer ID " + item.transferId);
            Console.WriteLine("" + item.transferDate);
            Console.WriteLine("From " + item.fromWhomId);
            Console.WriteLine("To " + item.toWhomId);
            Console.WriteLine("Amount " + item.transferAmount);
            Console.WriteLine();
        }
        */

        private static void WriteTransfers(MockDatabase mockDatabase, List<Transfer> transferList, int whoseId)
        {
            foreach (var item in transferList)
            {
                if (item.fromWhomId == whoseId)
                {
                    Console.WriteLine("Outgoing");
                }
                else
                {
                    Console.WriteLine("Incoming");
                }

                Console.WriteLine("Transfer ID " + item.transferId);
                Console.WriteLine("" + item.transferDate);
                Console.WriteLine("From " + item.fromWhomId);
                Console.WriteLine("To " + item.toWhomId);
                Console.WriteLine("Amount " + item.transferAmount);
                Console.WriteLine();
            }
        }






        public static void TransferHistory2(MockDatabase mockDatabase, int whoseId)
        {
            foreach (var item in TransferHistoryData(mockDatabase, whoseId))
            {
                if (item.fromWhomId == whoseId)
                {
                    Console.WriteLine("Outgoing");
                }
                else
                {
                    Console.WriteLine("Incoming");
                }

                Console.WriteLine("Transfer ID " + item.transferId);
                Console.WriteLine("" + item.transferDate);
                Console.WriteLine("From " + item.fromWhomId);
                Console.WriteLine("To " + item.toWhomId);
                Console.WriteLine("Amount " + item.transferAmount);
                Console.WriteLine();
            }
        }


        internal static List<Transfer> TransferHistoryData(MockDatabase mockDatabase, int whoseId)
        {
            var transferList = (from account in mockDatabase.accountList
                                where account.accountId == whoseId
                                select account.transferList).FirstOrDefault();


            return transferList;
        }




















    }
}
