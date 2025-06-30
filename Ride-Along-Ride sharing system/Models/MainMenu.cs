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
            Console.Clear();
            Console.WriteLine("Ride sharing System\n-------------------\n" +
                "1. Register as Passenger \n" +
                "2. Register as Driver \n" +
                "3. Login \n" +
                "4. Exit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1": RegisterPassenger(); 
                    break;
                case "2": RegisterDriver();
                    break;
                case "3": LoginUser();
                    break;
                case "4": return;
                default:
                    Console.WriteLine("Invalid input. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

        public void LoginUser()
        {
            Console.Clear();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            UserService userService = new UserService();
            var passenger = userService.LoginPassenger(email, password);
            var driver = userService.LoginDriver(email, password);

            if(passenger != null)
            {
                Console.WriteLine("Logged in as Passenger");
                var passengerService = new UserService();
                //passengerService.ShowPassengerMenu();

            }
            else if(driver != null)
            {
                Console.WriteLine("Logged in as Driver");
                var driverService = new DriverService(driver);
                driverService.ShowDriverMenu();
            }
            else
            {
                Console.WriteLine("Invalid email or password \nPress any key to return");
            }
        }
    }
}
