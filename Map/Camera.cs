using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Map
{
    [DataContract]
    public class Camera
    {
        public Camera()
        {
            //Parkings = new Dictionary<Parking, Rating>();
            //ParkingCamera = new HashSet<ParkingCamera>();
        }

        public Camera(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Номер камеры не может быть меньше 1.", nameof(number));
            }

            Number = number;
            //Parkings = new Dictionary<Parking, Rating>();
            //ParkingCamera = new HashSet<ParkingCamera>();
        }

        [DataMember]
        public int Number { get; set; }

        //[DataMember]
        //public Dictionary<Parking, Rating> Parkings { get; set; }
        //public ICollection<ParkingCamera> ParkingCamera { get; set; }

        public List<Camera> GetCameras()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Camera>));
            var fileName = $"data\\{typeof(Camera).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var items = (List<Camera>)jsonFormatter.ReadObject(fs);

                    if (items != null)
                    {
                        return items;
                    }
                }

                return new List<Camera>();
            }
        }

        public void Save(List<Camera> cameras)
        {
            var formatter = new DataContractJsonSerializer(typeof(List<Camera>));
            var fileName = $"data\\{typeof(Camera).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.WriteObject(fs, cameras);
            }
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            return Number == ((Camera)obj).Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

    }
}
