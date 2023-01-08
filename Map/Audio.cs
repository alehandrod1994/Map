using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    [DataContract]
    public class Audio
    {
        [DataMember]
        private SoundPlayer _sp;

        [DataMember]
        private readonly string _start = @"audio\start.wav";

        public Audio()
        {    
            SoundLocation = _start;
            Enabled = true;
            _sp = new SoundPlayer(_start);
        }

        public Audio(string soundLocation)
        {
            SoundLocation = soundLocation;
            Enabled = true;
            _sp = new SoundPlayer(soundLocation);
        }

        [DataMember]
        public bool Enabled { get; set; }

        [DataMember]
        public string SoundLocation { get; set; }

        public void Play()
        {
            _sp.Play();
        }

        public void Stop()
        {
            _sp.Stop();
        }

        public Audio GetAudio()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Audio));
            var fileName = $"data\\{typeof(Audio).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var item = (Audio)jsonFormatter.ReadObject(fs);

                    if (item != null)
                    {
                        return item;
                    }
                }

                return new Audio();
            }
        }

        public void Save()
        {
            var formatter = new DataContractJsonSerializer(typeof(Audio));
            var fileName = $"data\\{typeof(Audio).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.WriteObject(fs, this);
            }
        }
    }
}
