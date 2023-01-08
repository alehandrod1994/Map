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
    public partial class AddCamerasForm : Form
    {
        private Parking _parking;
        private List<Camera> _cameras;
        private List<ParkingCamera> _parkingCameras;

        public AddCamerasForm(Parking parking, List<Camera> cameras, List<ParkingCamera> parkingCameras)
        {
            InitializeComponent();

            _parking = parking;
            _cameras = cameras;
            _parkingCameras = parkingCameras;

            ResetData();          
        }

        private void ResetData()
        {
            labelParkingNumber.Text = _parking.Number;

            var selectedCameras = _parkingCameras.Select(pc => pc.Camera).ToList();
            _cameras = _cameras.Except(selectedCameras).ToList();

            tableAllCameras.Rows.Clear();
            tableSelectedCameras.Rows.Clear();
            tableAllCameras.RowCount = _cameras.Count + 1;
            tableSelectedCameras.RowCount = _parkingCameras.Count + 1;

            for (int i = 0; i < _cameras.Count; i++)
            {
                tableAllCameras.Rows[i].Cells[0].Value = _cameras[i].Number;
            }
            tableAllCameras.Sort(tableCamerasCameraColumn, ListSortDirection.Ascending);

            for (int i = 0; i < _parkingCameras.Count; i++)
            {
                tableSelectedCameras.Rows[i].Cells[0].Value = _parkingCameras[i].Camera.Number;
                tableSelectedCameras.Rows[i].Cells[1].Value = GetRatingValue(_parkingCameras[i].Rating);
            }
            tableSelectedCameras.Sort(tableSelectedCamerasRatingColumn, ListSortDirection.Descending);
        }

        private string GetRatingValue(Rating rating)
        {
            string value = "";

            switch (rating)
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

        private void btnMoveCameraToRightTable_Click(object sender, EventArgs e)
        {
            MoveCamera(tableAllCameras, tableSelectedCameras);
        }

        private void btnMoveCameraToLeftTable_Click(object sender, EventArgs e)
        {
            MoveCamera(tableSelectedCameras, tableAllCameras);
        }

        private void MoveCamera(DataGridView firstTable, DataGridView secondTable)
        {
            if (firstTable.SelectedCells.Count > 0)
            {
                foreach (DataGridViewTextBoxCell cell in firstTable.SelectedCells)
                {
                    secondTable.Rows.Add(cell.Value);
                    firstTable.Rows.RemoveAt(cell.RowIndex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetData();
        }

       
    }
}
