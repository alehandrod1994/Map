using System;
using System.Runtime.Serialization;

namespace Map
{
    [DataContract]
    public class Camera
    {
        public Camera() { }

        public Camera(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Номер камеры не может быть меньше 1.", nameof(number));
            }

            Number = number;
        }

        [DataMember]
        public int Number { get; set; } 

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Camera camera)
            {
                return Number == camera.Number;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

    }
}
