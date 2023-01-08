using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Map
{
    [DataContract]
    public class Parking
    {
        public Parking()
        {
            //Cameras = new Dictionary<Camera, Rating>();
            //ParkingCamera = new HashSet<ParkingCamera>();
        }

        public Parking(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Номер стоянки не может быть меньше 1.", nameof(number));
            }

            Number = number;
            //Cameras = new Dictionary<Camera, Rating>();
            //ParkingCamera = new HashSet<ParkingCamera>();
        }

        [DataMember]
        public string Number { get; set; }

        //[DataMember]
        //public Dictionary<Camera, Rating> Cameras { get; set; }
        //public ICollection<ParkingCamera> ParkingCamera { get; set; }

        public List<Parking> GetParkings()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Parking>));
            var fileName = $"data\\{typeof(Parking).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var items = (List<Parking>)jsonFormatter.ReadObject(fs);

                    if (items != null)
                    {
                        return items;
                    }
                }

                return new List<Parking>();
            }
        }

        public void Save(List<Parking> parkings)
        {
            var formatter = new DataContractJsonSerializer(typeof(List<Parking>));
            var fileName = $"data\\{typeof(Parking).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.WriteObject(fs, parkings);
            }
        }

        public override string ToString()
        {
            return Number.ToString();
        }    
    }
}
