using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripWallet.Models.Implementations
{
    public class LocationImp : Location
    {
        public decimal[] geoCoords { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
