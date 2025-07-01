using Ride_Along_Ride_sharing_system.Interfaces;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class Driver : Person, IPayable, IRideable
    {
        decimal earnings = 0;
        int rating;
        bool isActive;

        public decimal Earnings { get => earnings; set => earnings = value; }
        public int Rating { get => rating; set => rating = value; }
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
        }
    }
}
