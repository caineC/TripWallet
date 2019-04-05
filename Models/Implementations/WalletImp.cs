using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TripWallet.Models.Intefaces;

namespace TripWallet.Models.Implementations
{
    public class WalletImp : Wallet
    {
        public Trip Trip { get; private set; }


        public Stack<MoneyTransaction> MoneyTransactions { get; private set; }

        public WalletImp(Trip trip)
        {
            this.Trip = trip;
            MoneyTransactions = new Stack<MoneyTransaction>();
        }

        public bool Register(MoneyTransaction transaction)
        {
            try
            {
                MoneyTransactions.Push(transaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public decimal TotalMoneySpent
        {
            get { return CalculateTotalMoneySpent(); }
        }

        private decimal CalculateTotalMoneySpent()
        {
            decimal result = 0;
            foreach (var moneySpent in MoneyTransactions)
            {
                result += moneySpent.Value;
            }

            return result;
        }

        private decimal? _tripBudget;
        public decimal TripBudget
        {
            get
            {
                if (_tripBudget.HasValue) return _tripBudget.Value;
                _tripBudget = CalculateTripBudget();

                return _tripBudget.Value;
            }
        }

        private decimal CalculateTripBudget()
        {
            decimal result = 0;
            foreach (var participant in Trip.Participants)
                result += participant.Budget;

            return result;
        }
    }
}
