using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Map
{
    [DataContract]
    public class Camera
    {
        public Camera(int number, Rating rating)
        {
            if (number < 1)
            {
                throw new ArgumentException("Задан неверный номер камеры", nameof(number));
            }

            Number = number;
            //Parkings = new Dictionary<Parking, string>();
            Rating = rating;
        }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
        //public Dictionary<Parking, string> Parkings { get; set; }
        public Rating Rating { get; set; }

        public override string ToString()
        {
            return Number.ToString();
        }

    }
}
