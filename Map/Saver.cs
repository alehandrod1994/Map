using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Map
{
    public abstract class Saver
    {
        public static List<T> Load<T>() where T : class
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"data\\{typeof(T).Name}s.json";
            
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return fs.Length > 0 && jsonFormatter.ReadObject(fs) is List<T> items ? items : new List<T>();
            }
        }

        public static void Save<T>(List<T> item) where T : class
        {
            var formatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"data\\{typeof(T).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.WriteObject(fs, item);
            }
        }

    }
}
