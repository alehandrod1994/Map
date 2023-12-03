using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private readonly List<Parking> _parkings;
        private readonly List<Camera> _cameras;
        private readonly List<ParkingCamera> _parkingCameras;

        public SettingsForm(bool topMost)
        {
            InitializeComponent();

            TopMost = topMost;
            _currentParking = new Parking();
            _currentParkingCameras = new List<ParkingCamera>();

            _parkings = Saver.Load<Parking>();
            _cameras = Saver.Load<Camera>();
            _parkingCameras = Saver.Load<ParkingCamera>();
            
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

                tvParking.Nodes.Add(node);
            }

            _currentParking = null;
            _currentParkingCameras = null;
            panelParkingPreview.Enabled = false;
        }

        private void ResetParkingPreview()
        {
            imgParking.Image = null;
            labelCameraNumber.Text = "";
            tbParkingNumber.Text = "";
            tbParkingCameras.Text = "";
            tableSelectedCameras.Visible = false;         
            tableSelectedCameras.Rows.Clear();
        }
        
        private void TvParking_AfterSelect(object sender, TreeViewEventArgs e)
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
            labelCameraNumber.Text = $"Камера {camera.Number}";

            try
            {
                Image img = Image.FromFile($"cameras\\Охрана периметра\\{camera.Number}.jpg");
                imgParking.Image = img;

            }
            catch
            {
                imgParking.Image = null;             
            }
        }

        private void UpdateParkingPreview()
        {
            tbParkingNumber.Text = _currentParking.Number;
            UpdateParkingCamerasData();
        }

        private void UpdateParkingCamerasData()
        {
            tbParkingCameras.Text = string.Join("; ", _currentParkingCameras.Select(pc => pc.Camera));

            tableSelectedCameras.Rows.Clear();
            tableSelectedCameras.RowCount = _currentParkingCameras.Count + 1;

            for (int i = 0; i < _currentParkingCameras.Count; i++)
            {
                tableSelectedCameras.Rows[i].Cells[0].Value = _currentParkingCameras[i].Camera.Number;
                tableSelectedCameras.Rows[i].Cells[1].Value = Parser.GetValue(_currentParkingCameras[i].Rating);
            }           
        }

        private void BtnPrepareAddParking_Click(object sender, EventArgs e)
        {
            ShowAddParkingForm();
        }
     
        private void AddParking(Parking newParking)
        {
            var parking = _parkings.FirstOrDefault(p => p.Number.Equals(newParking.Number, StringComparison.CurrentCultureIgnoreCase));
            if (parking == null)
            {
                _parkings.Add(newParking);
                Saver.Save(_parkings);
            }
            else
            {
                MessageBox.Show("Такая стоянка уже есть.");
                return;
            }

            UpdateParkings();
            tvParking.SelectedNode = tvParking.Nodes[tvParking.Nodes.Count - 1];
            tvParking.Focus();
        }

        private void ShowAddParkingForm()
        {
            var form = new AddParkingForm(TopMost);
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddParking(form.Parking);
            }
        }

        private void BtnRemoveParking_Click(object sender, EventArgs e)
        {
            if (tvParking.SelectedNode == null)
            {
                return;
            }

            ShowRemoveParkingForm();          
        }

        private void RemoveParking()
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
            var form = new RemoveParkingForm(TopMost, _currentParking);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RemoveParking();
            }
        }
       
        private void BtnAddCameras_Click(object sender, EventArgs e)
        {
            tableSelectedCameras.Visible = !tableSelectedCameras.Visible;
        }

        private bool MarkOnValid()
        {
            if (string.IsNullOrWhiteSpace(tbParkingNumber.Text))
            {
                MessageBox.Show("Номер стоянки не может быть пустым.");
                return false;
            }

            if (!FormatTable(tableSelectedCameras, out int index))
            {
                MessageBox.Show($"Неверно введён номер камеры на {index} строке.");
                return false;
            }

            return true;
        }

        private void BtnSaveParking_Click(object sender, EventArgs e)
        {
            if (!MarkOnValid())
            {
                return;
            }         

            SaveParkings();
            SaveParkingCameras();
            SaveCameras();

            if (_currentParkingCameras.Count > 0)
            {
                _imgIndex = 0;
                UpdateImgParking();
            }
            UpdateParkingPreview();

            MessageBox.Show("Сохранено.");           
        }
      
        private void SaveParkings()
        {          
            _currentParking.Number = tbParkingNumber.Text;
            tvParking.SelectedNode.Text = _currentParking.Number;
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
                var rating = Parser.GetRating(tableSelectedCameras.Rows[i].Cells[1].Value.ToString());

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
       
        private int ParseInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        private void BtnCancelParking_Click(object sender, EventArgs e)
        {
            UpdateParkingPreview();
        }

        private void BtnNextImgParking_Click(object sender, EventArgs e)
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

        private void BtnPreviousImgParking_Click(object sender, EventArgs e)
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

        private async void BtnExportParkings_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Title = "Введите название файла";
            saveFileDialog1.Filter = "Документ Excel (*xlsx) | *.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var newFileName = saveFileDialog1.FileName;
                var progress = new Progress<int>(value => progressBarParkings.Value = value);
                var report = new Report();

                SetUiForStartExport();

                ReportStatus status = await Task.Run(() => report.ExportParkings(newFileName, progress));

                SetUiForEndExport();
                ShowExportResult(status, newFileName);                                 
            }
        }

        private void SetUiForStartExport()
        {
            btnExportParkings.Enabled = false;
            progressBarParkings.Value = 0;
            progressBarParkings.Visible = true;
        }

        private void SetUiForEndExport()
        {
            btnExportParkings.Enabled = true;
            progressBarParkings.Visible = false;
        }

        private void ShowExportResult(ReportStatus status, string newFileName)
        {
            switch (status)
            {
                case ReportStatus.Failed:
                    MessageBox.Show("Не удалось открыть подключение к файлу.");
                    break;

                case ReportStatus.NotSave:
                    MessageBox.Show("Не удалось сохранить файл.");
                    break;

                case ReportStatus.Success:
                    var form = new SuccessfullyExport(TopMost, newFileName);
                    form.Show();
                    break;
            }           
        }

        private void BtnUpParking_Click(object sender, EventArgs e)
        {
            if (tvParking.SelectedNode == null)
            {
                return;
            }

            ReplaceParking(tvParking.SelectedNode.Index - 1);
        }

        private void BtnDownParking_Click(object sender, EventArgs e)
        {
            if (tvParking.SelectedNode == null)
            {
                return;
            }

            ReplaceParking(tvParking.SelectedNode.Index + 1);
        }

        private void ReplaceParking(int newParkingIndex)
        {
            if (newParkingIndex != -1 && newParkingIndex != _parkings.Count)
            {
                int currentParkingIndex = tvParking.SelectedNode.Index;

                var temp = _parkings[currentParkingIndex];
                _parkings[currentParkingIndex] = _parkings[newParkingIndex];
                _parkings[newParkingIndex] = temp;

                tvParking.Nodes[currentParkingIndex].Text = _parkings[currentParkingIndex].Number;
                tvParking.Nodes[newParkingIndex].Text = _parkings[newParkingIndex].Number;
                tvParking.SelectedNode = tvParking.Nodes[newParkingIndex];
                tvParking.Select();

                Saver.Save(_parkings);
            }
        }

        private void ImgParking_Click(object sender, EventArgs e)
        {
            if (_currentParkingCameras.Count > 0)
            {
                var camera = _currentParkingCameras[_imgIndex].Camera;
                var path = $"cameras\\Охрана периметра\\{camera.Number}.jpg";

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
}
