using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2
{
    class Account
    {
        public decimal accountBalance;
        public int accountId;
        public DateTime accountLastUpdate;
        public List<int> clientIdList = new List<int>();
        public List<Transfer> transferList = new List<Transfer>();
    }
}
