﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Runtime.Serialization.Json;

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
        private float _imgWidth;
        private float _imgHeight;
        private float _pictureboxWidth;
        private float _pictureboxHeight;
        private bool _isFirstMap = true;

        private Audio _audio;
        private string _mapName;

        private List<Label> _labels;
        private List<PictureBox> _pictureBoxes;
        private List<string> _cameras;
        private List<Parking> _parkings = new List<Parking>();
        private List<Camera> _ccameras = new List<Camera>();
        private List<ParkingCamera> _parkingCameras = new List<ParkingCamera>();

        public Form1()
        {
            InitializeComponent();

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
                labelPreview18
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
                pictureBoxPreview18
            };

            MouseWheel += new MouseEventHandler(This_MouseWheel);

            List<Audio> audios = Saver.Load<Audio>();
            _audio = audios.Count > 0 ? audios.First() : new Audio();
            _cameras = new List<string>();
            _parkings = Saver.Load<Parking>();

        }

        private void LoadMap(string labelPreview)
        {
            if (_mapName != labelPreview)                                                           //Загрузка схемы происходит
            {                                                                                      //если выбрана новая схема
                try
                {
                    _img = Image.FromFile(@"схемы\" + labelPreview + ".png");
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

            if (labelPreview == "Охрана периметра")                                                    // Загрузка панели со стоянками
            {
                cbParkings.Items.Clear();                                                         //Загрузка схем               
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

        private void SortCameras()
        {
            string c;                                                                              // Сортировка камер
            for (int i = 0; i < _cameras.Count; i++)
            {
                for (int j = 0; j < _cameras.Count; j++)
                {
                    if (_cameras[j].ToString().Length > _cameras[i].ToString().Length)
                    {
                        c = _cameras[i].ToString();
                        _cameras[i] = _cameras[j];
                        _cameras[j] = c;
                    }
                }
            }
        }

        private void LoadCameras(string mapName)
        {
            cbCameras.Items.Clear();                                                         //Загрузка камер
            cbCameras.Text = "";
            _cameras.Clear();

            if (Directory.Exists(@"камеры\" + mapName))
            {
                DirectoryInfo dirCameras = new DirectoryInfo(@"камеры\" + mapName);
                foreach (FileInfo files in dirCameras.GetFiles())
                {
                    _cameras.Add(Path.GetFileNameWithoutExtension(files.Name));
                }
            }
        }

        private void OpenMapWindow(string mapName)
        {
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

            this.WindowState = FormWindowState.Maximized;                                      //Подбор размеров под разрешение монитора
            this.MaximizeBox = true;
            pictureBoxMap.Width = this.Width - 10;
            pictureBoxMap.Height = this.Height - 150;

            cbMaps.Items.Clear();                                                         //Загрузка схем               
            DirectoryInfo dirMaps = new DirectoryInfo("схемы");
            foreach (FileInfo files in dirMaps.GetFiles())
            {
                cbMaps.Items.Add(Path.GetFileNameWithoutExtension(files.Name));

            }
            cbMaps.Text = mapName;

            _isFirstMap = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelStart.Location = new Point(0, 0);
            this.MaximizeBox = false;
            this.Width = 1280;
            this.Height = 720;

            //var jsonFormatter = new DataContractJsonSerializer(typeof(Audio));

            // Создаёт файл settings, если его нет, и записывает туда данные об audio.
            //if (!File.Exists("settings.json"))
            //{
            //    using (var file = new FileStream("settings.json", FileMode.Create))
            //    {
            //        jsonFormatter.WriteObject(file, _audio);

            //        _audio.Play();

            //        return;
            //    }
            //}

            // Открывает файл settings и считывает данные об audio.
            //using (var file = new FileStream("settings.json", FileMode.OpenOrCreate))
            //{
            //    _audio = (Audio)jsonFormatter.ReadObject(file);

            //    if (_audio != null)
            //    {
            //        if (_audio.Enabled == true)
            //        {
            //            _audio = new Audio(@"audio\start.wav");
            //            _audio.Play();
            //        }
            //        else
            //        {
            //            pictureBoxSound.Image = Properties.Resources.mute;
            //        }
            //    }
            //    else
            //    {
            //        _audio = new Audio(@"audio\start.wav");
            //        _audio.Play();
            //    }
            //}

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
            e.Graphics.DrawLine(pen, 0, 74, pictureBoxMap.Width, 74);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
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

            label2.Text = "picW =" + _picWidth;
            label3.Text = "scrollW =" + hScrollBar1.Maximum;
            label4.Text = "valueW =" + hScrollBar1.Value;
            label6.Text = "picH =" + _picHeight;
            label5.Text = "scrollH =" + vScrollBar1.Maximum;
            label1.Text = "valueH =" + vScrollBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            //little = true;
            pictureBoxMap.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = @"камеры\" + _mapName + @"\" + cbCameras.Text + ".jpg";

            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBox.Show("Камера не найдена");
        }

        private void buttonBig_Click(object sender, EventArgs e)
        {
            //big = true;
            pictureBoxMap.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
            pictureBoxMap.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBoxMap.Capture)
            {
                _x += e.X - _lastPoint.X;
                _y += e.Y - _lastPoint.Y;
                _lastPoint = new Point(e.X, e.Y);
                pictureBoxMap.Invalidate();
            }
        }

        private void pictureBoxMinus_Click(object sender, EventArgs e)
        {
            if (_zoom == 100)
            {
                _picWidth = Convert.ToInt32(_picWidth / 2);
                _picHeight = Convert.ToInt32(_picHeight / 2);
                _zoom -= 50;
                _x = Convert.ToInt32(_x / 2);
                _y = Convert.ToInt32(_y / 2);
            }

            else if (_zoom > 100)
            {
                _picWidth = Convert.ToInt32(_picWidth / 1.5);
                _picHeight = Convert.ToInt32(_picHeight / 1.5);
                _zoom -= 25;
                _x = Convert.ToInt32(_x / 1.5);
                _y = Convert.ToInt32(_y / 1.5);
            }

           // x = Convert.ToInt32(x / 2.4);
            //y = Convert.ToInt32(y / 2);
            labelZoom.Text = _zoom + "%";
            pictureBoxMap.Invalidate();
        }

        private void pictureBoxPlus_Click(object sender, EventArgs e)
        {
            if (_zoom == 50)
            {
                _picWidth = Convert.ToInt32(_picWidth * 2);
                _picHeight = Convert.ToInt32(_picHeight * 2);
                _zoom += 50;
                _x = Convert.ToInt32 (_x * 2);
                _y = Convert.ToInt32 (_y * 2);
            }

            else if (_zoom < 200)
            {
                _picWidth = Convert.ToInt32(_picWidth * 1.5);
                _picHeight = Convert.ToInt32(_picHeight * 1.5);
                _zoom += 25;
                _x = Convert.ToInt32(_x * 1.5);
                _y = Convert.ToInt32(_y * 1.5);
            }

            
            labelZoom.Text = _zoom + "%";
            pictureBoxMap.Invalidate();
        }

        private void pictureBoxPreview9_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview9.Text);
        }

        private void pictureBoxPreview1_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview1.Text);
        }

        private void pictureBoxPreview2_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview2.Text);
        }

        private void pictureBoxPreview3_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview3.Text);
        }

        private void pictureBoxPreview4_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview4.Text);
        }

        private void pictureBoxPreview5_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview5.Text);
        }

        private void pictureBoxPreview6_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview6.Text);
        }

        private void pictureBoxPreview7_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview7.Text);
        }

        private void pictureBoxPreview8_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview8.Text);
        }

        private void pictureBoxPreview10_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview10.Text);
        }     

        private void pictureBoxPreview11_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview11.Text);
        }

        private void pictureBoxPreview12_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview12.Text);
        }

        private void pictureBoxPreview13_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview13.Text);
        }

        private void pictureBoxPreview14_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview14.Text);
        }

        private void pictureBoxPreview15_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview15.Text);
        }

        private void pictureBoxPreview16_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview16.Text);
        }

        private void pictureBoxPreview17_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview17.Text);
        }

        private void pictureBoxPreview18_Click(object sender, EventArgs e)
        {
            LoadMap(labelPreview18.Text);
        }

        private void buttonOpenMap_Click(object sender, EventArgs e)
        {
            LoadMap(cbMaps.Text);
        }

        private void panelStart_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }

        private void panelStart_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastPoint.X;
                this.Top += e.Y - _lastPoint.Y;
            }
        }

        private void pictureBoxSound_Click(object sender, EventArgs e)
        {
            //pictureBoxSound.Image = Map.Properties.Resources.mute;
            //sp.Stop();

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

            //var jsonFormatter = new DataContractJsonSerializer(typeof(Audio));

            //using (var file = new FileStream("settings.json", FileMode.Create))
            //{
            //    jsonFormatter.WriteObject(file, _audio);
            //}

            //_audio.Save();
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
            var parking = _parkings.SingleOrDefault(p => p.Number == cbParkings.Text);

            if (parking != null)
            {
                FormParkingCameras formParkingCameras = new FormParkingCameras(parking);
                formParkingCameras.ShowDialog();
            }
            else
            {
                MessageBox.Show("Стоянка не найдена.");
            }
        }

        private void btnAddParking_Click(object sender, EventArgs e)
        {
            //var parking = new Parking("42");
            //var camera1 = new Camera(63);
            //var camera2 = new Camera(64);
            //var camera3 = new Camera(65);
            //var camera4 = new Camera(45);

            //parking.Cameras.Add(camera1, Rating.Low);
            //parking.Cameras.Add(camera2, Rating.Medium);
            //parking.Cameras.Add(camera3, Rating.High);
            //parking.Cameras.Add(camera4, Rating.Medium);

            //_parkings.Add(parking);
            //parking.Save(_parkings);
            //MessageBox.Show("Стоянка успешно добавлена.");   

            //var parking = new Parking("10");
            //var camera1 = new Camera(110);
            //var camera2 = new Camera(119);
            //var camera3 = new Camera(555);
            //var pc1 = new ParkingCamera(parking, camera1, Rating.Low);
            //var pc2 = new ParkingCamera(parking, camera2, Rating.Medium);
            //var pc3 = new ParkingCamera(parking, camera3, Rating.High);

            //_parkings.Add(parking);
            //_ccameras.Add(camera1);
            //_ccameras.Add(camera2);
            //_ccameras.Add(camera3);
            //_parkingCameras.Add(pc1);
            //_parkingCameras.Add(pc2);
            //_parkingCameras.Add(pc3);

            //Saver.Save(_parkings);
            //Saver.Save(_ccameras);
            //Saver.Save(_parkingCameras);

            _ccameras.Clear();
            DirectoryInfo dirCameras = new DirectoryInfo(@"камеры\Охрана периметра");
            foreach (FileInfo files in dirCameras.GetFiles())
            {
                var camera = new Camera(Convert.ToInt32(Path.GetFileNameWithoutExtension(files.Name)));
                _ccameras.Add(camera);
            }

            Saver.Save(_ccameras);
            MessageBox.Show("Сохранено.");
        }

        private void btnOpenParking_Click(object sender, EventArgs e)
        {
            ShowParkingCameras();
        }

        private void imgSettings_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private static void ShowSettingsForm()
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }



        //private void SaveFile<T>(List<T> items)
        //{
        //    var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
        //    var fileName = $"{typeof(T).Name}s.json";

        //    using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        jsonFormatter.WriteObject(fs, items);
        //    }
        //}

        //private List<T> LoadFile<T>()
        //{
        //    var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
        //    var fileName = $"{typeof(T).Name}s.json";

        //    using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        return fs.Length > 0 && jsonFormatter.ReadObject(fs) is List<T> items ? items : new List<T>();
        //    }
        //}


    }
}
