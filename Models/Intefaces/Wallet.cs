using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripWallet.Models.Intefaces
{
    public interface Wallet
    {
        Trip Trip { get; }
        decimal TripBudget { get; }
        decimal TotalMoneySpent { get; }
        Stack<MoneyTransaction> MoneyTransactions { get; }

        bool Register(MoneyTransaction transaction);
    }
}
