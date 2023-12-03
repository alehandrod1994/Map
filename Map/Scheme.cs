using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Scheme
    {
        public Scheme() { }

        public Scheme(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Название схемы не может быть пустым.");
            }

            Name = name;
            Path = $"maps\\{Name}.png";
            LeftScheme = new Scheme();
            RightScheme = new Scheme();
            UpScheme = new Scheme();
            DownScheme = new Scheme();
            Additional = new List<string>();
        }

        public string Name { get; set; }
        public string Path { get; set; }
        public Scheme LeftScheme { get; set; }
        public Scheme RightScheme { get; set; }
        public Scheme UpScheme { get; set; }
        public Scheme DownScheme { get; set; }
        public List<string> Additional { get; set; }
    }
}
