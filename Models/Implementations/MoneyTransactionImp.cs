using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripWallet.Models.Implementations
{
    class MoneyTransactionImp : MoneyTransaction
    {
        public Location Location { get; set; }
        public decimal Value { get; set; }
        public Participant Payer { get; set; }
    }
}
