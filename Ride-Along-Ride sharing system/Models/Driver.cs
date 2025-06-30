using Ride_Along_Ride_sharing_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class Driver : Person, IPayable, IRideable
    {
        string earnings;
        string rating;
        bool isActive;

        public string Earnings { get => earnings; set => earnings = value; }
        public string Rating { get => rating; set => rating = value; }
        public bool IsActive { get => isActive; set => isActive = value; }


        public void RequestRide(string pickup, string dropoff)
        {
            throw new NotImplementedException("Can't request a ride");
        }

        public void AcceptRide(int rideId)
        {
            Console.WriteLine($"{Name} accepted the ride, ID: {rideId}");
        }

        public void ProccessPayment(decimal amount) {
            earnings += amount;
            Console.WriteLine($"{Name} earned {amount}.\nTotale earned: {earnings}");
        }
    }
}
