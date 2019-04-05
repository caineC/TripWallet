using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripWallet.Models.EventArgs;
using TripWallet.Models.Intefaces;

namespace TripWallet.Models.Implementations
{
    class UserImp : ParticipantImp, User
    {
        public Trip CreateTrip()
        {

            Location destination = new LocationImp()
            {
                Description = "qweqew",
                geoCoords = new [] {(decimal)2323.0,(decimal)232.1},
                Name = "Las Vegas"
            };

            Trip trip = new TripImp(destination);

            trip.Register(this);

            return trip;
        }

        public UserImp(Id id, string Name, decimal budget, decimal moneyspent = 0) : base(id, Name, budget, moneyspent)
        {
        }
    }
}
