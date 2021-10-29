using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankv2
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
                Transfer transfer = new Transfer(mockDatabase.transferList.Count, mockDatabase.accountList[sourceIndex].accountId, mockDatabase.accountList[targetIndex].accountId, howMuch, DateTime.UtcNow);
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













        public static void MakeTransfer(MockDatabase mockDatabase)
        {
            Console.WriteLine("To whom?");
            bool transfering = true;

            while (transfering)
            {
                string input1 = Console.ReadLine();

                var clientExists = from work1 in mockDatabase.clientList
                                   where work1.clientName == input1
                                   select work1.clientName;

                if (clientExists.FirstOrDefault() != string.Empty || clientExists.FirstOrDefault() != null)
                {
                    Console.WriteLine("How much?");

                    while (transfering)
                    {
                        string input2 = Console.ReadLine();

                        var amountExists = from account in mockDatabase.accountList
                                           where account.clientIdList.Contains(Program.loginId)
                                           select account.accountBalance;

                        if (decimal.Parse(input2) > amountExists.FirstOrDefault())
                        {
                            Console.WriteLine("Not enough available funds. Try again.");
                            Console.WriteLine("Your balance is {0}", amountExists.FirstOrDefault());
                        }
                        else
                        {
                            int sourceIndex = mockDatabase.accountList.IndexOf((from account in mockDatabase.accountList
                                                                                where account.accountBalance == amountExists.FirstOrDefault()
                                                                                select account).FirstOrDefault());//== loginIndex

                            mockDatabase.accountList[sourceIndex].accountBalance -= decimal.Parse(input2);

                            int targetIndex = mockDatabase.accountList.IndexOf((from account in mockDatabase.accountList
                                                                                from client in mockDatabase.clientList
                                                                                where client.clientName == clientExists.FirstOrDefault()
                                                                                where account.clientIdList.Contains(client.clientId)
                                                                                select account).FirstOrDefault());

                            mockDatabase.accountList[targetIndex].accountBalance += decimal.Parse(input2);
                            Console.WriteLine("Operation completed.");
                            Console.WriteLine();
                            transfering = false;
                            /*
                            TransferService transfer = new TransferService
                            {
                                transferAmount = decimal.Parse(input2),
                                transferDate = DateTime.Today,
                                transferId = mockDatabase.accountList[sourceIndex].transferList.Count
                            };
                            mockDatabase.accountList[sourceIndex].transferList.Add(transfer);
                            */
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No account with that name. Try again.");
                }

            }
        }









    }
}
