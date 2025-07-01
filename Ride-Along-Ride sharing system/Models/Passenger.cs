using Ride_Along_Ride_sharing_system.Interfaces;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class Passenger : Person, IPayable, IRideable
    {
        private Wallet wallet = new Wallet();

        public Wallet Wallet { get => wallet; set => wallet = value; }

        public void RequestRide(string pickup, string dropoff)
        {
            Console.WriteLine($"{Name} is requesting a ride from {pickup} to {dropoff}");
        }

        public void AcceptRide(int rideId)
        {
            throw new NotImplementedException("You can't accept a ride");
        }

        public void ProccessPayment(decimal amount)
        {
            if (wallet.Balance1 >= amount)
            {
                wallet.Balance1 -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficent money available");
            }
        }
    }
}
