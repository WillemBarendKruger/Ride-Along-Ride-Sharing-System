using Ride_Along_Ride_sharing_system.Data;
using Ride_Along_Ride_sharing_system.Models;

namespace Ride_Along_Ride_sharing_system.Services
{
    public class DriverService
    {
        private Driver _driver;
        private List<Ride> _rides;
        private const string RideFile = "rides.json";
        private const string PassangerFile = "passenger.json";

        public DriverService(Driver driver)
        {
            _driver = driver;
            _rides = FileStorage.LoadFromFile<Ride>(RideFile);
        }

        public void ShowDriverMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {_driver.Name} (Driver menu)\n--------------\n" +
                    $"1. View available ride request\n" +
                    $"2. Switch active status \n" +
                    $"3. Complete a ride\n" +
                    $"4. View Earnings\n" +
                    $"5. Logout");
                 
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": ViewAvailableRides(); 
                        break;
                    case "2": SwitchState(); 
                        break;
                    case "3": CompleteRide(); 
                        break;
                    case "4": ViewEarnings();
                        break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid input detected, \nPress any button to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ViewAvailableRides()
        {
            var available = _rides.Where(ride => ride.RideId >= 0 && !ride.IsComplete).ToList();

            if (_driver.IsActive)
            {
                if (!available.Any())
                {
                    Console.WriteLine("No avaible rides");
                }
                else
                {
                    foreach (var ride in available)
                    {
                        Console.WriteLine($"Ride: {ride.RideId}, From: {ride.PickupLocation} To: {ride.DropoffLocation}, Distance: {ride.Distance} Km");
                    }
                }
            }
            else
            {
                Console.WriteLine("Make your self active to view rides");
            }

                Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public void SwitchState()
        {
            Console.WriteLine($"Confirm switch status to: {!_driver.IsActive} \n1. Yes \n2. No");
            if (int.TryParse(Console.ReadLine(), out int response))
            {
                if (response == 1)
                {
                    _driver.IsActive = !_driver.IsActive;
                    Console.WriteLine("Status switched.");
                }
                else if (response == 2)
                {
                    Console.WriteLine("No changes made.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public void CompleteRide()
        {
            Console.Write("Enter ride ID to complete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var ride = _rides.FirstOrDefault(ride => ride.RideId == id);
                if (ride != null)
                {
                    if (ride.IsComplete)
                    {
                        Console.WriteLine("Ride already completed");
                    }
                    else
                    {
                        ride.IsComplete = true;
                        ride.DriverName = _driver.Name;
                        decimal fare = ride.CalculateCost();
                        _driver.ProccessPayment(fare);
                        FileStorage.SaveToFile(_rides, RideFile);

                        var passengers = FileStorage.LoadFromFile<Passenger>(PassangerFile);
                        Passenger passenger = passengers?.FirstOrDefault(person => person.Name == ride.PassengerName);
                        if (passenger != null)
                        {
                            passenger.ProccessPayment(fare);
                            FileStorage.SaveToFile(passengers, PassangerFile);
                        }
                        Console.WriteLine($"Ride completed and payment calculated \n{_driver.Name} you earned: R{fare} \nYour Total is: R{_driver.Earnings}");
                    }
                        
                }
                else
                {
                    Console.WriteLine("Ride not found or already completed");
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public void ViewEarnings()
        {
            Console.WriteLine($"Total earnings: R{_driver.Earnings} \nPress any key to return...");
            Console.ReadKey();
        }

    }
}
