using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class FlashbackForm : Form
    {
        private Flashback _flashback = new Flashback();
        private List<string> _cameras = new List<string>();

        public FlashbackForm(bool topMost)
        {
            InitializeComponent();

            TopMost = topMost;

            if (!Directory.Exists("archive"))
            {
                Directory.CreateDirectory("archive");
            }

            var dirCameras = new DirectoryInfo("archive");
            foreach (DirectoryInfo directory in dirCameras.GetDirectories())
            {
                cbRange.Items.Add(directory.Name);
            }
            cbRange.Text = cbRange.Items[0].ToString();

        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            switch (cbRange.Text)
            {
                case "За всё время":
                    break;

                case "Текущий":
                    break;

                default:
                    var directory = new DirectoryInfo($"archive\\{cbRange.Text}");
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        string cameraNumber = Path.GetFileNameWithoutExtension(file.Name);
                        _cameras.Add(file.FullName);
                    }
                    
                    break;                 
            }

            try
            {
                imgScreen.Image = Image.FromFile(_cameras[0]);
            }
            catch
            {
                imgScreen.Image = null;
            }
        }
    }
}
