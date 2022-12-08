using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Map
{
    [DataContract]
    public class Parking
    {
        public Parking(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Задан неверный номер стоянки", nameof(number));
            }

            Number = number;
            Cameras = new List<Camera>();
        }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
       // public Dictionary<Camera, string> Cameras { get; set; }
        public List<Camera> Cameras { get; set; }

        public override string ToString()
        {
            return Number.ToString();
        }

    }
}
