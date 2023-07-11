using System;

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
        
        public override string ToString()
        {
            return $"Парковка: {Parking}, Камера: {Camera}, Рейтинг: {Rating}";
        }
    }
}
