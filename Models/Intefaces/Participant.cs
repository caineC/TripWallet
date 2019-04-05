using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripWallet.Models.EventArgs;

namespace TripWallet.Models
{
    public interface Participant
    {
        Id Id { get; }
        string Name { get; }
        decimal MoneySpent { get; }
        decimal Budget { get; }
        Trip[] TripHistory { get; }
        Location CurrentLocation { get; }

        void Pay(decimal value);
        event EventHandler<ParticipantPaidEventInfo> ParticipantPaid;
    }
}
