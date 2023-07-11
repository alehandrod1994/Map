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
        public Parking() { }

        public Parking(string number)
            {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Номер стоянки не может быть меньше 1.", nameof(number));
            }

            Number = number;
        }

        [DataMember]
        public string Number { get; set; }
     
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
