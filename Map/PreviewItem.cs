using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public class PreviewItem
    {
        private Image _img;

        public PreviewItem(int number, string name, int x, int y)
        {
            Panel = new Panel();
            Label = new Label();          
            Img = new PictureBox();

            // 
            // panel
            // 
            Panel.Controls.Add(Label);
            Panel.Controls.Add(Img);
            Panel.Location = new Point(x, y);
            Panel.Name = "PreviewPanel" + number;
            Panel.Size = new Size(180, 200);
            //Panel.BackColor = Color.Black;
            // 
            // label
            // 
            Label.AutoSize = true;
            Label.TextAlign = ContentAlignment.TopCenter;
            Label.Location = new Point(0, 0);
            Label.Name = "PreviewLabel" + number;
            Label.Size = new Size(180, 20);
            Label.Text = name;
            // 
            // pictureBox
            // 
            Img.Location = new Point(0, 20);
            Img.Name = "PreviewImg" + number;
            Img.Size = new Size(180, 180);
            Img.SizeMode = PictureBoxSizeMode.Zoom;

            LoadMap(name);

        }

        public Panel Panel { get; set; }
        public Label Label { get; set; }
        public PictureBox Img { get; set; }

        private void LoadMap(string name)
        {
            string path = $"maps\\{name}.png";

            try
            {
                _img = Image.FromFile(path);
                Img.Image = _img;
            }
            catch
            {
                Img.Image = null;
            }
        }
    }
}
