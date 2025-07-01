using Ride_Along_Ride_sharing_system.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class MainMenu
    {
        public void Load()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ride Sharing System\n--------------------------");
                Console.WriteLine("1. Register as Passenger");
                Console.WriteLine("2. Register as Driver");
                Console.WriteLine("3. Login");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": RegisterPassenger(); break;
                    case "2": RegisterDriver(); break;
                    case "3": LoginUser(); break;
                    case "4": return;
                    default:
                        Console.WriteLine("Invalid input. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void LoginUser()
        {
            Console.Clear();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var userService = new UserService();
            var passenger = userService.LoginPassenger(email, password);
            var driver = userService.LoginDriver(email, password);

            if (passenger != null)
            {
                Console.WriteLine("Logged in as Passenger");
                var passengerService = new PassengerService(passenger);
                passengerService.ShowPassengerMenu();
            }
            else if (driver != null)
            {
                Console.WriteLine("Logged in as Driver");
                var driverService = new DriverService(driver);
                driverService.ShowDriverMenu();
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
            }
        }

        public void RegisterPassenger()
        {
            Console.Clear();
            Console.WriteLine("Register as a Passenger\n-----------------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            Passenger passenger = new Passenger
            {
                Id = new Random().Next(1000, 9999),
                Name = name,
                Email = email,
                Password = password
            };

            UserService userService = new UserService();
            userService.RegisterPassenger(passenger);

            PassengerService passengerService = new PassengerService(passenger);
            passengerService.ShowPassengerMenu();
        }

        public void RegisterDriver()
        {
            Console.Clear();
            Console.WriteLine("Register as a Driver\n-----------------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var driver = new Driver
            {
                Id = new Random().Next(1000, 9999),
                Name = name,
                Email = email,
                Password = password,
                IsActive = true
            };

            UserService userService = new UserService();
            userService.RegisterDriver(driver);

            DriverService driverService = new DriverService(driver);
            driverService.ShowDriverMenu();
        }
    }

}
