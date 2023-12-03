using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Flashback
    {
        private Audio _audio;
        public Flashback()
        {
            _audio = new Audio(@"audio\flashback.wav");
        }

        public string Range { get; set; }

    }
}
