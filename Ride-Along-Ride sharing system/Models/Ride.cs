using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class Ride
    {
        string driverName;
        string passengerName;
        string pickupLocation;
        string dropoffLocation;
        bool isComplete = false;
        decimal distance;
        decimal CalculateCost() => distance * 5.0m;
    }
}
