using Bankv2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2.Services
{
    class InterestService
    {
        public static void UpdateInterest(MockDatabase mockDatabase)
        {
            var work1 = from account in mockDatabase.accountList
                       select account;

            foreach (var item in work1)
            {
                if (item.accountLastUpdate.Day != 1)
                {
                    item.accountLastUpdate = item.accountLastUpdate.AddDays(1 - item.accountLastUpdate.Day);
                }


                while (item.accountLastUpdate.Year < DateTime.Today.Year)
                {
                    item.accountBalance *= 1.1m;

                    item.accountLastUpdate = item.accountLastUpdate.AddMonths(1);
                }


                while (item.accountLastUpdate.Month != DateTime.Today.Month)
                {
                    item.accountBalance *= 1.1m;

                    item.accountLastUpdate = item.accountLastUpdate.AddMonths(1);
                }
            }
        }
    }
}
