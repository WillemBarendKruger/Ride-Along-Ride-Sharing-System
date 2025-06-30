using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Interfaces
{
    public interface IRideable
    {
        void RequestRide(string pickup, string dropoff);
        void AcceptRide(int rideId);
    }
}
