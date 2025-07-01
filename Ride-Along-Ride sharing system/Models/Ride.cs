
namespace Ride_Along_Ride_sharing_system.Models
{
    public class Ride
    {
        Passenger passenger = new Passenger();
        int rideId;
        string driverName;
        string passengerName;
        string pickupLocation;
        string dropoffLocation;
        bool isComplete = false;
        decimal distance;


        public int RideId { get => rideId; set => rideId = value; }
        public string DriverName { get => driverName; set => driverName = value; }
        public string PassengerName { get => passengerName; set => passengerName = value; }
        public string PickupLocation { get => pickupLocation; set => pickupLocation = value; }
        public string DropoffLocation { get => dropoffLocation; set => dropoffLocation = value; }
        public bool IsComplete { get => isComplete; set => isComplete = value; }
        public decimal Distance { get => distance; set => distance = value; }

        public decimal CalculateCost()
        {
            decimal cost = Distance * 5.0m;
            if (cost > passenger.Wallet.Balance1)
            {
                Console.WriteLine("Insufficient funds. Please add more money to your wallet or try again.");
                throw new InvalidOperationException("Insufficient funds.");
            }
            else
            {
                return cost;
            }
        }
    }
}
