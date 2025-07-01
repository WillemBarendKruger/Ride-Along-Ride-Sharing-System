
namespace Ride_Along_Ride_sharing_system.Interfaces
{
    public interface IRideable
    {
        void RequestRide(string pickup, string dropoff);
        void AcceptRide(int rideId);
    }
}
