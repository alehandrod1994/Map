using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class SettingsForm : Form
    {
        private int _imgIndex;

        private Parking _currentParking;

        private List<ParkingCamera> _currentParkingCameras;

        private List<Parking> _parkings;
        private List<Camera> _cameras;
        private List<ParkingCamera> _parkingCameras;

        public SettingsForm()
        {
            InitializeComponent();

            _currentParking = new Parking();
            _currentParkingCameras = new List<ParkingCamera>();

            _parkings = Saver.Load<Parking>();
            _cameras = Saver.Load<Camera>();
            _parkingCameras = Saver.Load<ParkingCamera>();
          
            tvParking.ImageList = imageList1;

            UpdateParkings();
            ResetParkingPreview();
        }

        private void UpdateParkings()
        {
            tvParking.Nodes.Clear();
            foreach (var parking in _parkings)
            {
                var node = new TreeNode()
                {
                    Text = parking.Number,
                    ImageIndex = 0,
                    SelectedImageIndex = 0
                };

                tvParking.Nodes.Add(parking.Number);
            }

            _currentParking = null;
            _currentParkingCameras = null;
            panelParkingPreview.Enabled = false;
        }

        private void ResetParkingPreview()
        {
            imgParking.Image = null;
            tbParkingNumber.Text = "";
            tbParkingCameras.Text = "";
            tableSelectedCameras.Visible = false;         
            tableSelectedCameras.Rows.Clear();
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

        private Rating GetRating(string value)
        {
            var rating = Rating.Low;

            switch (value)
            {
                case "***":
                    rating = Rating.High;
                    break;

                case "**":
                    rating = Rating.Medium;
                    break;

                case "*":
                    rating = Rating.Low;
                    break;

                default:
                    rating = Rating.Low;
                    break;
            }

            return rating;
        }

        private void tvParking_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panelParkingPreview.Enabled = true;
            ResetParkingPreview();

            _currentParking = _parkings.FirstOrDefault(p => p.Number == e.Node.Text);
            _currentParkingCameras = _parkingCameras.Where(pc => pc.Parking.Number == _currentParking.Number).ToList();

            if (_currentParkingCameras.Count > 0)
            {
                _imgIndex = 0;
                UpdateImgParking();

            }

            UpdateParkingPreview();
        }

        private void UpdateImgParking()
        {
            var camera = _currentParkingCameras[_imgIndex].Camera;

            try
            {
                Image img = Image.FromFile(@"камеры\Охрана периметра\" + camera.Number + ".jpg");
                imgParking.Image = img;

            }
            catch
            {
                MessageBox.Show("Схема не найдена.");
            }
        }

        private void UpdateParkingPreview()
        {
            tbParkingNumber.Text = _currentParking.Number;
            UpdateParkingCamerasData();
        }

        private void UpdateParkingCamerasData()
        {
            tbParkingCameras.Text = "";
            foreach (var pc in _currentParkingCameras)
            {
                tbParkingCameras.Text += pc.Camera.Number + "; ";
            }

            tableSelectedCameras.Rows.Clear();
            tableSelectedCameras.RowCount = _currentParkingCameras.Count + 1;

            for (int i = 0; i < _currentParkingCameras.Count; i++)
            {
                tableSelectedCameras.Rows[i].Cells[0].Value = _currentParkingCameras[i].Camera.Number;
                tableSelectedCameras.Rows[i].Cells[1].Value = GetRatingValue(_currentParkingCameras[i].Rating);
            }           
        }

        private void btnPrepareAddParking_Click(object sender, EventArgs e)
        {
            ShowAddParkingForm();

            //tbAddParking.Text = "";
            //tbAddParking.Visible = true;
            //btnAddParking.Visible = true;
        }

        private void btnAddParking_Click(object sender, EventArgs e)
        {
                     
        }
     
        private void AddParking(object sender, EventArgs e)
        {
            var newParking = sender.ToString();

            if (string.IsNullOrWhiteSpace(newParking))
            {
                return;
            }

            var parking = _parkings.FirstOrDefault(p => p.Number == newParking);
            if (parking == null)
            {
                parking = new Parking(newParking);
                _parkings.Add(parking);
                Saver.Save(_parkings);
            }
            else
            {
                MessageBox.Show("Такая стоянка уже есть.");
            }

            UpdateParkings();
            ResetParkingPreview();

            //tbAddParking.Visible = false;
            //btnAddParking.Visible = false;
        }

        private void ShowAddParkingForm()
        {
            var addParkingForm = new AddParkingForm();
            addParkingForm.OnAdd += AddParking;
            addParkingForm.ShowDialog();
        }

        private void btnRemoveParking_Click(object sender, EventArgs e)
        {
            if (tvParking.SelectedNode == null)
            {
                return;
            }

            ShowRemoveParkingForm();          
        }

        private void RemoveParking(object sender, EventArgs e)
        {           
            _parkings.Remove(_currentParking);
            _parkingCameras.RemoveAll(pc => pc.Parking.Number == _currentParking.Number);

            Saver.Save(_parkings);
            Saver.Save(_parkingCameras);

            UpdateParkings();
            ResetParkingPreview();           
        }

        private void ShowRemoveParkingForm()
        {
            var removeParkingForm = new RemoveParkingForm(_currentParking);
            removeParkingForm.OnRemove += RemoveParking;
            removeParkingForm.ShowDialog();
        }

        //private void UpdateTables()
        //{
        //    var parking = _parkings.FirstOrDefault(p => p.Number == cbParking.Text);

        //    if (parking == null)
        //    {
        //        return;
        //    }

        //    UpdateTableSelectedCameras(parking);

        //    var selectedCameras = new List<Camera>();
        //    foreach (var camera in parking.Cameras)
        //    {
        //        selectedCameras.Add(camera.Key);
        //    }

        //    var exceptCameras = _cameras.Except(selectedCameras).ToList();
        //    UpdateTableAllCameras(exceptCameras);
        //}


        private void btnAddCameras_Click(object sender, EventArgs e)
        {
            tableSelectedCameras.Visible = tableSelectedCameras.Visible ? false : true;
        }

        private void ShowAddCamerasForm()
        {
            AddCamerasForm addCamerasForm = new AddCamerasForm(_currentParking, _cameras, _currentParkingCameras);
            addCamerasForm.Show();
        }

        private bool MarkOnValid()
        {
            if (string.IsNullOrWhiteSpace(tbParkingNumber.Text))
            {
                MessageBox.Show("Номер стоянки не может быть пустым.");
                return false;
            }

            int index = 0;
            if (!FormatTable(tableSelectedCameras, out index))
            {
                MessageBox.Show($"Неверно введён номер камеры на {index} строке.");
                return false;
            }

            return true;
        }

        private void btnSaveParking_Click(object sender, EventArgs e)
        {
            if (!MarkOnValid())
            {
                return;
            }
            
            SaveParkings();
            SaveParkingCameras();
            SaveCameras();
           
            MessageBox.Show("Сохранено.");           
        }
      
        private void SaveParkings()
        {          
            _currentParking.Number = tbParkingNumber.Text;
            Saver.Save(_parkings);
        }

        private void SaveParkingCameras()
        {
            _currentParkingCameras.Clear();
            _parkingCameras.RemoveAll(pc => pc.Parking.Number == _currentParking.Number);

            tableSelectedCameras.Sort(tableSelectedCamerasRatingColumn, ListSortDirection.Descending);

            for (int i = 0; i < tableSelectedCameras.RowCount - 1; i++)
            {
                var camera = new Camera(Convert.ToInt32(tableSelectedCameras.Rows[i].Cells[0].Value));
                var rating = GetRating(tableSelectedCameras.Rows[i].Cells[1].Value.ToString());

                var parkingCamera = new ParkingCamera(_currentParking, camera, rating);
                _currentParkingCameras.Add(parkingCamera);                
            }

            UpdateParkingCamerasData();

            _parkingCameras.AddRange(_currentParkingCameras);
            Saver.Save(_parkingCameras);
        }     

        private void SaveCameras()
        {
            var selectedCameras = _currentParkingCameras.Select(pc => pc.Camera).ToList();
            var newCameras = selectedCameras.Except(_cameras).ToList();

            if (newCameras != null)
            {
                foreach (var camera in newCameras)
                {
                    _cameras.Add(camera);
                }

                Saver.Save(_cameras);
            }
        }

        private bool FormatTable(DataGridView table, out int index)
        {
            index = 0;
            for (int i = 0; i < table.RowCount - 1; i++)
            {
                string column1 = table.Rows[i].Cells[0].Value?.ToString();
                string column2 = table.Rows[i].Cells[1].Value?.ToString();

                if (string.IsNullOrWhiteSpace(column1) || string.IsNullOrWhiteSpace(column2))
                {
                    table.Rows.RemoveAt(i);
                    i--;
                    continue;
                }

                table.Rows[i].Cells[0].Value = Regex.Replace(column1, @"\s+", " ");

                if (ParseInt(column1) < 1)
                {
                    index = i + 1;
                    return false;
                }
            }

            return true;
        }

        //    private void RenameParking()
        //    {
        //        parkingNumber = ParseInt(cbParking.Text);
        //        if (parkingNumber == 0) return;

        //        newParkingNumber = ParseInt(tbNewParkingNumber.Text);
        //        if (newParkingNumber == 0) return;

        //        var parking = _parkings.SingleOrDefault(p => p.Number == parkingNumber);
        //        if (parking != null)
        //        {
        //            _parkings[parking].Number = newParkingNumber;
        //            Save(_parkings);
        //        }

        //        foreach (camera in _cameras)
        //        {
        //            parking = camera.Parkings.SingleOrDefault(p => p.Number == parkingNumber);
        //            if (parking != null)
        //            {
        //                camera.Parkings[parking].Number = newParkingNumber;
        //                Save(_cameras);
        //            }
        //        }

        //        var parkings = _parkingCameras.Where(pc => pc.Parking.Number == parkingNumber);
        //        if (parkings != null)
        //        {
        //            foreach (parking in parkings)
        //            {
        //                _parkingCameras[parking].Parking.Number = newParkingNumber;
        //            }

        //            Save(_parkingCameras);
        //        }

        //        MessageBox.Show("Стоянка успешно изменена.");
        //    }

        //    private void SaveParkingsChanges()
        //    {
        //        _parking.Cameras.Clear();

        //        for (int i = 0; i < DataGridViewContains.RowCount - 1; i++)
        //        {
        //            var camera = new Camera(ParseInt(DataGridViewContains.Rows[i].Cells[0]));
        //            _parking.Cameras.Add(camera);
        //        }

        //        Save(_parking);
        //    }

        //    private void SaveCamerasChanges()
        //    {
        //        for (int i = 0; i < DataGridViewContains.RowCount - 1; i++)
        //        {
        //            for (int j = 0; j < _cameras.Count; j++)
        //            {
        //                if (DataGridViewContains.Rows[i].Cells[0] == _cameras[j].Number.ToString())
        //                {
        //                    var parkingIntersect = _cameras[j].Parkings.ToString().Intersect(cbParking.Text);

        //                    if (parkingIntersect == null)
        //                    {
        //                        _cameras[j].Parkings.Add(new Parking(ParseInt(cbParking.Text)));
        //                    }

        //                    break;
        //                }
        //            }
        //        }

        //        for (int i = 0; i < DataGridViewNotContains.RowCount - 1; i++)
        //        {
        //            for (int j = 0; j < _cameras.Count; j++)
        //            {
        //                if (DataGridViewNotContains.Rows[i].Cells[0] == _cameras[j].Number.ToString())
        //                {
        //                    var parkingIntersect = _cameras[j].Parkings.ToString().Intersect(cbParking.Text);

        //                    if (parkingIntersect != null)
        //                    {
        //                        _cameras[j].Parkings.Remove(parkingIntersect);
        //                    }

        //                    break;
        //                }
        //            }
        //        }

        //        Save(_cameras);
        //    }

        //    private void SaveParkingCamerasChanges()
        //    {
        //        for (int i = 0; i < _parkingCameras.Count; i++)
        //        {
        //            if (_parkingCameras[i].Parking.Number.ToString() == cbParking.Text)
        //            {
        //                _parkingCameras.RemoveAt(i);

        //                i--;
        //            }
        //        }

        //        for (int i = 0; i < DataGridViewContains.RowCount - 1; i++)
        //        {
        //            var parkingCamera = new ParkingCamera()
        //            {
        //                Parking = new Parking(ParseInt(DataGridViewContains.Rows[i].Cells[0]));
        //            Camera = new Camera(ParseInt(DataGridViewContains.Rows[i].Cells[1]));
        //            Rating = // метод для вставки Rating.	

        //            }

        //        _parkingCameras.Add(parkingCamera);
        //    }


        //        Save(_parkingCameras);
        //}

        //private void Cancel()
        //{
        //    UpdateDataParking();
        //}



        private int ParseInt(string value)
        {
            int result = 0;

            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {               
                return 0;
            }
        }

        private void btnCancelParking_Click(object sender, EventArgs e)
        {
            UpdateParkingPreview();
        }

        private void btnNextImgParking_Click(object sender, EventArgs e)
        {
            if (_currentParkingCameras.Count > 0)
            {
                _imgIndex++;

                if (_imgIndex == _currentParkingCameras.Count)
                {
                    _imgIndex = 0;
                }

                UpdateImgParking();
            }
        }

        private void btnPreviousImgParking_Click(object sender, EventArgs e)
        {
            if (_currentParkingCameras.Count > 0)
            {
                _imgIndex--;

                if (_imgIndex < 0)
                {
                    _imgIndex = _currentParkingCameras.Count - 1;
                }

                UpdateImgParking();
            }
        }

        //private void Save<T>(List<T> items)
        //{
        //    var formatter = new BinaryFormatter();
        //    var fileName = $"{typeof(T).Name}s.bin";

        //    using (var fs = new FileStream(fileName, FIleMode.OpenOrCreate))
        //    {
        //        formatter.Serialize(fs, items);
        //    }
        //}

        //private List<T> Load<T>()
        //{
        //    var formatter = new BinaryFormatter();
        //    var fileName = $"{typeof(T).Name}s.bin";

        //    using (var fs = new FileStream(fileName, FIleMode.OpenOrCreate))
        //    {
        //        return fs.Length > 0 && formatter.Deserialize(fs) is List<T> items? items : new List<T>();
        //    }
        //}
    }
}
