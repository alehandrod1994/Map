using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Map.Controller;
using System.Threading.Tasks;

namespace Map
{
    public partial class Form1 : Form
    {
        private Image _img;
        private int _x = 0;
        private int _y = 0;
        private int _picWidth = 0;
        private int _picHeight = 0;
        private int _zoom = 100;
        private Point _lastPoint;
        private readonly int _startY = 24;
        private float _imgWidth;
        private float _imgHeight;
        private float _pictureboxWidth;
        private float _pictureboxHeight;
        private bool _isFirstMap = true;
        private static bool _isTop = false;

        private readonly Audio _audio;
        private string _mapName;
        private Scheme _currentScheme;

        private readonly List<Label> _labels;
        private readonly List<PictureBox> _pictureBoxes;
        private readonly List<string> _cameras;
        private List<Parking> _parkings;

        private readonly UserController _userController;

        public Form1()
        {
            _userController = new UserController();

            ShowLoginForm();

            InitializeComponent();

            List<Audio> audios = Saver.Load<Audio>();
            _audio = audios.Count > 0 ? audios.First() : new Audio();
            _cameras = new List<string>();

            Text = $"Просмотр схем (Пользователь: {_userController.CurrentUser})";

            _labels = new List<Label>()
            {
                labelPreview1,
                labelPreview2,
                labelPreview3,
                labelPreview4,
                labelPreview5,
                labelPreview6,
                labelPreview7,
                labelPreview8,
                labelPreview9,
                labelPreview10,
                labelPreview11,
                labelPreview12,
                labelPreview13,
                labelPreview14,
                labelPreview15,
                labelPreview16,
                labelPreview17,
                labelPreview18,
                labelPreview19,
                labelPreview20,
                labelPreview21,
            };

            _pictureBoxes = new List<PictureBox>()
            {
                pictureBoxPreview1,
                pictureBoxPreview2,
                pictureBoxPreview3,
                pictureBoxPreview4,
                pictureBoxPreview5,
                pictureBoxPreview6,
                pictureBoxPreview7,
                pictureBoxPreview8,
                pictureBoxPreview9,
                pictureBoxPreview10,
                pictureBoxPreview11,
                pictureBoxPreview12,
                pictureBoxPreview13,
                pictureBoxPreview14,
                pictureBoxPreview15,
                pictureBoxPreview16,
                pictureBoxPreview17,
                pictureBoxPreview18,
                pictureBoxPreview19,
                pictureBoxPreview20,
                pictureBoxPreview21,
            };

            MouseWheel += new MouseEventHandler(This_MouseWheel);           
        }

        private void ShowLoginForm()
        {
            var form = new LoginForm(_userController);
            if (form.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        private void LoadMap(string labelPreview)
        {
            var path = $"maps\\{labelPreview}.png";

            if (_mapName != labelPreview)                                                           //Загрузка схемы происходит
            {                                                                                      //если выбрана новая схема
                try
                {
                    _img = Image.FromFile(path);
                    cbMaps.Text = labelPreview;

                    _currentScheme = new Scheme(labelPreview)
                    {
                        LeftScheme = new Scheme("Т1 - 3 этаж (1)")
                    };
                }
                catch
                {
                    MessageBox.Show("Схема не найдена.");
                    return;
                }
            }

            if (_isFirstMap)
            {               
                OpenMapWindow(labelPreview);
            }

            Cursor = Cursors.WaitCursor;
            LoadCameras(labelPreview);
            SortCameras();

            foreach (var camera in _cameras)
            {
                cbCameras.Items.Add(camera);
            }

            if (labelPreview == "Охрана периметра")                                               // Загрузка панели со стоянками
            {
                _parkings = Saver.Load<Parking>();                                                

                cbParkings.Items.Clear();                                                                      
                foreach (var p in _parkings)
                {
                    cbParkings.Items.Add(p.Number);
                }
                panelParking.Visible = true;
            }
            else
            {
                panelParking.Visible = false;
            }

            CalculateMapSize(labelPreview);
            Cursor = Cursors.Default;
        }

        private void CalculateMapSize(string labelPreview)
        {
            _pictureboxWidth = pictureBoxMap.Width;
            _pictureboxHeight = pictureBoxMap.Height;
            _imgWidth = _img.Width;
            _imgHeight = _img.Height;

            _picWidth = pictureBoxMap.Width;                                                        //Изменение размеров изображения под размеры холста    
            _picHeight = Convert.ToInt32(_imgHeight / (_imgWidth / _pictureboxWidth));
            if (pictureBoxMap.Height < _picHeight)
            {
                _picHeight = pictureBoxMap.Height;
                _picWidth = Convert.ToInt32(_imgWidth / (_imgHeight / _pictureboxHeight));
            }

            _x = (pictureBoxMap.Width - _picWidth) / 2;                                              //По центру экрана
            _y = 0;
            labelZoom.Text = "100%";
            _zoom = 100;

            _mapName = labelPreview;
            pictureBoxMap.Invalidate();
        }

        private void LoadCameras(string mapName)
        {
            cbCameras.Items.Clear();                                                         //Загрузка камер
            cbCameras.Text = "";
            _cameras.Clear();

            if (Directory.Exists($"cameras\\{mapName}"))
            {
                DirectoryInfo dirCameras = new DirectoryInfo($"cameras\\{mapName}");
                foreach (FileInfo file in dirCameras.GetFiles())
                {
                    _cameras.Add(Path.GetFileNameWithoutExtension(file.Name));
                }
            }
        }


        private void SortCameras()
        {
            var count = _cameras.Count;

            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < count - j - 1; i++)
                {
                    var a = _cameras[i];
                    var b = _cameras[i + 1];

                    if (a.Length > b.Length || (a.Length == b.Length && a.CompareTo(b) == 1))
                    {
                        Swap(i, i + 1);
                    }
                }
            }
        }

        private void Swap(int positionA, int positionB)
        {
            if (positionA < _cameras.Count && positionB < _cameras.Count)
            {
                var temp = _cameras[positionA];
                _cameras[positionA] = _cameras[positionB];
                _cameras[positionB] = temp;
            }
        }
       
        private void OpenMapWindow(string mapName)
        {
            ImgTopLevel.Visible = true;
            pictureBoxMap.Visible = true;
            imgMapLogo.Visible = true;
            imgCameraLogo.Visible = true;
            cbMaps.Visible = true;
            cbCameras.Visible = true;
            btnOpenMap.Visible = true;
            btnOpenCamera.Visible = true;
            imgMinus.Visible = true;
            imgPlus.Visible = true;
            labelZoom.Visible = true;
            panelStart.Visible = false;
            _audio.Stop();

            WindowState = FormWindowState.Maximized;                                      //Подбор размеров под разрешение монитора
            MaximizeBox = true;
            pictureBoxMap.Width = Width - 10;
            pictureBoxMap.Height = Height - 150;

            cbMaps.Items.Clear();                                                         //Загрузка схем               
            DirectoryInfo dirMaps = new DirectoryInfo("maps");
            foreach (FileInfo file in dirMaps.GetFiles())
            {
                cbMaps.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            cbMaps.Text = mapName;
            _isFirstMap = false;
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            panelStart.Location = new Point(0, _startY);
            MaximizeBox = false;
            Width = 1280;
            Height = 720;
         
            if (_audio.Enabled == true)
            {
                pictureBoxSound.Image = Properties.Resources.speaker;
                _audio.Play();
            }
            else
            {
                pictureBoxSound.Image = Properties.Resources.mute;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 0, 98, pictureBoxMap.Width, 98);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
          
           /* if (zoom == 100)
            {
                hScrollBar1.Maximum = 100;
                vScrollBar1.Maximum = 100;
            }

            if (zoom == 125)
            {
                hScrollBar1.Maximum = Convert.ToInt32(picWidth / 2.7);
                vScrollBar1.Maximum = Convert.ToInt32(picHeight / 2.45);
            }

            if (zoom == 150)
            {
                hScrollBar1.Maximum = Convert.ToInt32(picWidth / 1.73);
                vScrollBar1.Maximum = Convert.ToInt32(picHeight / 1.65);
            }

            if (zoom == 175)
            {
                hScrollBar1.Maximum = Convert.ToInt32(picWidth / 1.39);
                vScrollBar1.Maximum = Convert.ToInt32(picHeight / 1.36);
            }

            if (zoom == 200)
            {
                hScrollBar1.Maximum = Convert.ToInt32(picWidth / 1.23);
                vScrollBar1.Maximum = Convert.ToInt32(picHeight / 1.21);
            }    */     

            Graphics g = e.Graphics;
            g.DrawImage(_img, _x, _y, _picWidth, _picHeight);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
          //  x = e.NewValue;    
          //  pictureBoxMap.Invalidate();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
          //  y = e.NewValue;
          //  pictureBoxMap.Invalidate();
        }

        private void BtnOpenCamera_Click(object sender, EventArgs e)
        {
            var path = $"cameras\\{_mapName}\\{cbCameras.Text}.jpg";

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Камера не найдена.");
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
            pictureBoxMap.Invalidate();
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBoxMap.Capture)
            {
                _x += e.X - _lastPoint.X;
                _y += e.Y - _lastPoint.Y;
                _lastPoint = new Point(e.X, e.Y);
                pictureBoxMap.Invalidate();
            }
        }

        private async void ImgMinus_Click(object sender, EventArgs e)
        {
            await Task.Run(() => pictureBoxMap.BeginInvoke((Action)delegate
            {
                if (_zoom == 100)
                {
                    _picWidth = Convert.ToInt32(_picWidth / 2);
                    _picHeight = Convert.ToInt32(_picHeight / 2);
                    _zoom -= 50;
                    _x = Convert.ToInt32((_x / 2) + (pictureBoxMap.Width / 4));
                    _y = Convert.ToInt32((_y / 2) + (pictureBoxMap.Height / 4));
                }

                else if (_zoom > 100)
                {
                    _picWidth = Convert.ToInt32(_picWidth / 1.5);
                    _picHeight = Convert.ToInt32(_picHeight / 1.5);
                    _zoom -= 25;
                    _x = Convert.ToInt32((_x / 1.5) + (pictureBoxMap.Width / 6));
                    _y = Convert.ToInt32((_y / 1.5) + (pictureBoxMap.Height / 6));
                }

                labelZoom.Text = _zoom + "%";
                pictureBoxMap.Invalidate();
            }));
        }

        private async void ImgPlus_Click(object sender, EventArgs e)
        {
            await Task.Run(() => pictureBoxMap.BeginInvoke((Action)delegate
            {
                if (_zoom == 50)
                {
                    _picWidth = Convert.ToInt32(_picWidth * 2);
                    _picHeight = Convert.ToInt32(_picHeight * 2);
                    _zoom += 50;
                    _x = Convert.ToInt32((_x * 2) - (pictureBoxMap.Width / 2));
                    _y = Convert.ToInt32((_y * 2) - (pictureBoxMap.Height / 2));
                }

                else if (_zoom < 200)
                {
                    _picWidth = Convert.ToInt32(_picWidth * 1.5);
                    _picHeight = Convert.ToInt32(_picHeight * 1.5);
                    _zoom += 25;
                    _x = Convert.ToInt32((_x * 1.5) - (pictureBoxMap.Width / 4));
                    _y = Convert.ToInt32((_y * 1.5) - (pictureBoxMap.Height / 4));
                }

                labelZoom.Text = _zoom + "%";
                pictureBoxMap.Invalidate();
            }));

        }      

        #region Обработка нажатий на превью схем
        private void PictureBoxPreview1_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview1.Text);
        }

        private void PictureBoxPreview2_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview2.Text);
        }

        private void PictureBoxPreview3_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview3.Text);
        }

        private void PictureBoxPreview4_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview4.Text);
        }

        private void PictureBoxPreview5_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview5.Text);
        }

        private void pictureBoxPreview6_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview6.Text);
        }

        private void PictureBoxPreview7_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview7.Text);
        }

        private void PictureBoxPreview8_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview8.Text);
        }

        private void PictureBoxPreview9_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview9.Text);
        }

        private void PictureBoxPreview10_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview10.Text);
        }     

        private void PictureBoxPreview11_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview11.Text);
        }

        private void PictureBoxPreview12_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview12.Text);
        }

        private void PictureBoxPreview13_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview13.Text);
        }

        private void PictureBoxPreview14_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview14.Text);
        }

        private void PictureBoxPreview15_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview15.Text);
        }

        private void PictureBoxPreview16_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview16.Text);
        }

        private void PictureBoxPreview17_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview17.Text);
        }

        private void PictureBoxPreview18_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview18.Text);
        }

        private void PictureBoxPreview19_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview19.Text);
        }

        private void PictureBoxPreview20_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview20.Text);
        }

        private void PictureBoxPreview21_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview21.Text);
        }
        #endregion

        private void ButtonOpenMap_Click(object sender, EventArgs e)
        {
            LoadMap(cbMaps.Text);
        }

        private void PanelStart_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }

        private void PanelStart_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _lastPoint.X;
                Top += e.Y - _lastPoint.Y;
            }           
        }

        private void PictureBoxSound_Click(object sender, EventArgs e)
        {
            if (_audio.Enabled == true)
            {
                _audio.Stop();
                _audio.Enabled = false;
                pictureBoxSound.Image = Properties.Resources.mute;
            }
            else
            {
                _audio.Enabled = true;
                pictureBoxSound.Image = Properties.Resources.speaker;
            }

            Saver.Save(new List<Audio>() { _audio });
        }    

        private void This_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                //(Controls[$"labelPreview{1}"] as Label).Top -= 10;

                labelTitle.Top -= 20;

                foreach (var label in _labels)
                {
                    label.Top -= 20;
                }

                foreach (var picture in _pictureBoxes)
                {
                    picture.Top -= 20;
                }
            }
            else
            {
                labelTitle.Top += 20;

                foreach (var label in _labels)
                {
                    label.Top += 20;
                }

                foreach (var picture in _pictureBoxes)
                {
                    picture.Top += 20;
                }
            }
        }

        private void ShowParkingCameras()
        {
            var parking = _parkings.SingleOrDefault(p => p.Number.Equals(cbParkings.Text, StringComparison.CurrentCultureIgnoreCase));

            if (parking != null)
            {
                var form = new FormParkingCameras(_isTop, parking);
                form.Show();
            }
            else
            {
                MessageBox.Show("Стоянка не найдена.");
            }
        }

        private void BtnOpenParking_Click(object sender, EventArgs e)
        {
            ShowParkingCameras();
        }

        private void ImgSettings_Click(object sender, EventArgs e)
        {
            RunSafe(ShowSettingsForm);
        }

        private static void ShowSettingsForm()
        {
            var form = new SettingsForm(_isTop);
            form.ShowDialog();
        }

        private void SearchCamerasItem_Click(object sender, EventArgs e)
        {
            var form = new SearchCameraForm(_isTop);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadMap(form.SelectedMap);
            }
        }

        private void SettingsItem_Click(object sender, EventArgs e)
        {
            RunSafe(ShowSettingsForm);
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ManualItem_Click(object sender, EventArgs e)
        {
            string path = "manual\\Пошаговая инструкция.docx";

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Не удалось открыть инструкцию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AboutItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm(_isTop);
            aboutForm.Show();
        }      

        private void RunSafe(Action action)
        {
            if (_userController.CurrentUser.Role == Role.Admin)
            {
                action();
            }
            else
            {
                MessageBox.Show("Отказано в доступе.");
            }
        }

        private void ImgTopLevel_Click(object sender, EventArgs e)
        {
            if (!_isTop)
            {
                _isTop = true;
                ImgTopLevel.Image = Properties.Resources.top_on;
            }
            else
            {
                _isTop = false;                
                ImgTopLevel.Image = Properties.Resources.top_off;
            }

            TopMost = _isTop;
        }
    }
}
