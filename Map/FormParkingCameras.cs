using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class FormParkingCameras : Form
    {
        public FormParkingCameras()
        {
            InitializeComponent();
        }

        public FormParkingCameras(Parking parking)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = parking.Cameras.Count;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = parking.Cameras[i].Number;
                dataGridView1.Rows[i].Cells[1].Value = GetRatingValue(parking.Cameras[i].Rating);
            }
        }

        private string GetRatingValue(Rating rating)
        {
            string value = "";

            switch(rating)
            {
                case Map.Rating.High:
                    value = "***";
                    break;

                case Map.Rating.Medium:
                    value = "**";
                    break;

                case Map.Rating.Low:
                    value = "*";
                    break;
            }

            return value;
        }

    }
}
