using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ride_Along_Ride_sharing_system.Data
{
    public class FileStorage
    {
        public static void SaveToFile<T>(List<T> data, string filename)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public static List<T> LoadFromFile<T>(string filename) 
        {
            if (!File.Exists(filename)) return new List<T>();

            var json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}
