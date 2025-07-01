using Ride_Along_Ride_sharing_system.Data;
using Ride_Along_Ride_sharing_system.Models;

namespace Ride_Along_Ride_sharing_system.Services
{
    public class UserService
    {
        private List<Passenger> passengers;
        private List<Driver> drivers;
        private const string PassangerFile = "passenger.json";
        private const string DriverFile = "driver.json";

        public UserService()
        {
            passengers = FileStorage.LoadFromFile<Passenger>(PassangerFile);
            drivers = FileStorage.LoadFromFile<Driver>(DriverFile);
        }

        public void RegisterDriver(Driver driver)
        {
            driver.Id = drivers.Count + 1;
            drivers.Add(driver);
            FileStorage.SaveToFile(drivers, DriverFile);
        }

        public void RegisterPassenger(Passenger passenger)
        {
            passenger.Id = drivers.Count + 1;
            passengers.Add(passenger);
            FileStorage.SaveToFile(passengers, PassangerFile);
        }

        public Passenger? LoginPassenger(string email, string password)
        {
            return passengers.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

        public Driver? LoginDriver(string email, string password)
        {
            return drivers.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

        public List<Driver> GetAvailableDrivers() => drivers.Where(driver => driver.IsActive).ToList();

        public void UpdateDrivers() => FileStorage.SaveToFile(drivers, DriverFile);
    }
}
