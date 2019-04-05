using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripWallet.Models.Intefaces;

namespace TripWallet.Models
{
    public interface MoneyTransaction
    {
        Location Location{ get; }
        decimal Value { get; }
        Participant Payer { get; }
    }
}
