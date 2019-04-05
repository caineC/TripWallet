using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripWallet.Models.EventArgs
{
    public class ParticipantPaidEventInfo : System.EventArgs
    {
        public decimal Value { get; set; }
        public Location CurrentLocation { get; set; }

        public ParticipantPaidEventInfo(decimal value, Location currentLocation)
        {
            Value = value;
            CurrentLocation = currentLocation;
        }
    }
}
