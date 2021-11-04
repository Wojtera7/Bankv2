using Bankv2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankv2.Entities
{
    class Client
    {
        public string clientName;
        public int clientId;
        public List<int> accountIdList = new List<int>();
    }
}
