using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                table.Rows[i].Cells[1].Value = Parser.GetValue(parkingCameras[i].Rating);
            }
        }

        private void Table_DoubleClick(object sender, EventArgs e)
        {
            var cameraNumber = table.SelectedRows[0].Cells[0].Value;
            var path = $"cameras\\Охрана периметра\\{cameraNumber}.jpg";

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Камера не найдена.");
            }
        }
    }
}
