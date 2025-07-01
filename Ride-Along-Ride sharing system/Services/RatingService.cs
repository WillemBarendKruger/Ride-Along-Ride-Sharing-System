using Ride_Along_Ride_sharing_system.Data;
using Ride_Along_Ride_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Services
{
    public class RatingService
    {
            private const string RatingFile = "ratings.json";
            private List<Rating> ratings;

            public RatingService()
            {
                ratings = FileStorage.LoadFromFile<Rating>(RatingFile);
            }

            public void SubmitRating(string driverName, string passengerName)
            {
                Console.Write("Enter rating (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out int score) || score < 1 || score > 5)
                {
                    Console.WriteLine("Invalid score.");
                    return;
                }

                Console.Write("Leave a comment (optional): ");
                string comment = Console.ReadLine() ?? "";

                Rating rating = new Rating
                {
                    DriverName = driverName,
                    PassengerName = passengerName,
                    Score = score,
                    Comment = comment
                };

                ratings.Add(rating);
                FileStorage.SaveToFile(ratings, RatingFile);

                Console.WriteLine("Rating submitted.");
            }

            public double GetAverageRating(string driverName)
            {
                var driverRatings = ratings.Where(r => r.DriverName == driverName).ToList();
                if (!driverRatings.Any()) return 0.0;
                return driverRatings.Average(r => r.Score);
            }

            public List<Rating> GetRatingsForDriver(string driverName) =>
                ratings.Where(r => r.DriverName == driverName).ToList();

            public List<Rating> GetLowRatedDrivers(double threshold = 2.5) =>
                ratings.GroupBy(r => r.DriverName)
                       .Where(g => g.Average(r => r.Score) < threshold)
                       .SelectMany(g => g)
                       .ToList();

    }
}
