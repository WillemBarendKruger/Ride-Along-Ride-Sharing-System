using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class Rating
    {
            public string DriverName { get; set; }
            public string PassengerName { get; set; }
            public int Score { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.Now;

    }
}
