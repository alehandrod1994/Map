using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public abstract class Saver
    {
        public static List<T> Load<T>() where T : class
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"data\\{typeof(T).Name}s.json";
            
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var items = (List<T>)jsonFormatter.ReadObject(fs);

                    if (items != null)
                    {
                        return items;
                    }
                }

                return new List<T>();
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
