using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TripWallet.Models.Intefaces;

namespace TripWallet.Models
{
    public interface Trip
    {
        Participant[] Participants { get; }
        Location[] Locations { get; }
        Location Destination { get; }
        Wallet Wallet { get; }
        bool isActive { get; }

        bool Register(Participant participant);
        bool Register(Location location);

        bool Remove(Participant participant);
        bool Remove(Id id);
        bool Remove(Location location);

        bool Change(Destination destination);
        bool RemoveDestination();

        void ShowParticipants();

    }
}
