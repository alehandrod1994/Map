using System.Media;
using System.Runtime.Serialization;

namespace Map
{
    [DataContract]
    public class Audio
    {
        [DataMember]
        private readonly SoundPlayer _sp;

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
            try
            {
                _sp.Play();
            }
            catch { }
        }

        public void Stop()
        {
            _sp.Stop();
        }      
    }
}
