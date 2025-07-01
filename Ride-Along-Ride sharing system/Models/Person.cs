
namespace Ride_Along_Ride_sharing_system.Models
{
    public abstract class Person
    {
        int id;
        string name;
        string email;
        string password;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
    }
}
