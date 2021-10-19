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
        public List<int> clientId = new List<int>();
    }
}
