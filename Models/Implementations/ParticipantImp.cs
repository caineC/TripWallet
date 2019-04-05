using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripWallet.Models.EventArgs;

namespace TripWallet.Models
{
    class ParticipantImp : Participant
    {
        public Id Id { get; private set; }
        public string Name { get; private set; }
        public decimal MoneySpent { get; private set; }
        public decimal Budget { get; private set; }
        public Trip[] TripHistory { get; set; }
        public Location CurrentLocation { get; private set; }

        public ParticipantImp(Id id, string Name, decimal budget, decimal moneyspent = 0)
        {
            Id = id;
            MoneySpent = moneyspent;
            Budget = budget;
            this.Name = Name;
        }

        public void Pay(decimal value)
        {
            MoneySpent += value;

            ParticipantPaid(sender: this, e: new ParticipantPaidEventInfo(value, CurrentLocation));
        }

        public event EventHandler<ParticipantPaidEventInfo> ParticipantPaid = delegate { };
    }
}
