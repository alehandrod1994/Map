using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Map
{
    public class ParkingCamera
    {
        public ParkingCamera() { }

        public ParkingCamera(Parking parking, Camera camera, Rating ration)
        {
            if (parking == null)
            {
                throw new ArgumentNullException("Стоянка пуста.", nameof(parking));
            }

            if (camera == null)
            {
                throw new ArgumentNullException("Камера пуста.", nameof(camera));
            }

            Parking = parking;
            Camera = camera;
            Rating = ration;
        }

        public Parking Parking { get; set; }
        public Camera Camera { get; set; }
        public Rating Rating { get; set; }

        //public List<ParkingCamera> GetParkingCameras()
        //{
        //    var jsonFormatter = new DataContractJsonSerializer(typeof(ParkingCamera));
        //    var fileName = $"data\\{typeof(ParkingCamera).Name}s.json";

        //    using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        if (fs.Length > 0)
        //        {
        //            var items = (List<ParkingCamera>)jsonFormatter.ReadObject(fs);

        //            if (items != null)
        //            {
        //                return items;
        //            }
        //        }

        //        return new List<ParkingCamera>();
        //    }
        //}

        //public void Save(List<ParkingCamera> parkingCameras)
        //{
        //    var formatter = new DataContractJsonSerializer(typeof(ParkingCamera));
        //    var fileName = $"data\\{typeof(ParkingCamera).Name}s.json";

        //    using (var fs = new FileStream(fileName, FileMode.Create))
        //    {
        //        formatter.WriteObject(fs, parkingCameras);
        //    }
        //}

        public override string ToString()
        {
            return $"Парковка: {Parking}, Камера: {Camera}, Рейтинг: {Rating}";
        }
    }
}
