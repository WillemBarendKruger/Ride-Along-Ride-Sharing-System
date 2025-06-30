using Ride_Along_Ride_sharing_system.Data;
using Ride_Along_Ride_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Services
{
    public class DriverService
    {
        private Driver _driver;
        private List<Ride> _rides;
        private const string RideFile = "rides.json";

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
                Console.WriteLine($"Welcome {_driver.Name}\n--------------\n" +
                    $"1. View available ride request\n" +
                    $"2. Cancel a Ride\n" +
                    $"3. Complete a ride\n" +
                    $"4. View Earnings\n" +
                    $"5. Logout");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": ViewAvailableRides(); 
                        break;
                    case "2": CancelRide(); 
                        break;
                    case "4": CompleteRide(); 
                        break;
                }
            }
        }

        public void ViewAvailableRides()
        {
            var available = _rides.Where(ride => !ride.IsComplete).ToList();

            if(!available.Any())
            {
                Console.WriteLine("No avaible rides");
            }
            else
            {
                foreach(var ride in available)
                {
                    Console.WriteLine($"Ride: {ride.RideId}, From: {ride.PickupLocation} To: {ride.DropoffLocation}, Distance: {ride.Distance} Km");
                }
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public void CancelRide()
        {
            Console.Write("Enter ride ID to Cancel: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                var ride = _rides.FirstOrDefault(ride => ride.RideId == id && ride.DriverName == _driver.Name);
                if(ride != null && !ride.IsComplete)
                {
                    ride.DriverName = _driver.Name;
                    FileStorage.SaveToFile(_rides, RideFile);
                    Console.WriteLine("Ride Canceled.");
                }
                else
                {
                    Console.WriteLine("Ride already complete or doesn't exist");
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public void CompleteRide()
        {
            Console.Write("Enter ride ID to complete: ");
            if(int.TryParse(Console.ReadLine(),out int id))
            {
                var ride = _rides.FirstOrDefault(ride => ride.RideId == id && ride.DriverName == _driver.Name);
                if(ride != null)
                {
                    ride.IsComplete = true;
                    decimal fare = ride.CalculateCost();
                    _driver.ProccessPayment(fare);
                    FileStorage.SaveToFile(_rides, RideFile);
                    Console.WriteLine("Ride completed and payment calculated");
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
            Console.WriteLine($"Total earnings: {_driver.Earnings} \nPress any key to return...");
            Console.ReadKey();
        }

        public static void RegisterDriver()
        {
            Console.Clear();
            Console.WriteLine("Register as a Driver\n-----------------------");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Driver driver = new Driver();
            {
                Name = name ?? "";
                Email = email ?? "";
                Password = password ?? "";
                IsActive = true;
            };

            var userService = new UserService();
            userService.RegisterDriver(driver);

            var driverService = new DriverService();
            driverService.ShowDriverMenu();
        }
    }
}
