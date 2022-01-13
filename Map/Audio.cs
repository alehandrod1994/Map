using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    [DataContract]
    public class Audio 
    {
        [DataMember]
        private SoundPlayer sp;

        public Audio(string soundLocation)
        {
            SoundLocation = soundLocation;
            Enabled = true;
            sp = new SoundPlayer(soundLocation);
        }

        [DataMember]
        public bool Enabled { get; set; }

        [DataMember]
        public string SoundLocation { get; set; }

        public void Play()
        {
            sp.Play();
        }

        public void Stop()
        {
            sp.Stop();
        }

    }
}
