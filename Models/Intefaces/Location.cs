using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripWallet.Models
{
    public interface Location
    {
        decimal[] geoCoords { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
