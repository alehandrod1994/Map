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
        public FormParkingCameras(Parking parking)
        {
            InitializeComponent();

            labelParkingNumber.Text = parking.Number;

            var parkingCameras = Saver.Load<ParkingCamera>();
            var currentParkingCameras = parkingCameras.Where(pc => pc.Parking.Number == parking.Number).ToList();

            UpdateTable(currentParkingCameras);
        }

        private void UpdateTable(List<ParkingCamera> parkingCameras)
        {
            table.Rows.Clear();
            table.RowCount = parkingCameras.Count + 1;

            for (int i = 0; i < parkingCameras.Count; i++)
            {
                table.Rows[i].Cells[0].Value = parkingCameras[i].Camera.Number;
                table.Rows[i].Cells[1].Value = GetRatingValue(parkingCameras[i].Rating);
            }
        }

        private string GetRatingValue(Rating rating)
        {
            string value = "";

            switch(rating)
            {
                case Rating.High:
                    value = "***";
                    break;

                case Rating.Medium:
                    value = "**";
                    break;

                case Rating.Low:
                    value = "*";
                    break;
            }

            return value;
        }

    }
}
