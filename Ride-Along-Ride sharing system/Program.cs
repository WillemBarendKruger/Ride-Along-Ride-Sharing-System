using Ride_Along_Ride_sharing_system.Models;

namespace Ride_Along_Ride_sharing_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ride Along\n----------------------");
            MainMenu menu = new MainMenu();
            menu.Load();
        }
    }
}