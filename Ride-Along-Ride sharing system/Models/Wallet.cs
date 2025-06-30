using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Models
{
    public class Wallet
    {
        decimal Balance = 1000;

        public decimal Balance1 { get => Balance; set => Balance = value; }

        public void AddMoney(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Added {amount} to your  wallet\nYou have {Balance} available");
        }
    }
}
