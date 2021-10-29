using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2
{
    class Transfer
    {
        public int transferId;
        public int fromWhomId;
        public int toWhomId;
        public decimal transferAmount;
        public DateTime transferDate;

        public Transfer(int transferId, int fromWhomId, int toWhomId, decimal transferAmount, DateTime transferDate)
        {
            this.transferId = transferId;
            this.fromWhomId = fromWhomId;
            this.toWhomId = toWhomId;
            this.transferAmount = transferAmount;
            this.transferDate = transferDate;
        }

        /*
        public Transfer(MockDatabase mockDatabase, int fromWhomId, int toWhomId, decimal transferAmount, DateTime transferDate)
        {
            this.transferId = mockDatabase.transferList.Count;
            this.fromWhomId = fromWhomId;
            this.toWhomId = toWhomId;
            this.transferAmount = transferAmount;
            this.transferDate = transferDate;
        }
        */

    }
}
