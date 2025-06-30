using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Models
{
    public abstract class Person
    {
        string name;
        string password;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
    }
}
