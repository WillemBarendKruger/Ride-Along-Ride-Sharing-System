using Ride_Along_Ride_sharing_system.Data;
using Ride_Along_Ride_sharing_system.Models;

namespace Ride_Along_Ride_sharing_system.Services
{
    public class PassengerService
    {
        private Passenger _passenger;
        private List<Ride> _rides;
        private const string RideFile = "rides.json";

        public PassengerService(Passenger passenger)
        {
            _passenger = passenger;
            _rides = FileStorage.LoadFromFile<Ride>(RideFile);
        }

        public void ShowPassengerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {_passenger.Name} (Passenger Menu)\n-----------------\n" +
                $"1. Request a Ride\n" +
                $"2. View Wallet Balance\n" +
                $"3. Add Funds to Wallet\n" +
                $"4. View Ride History\n" +
                $"5. Logout");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": RequestRide(); break;
                    case "2": ViewWallet(); break;
                    case "3": AddFunds(); break;
                    case "4": ViewHistory(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid input. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }

          
        }

        private void RequestRide()
        {
            Console.Write("Pickup Location: ");
            string pickup = Console.ReadLine() ?? "";
            Console.Write("Drop-off Location: ");
            string dropoff = Console.ReadLine() ?? "";
            Console.Write("Distance (in km): ");

            if (decimal.TryParse(Console.ReadLine(), out decimal distance))
            {
                Ride newRide = new Ride
                {
                    RideId = _rides.Any() ? _rides.Max(ride => ride.RideId) + 1 : 1,
                    DriverName = null,
                    PassengerName = _passenger.Name,
                    PickupLocation = pickup,
                    DropoffLocation = dropoff,
                    Distance = distance
                };

                decimal cost = newRide.CalculateCost();
                _rides.Add(newRide);
                FileStorage.SaveToFile(_rides, RideFile);
                Console.WriteLine($"Ride requested successfully! Estimated Cost: R{cost}");
            }
            else
            {
                Console.WriteLine("Invalid distance input.");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private void ViewWallet()
        {
            Console.WriteLine($"Wallet Balance: R{_passenger.Wallet.Balance1}");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private void AddFunds()
        {
            Console.Write("Enter amount to add: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                _passenger.Wallet.AddMoney(amount);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private void ViewHistory()
        {
            var history = _rides.Where(ride => ride.PassengerName == _passenger.Name).ToList();
            if (!history.Any())
            {
                Console.WriteLine("No ride history.");
            }
            else
            {
                foreach (var ride in history)
                {
                    Console.WriteLine($"Ride ID: {ride.RideId}, From: {ride.PickupLocation} To: {ride.DropoffLocation}, Distance: {ride.Distance}km, Completed: {ride.IsComplete}, Driver: {ride.DriverName}");
                }
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}
