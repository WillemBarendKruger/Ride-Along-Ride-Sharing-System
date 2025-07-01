
namespace Ride_Along_Ride_sharing_system.Models
{
    public class Wallet
    {
        decimal Balance = 1000;

        public decimal Balance1 { get => Balance; set => Balance = value; }

        public void AddMoney(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Added R{amount} to your  wallet\nYou have R{Balance} available");
        }
    }
}
