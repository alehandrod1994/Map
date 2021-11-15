using System;
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

namespace Map
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image img;
        //  bool right = false;
        // bool left = false;
        int x = 0;
        int y = 0;
        int picWidth = 0;
        int picHeight = 0;
        int zoom = 100;
        Point lastPoint;
        float imgWidth;
        float imgHeight;
        float pictureboxWidth;
        float pictureboxHeight;
        int raz = 0;
        SoundPlayer sp = new SoundPlayer(@"audio\start.wav");
        string mapName;

        public void LoadMap(string labelPreview)
        {
            if (raz == 0)
            {
                pictureBoxMap.Visible = true;
                pictureBoxMapLogo.Visible = true;
                pictureBoxCameraLogo.Visible = true;
                comboBoxMaps.Visible = true;
                comboBoxCameras.Visible = true;
                buttonOpenMap.Visible = true;
                buttonOpenCamera.Visible = true;
                pictureBoxMinus.Visible = true;
                pictureBoxPlus.Visible = true;
                labelZoom.Visible = true;
                panelStart.Visible = false;
                sp.Stop();

                this.WindowState = FormWindowState.Maximized;                                      //Подбор размеров под разрешение монитора
                this.MaximizeBox = true;
                pictureBoxMap.Width = this.Width - 10;
                pictureBoxMap.Height = this.Height - 150;

                comboBoxMaps.Text = labelPreview;

                raz = 1;
            }
            this.Cursor = Cursors.WaitCursor;

            comboBoxCameras.Items.Clear();                                                         //Загрузка камер
            comboBoxCameras.Text = "";

            DirectoryInfo dir = new DirectoryInfo(@"камеры\" + labelPreview);

            foreach (FileInfo files in dir.GetFiles())
            {
                comboBoxCameras.Items.Add(Path.GetFileNameWithoutExtension(files.Name));
            }

            string c;                                                                              // Сортировка камер
            for (int i = 0; i < comboBoxCameras.Items.Count; i++)
            {
                for (int j = 0; j < comboBoxCameras.Items.Count; j++)
                {
                    if ((Convert.ToString(comboBoxCameras.Items[j]).Length > Convert.ToString(comboBoxCameras.Items[i]).Length))
                    {
                        c = comboBoxCameras.Items[i].ToString();
                        comboBoxCameras.Items[i] = comboBoxCameras.Items[j];
                        comboBoxCameras.Items[j] = c;
                    }
                }
            }

            if (mapName != labelPreview)                                                           //Загрузка схемы происходит
            {                                                                                      //если выбрана новая схема
                try
                {
                    //if (labelPreview == labelPreview9.Text)
                    //{
                        img = Image.FromFile(@"схемы\" + labelPreview + ".png");
                    //}
                    //else
                    //{
                    //    img = Image.FromFile(@"схемы\" + labelPreview + ".bmp");
                    //}
                }
                catch
                {
                    MessageBox.Show("Схема не найдена");
                }
            }

            pictureboxWidth = pictureBoxMap.Width;
            pictureboxHeight = pictureBoxMap.Height;
            imgWidth = img.Width;
            imgHeight = img.Height;
                                                                      
            picWidth = pictureBoxMap.Width;                                                        //Изменение размеров изображения под размеры холста    
            picHeight = Convert.ToInt32(imgHeight / (imgWidth / pictureboxWidth));
            if (pictureBoxMap.Height < picHeight)
                {
                    picHeight = pictureBoxMap.Height;
                    picWidth = Convert.ToInt32(imgWidth / (imgHeight / pictureboxHeight));
                }
                     
            x = (pictureBoxMap.Width - picWidth) / 2;                                              //По центру экрана
            y = 0;
            labelZoom.Text = "100%";
            zoom = 100;

            mapName = labelPreview;
            pictureBoxMap.Invalidate();
            this.Cursor = Cursors.Default;

            // MessageBox.Show("imgW= " + img.Width + ", imgH= " + img.Height + ", pictureBoxMap.Width=" + pictureBoxMap.Width +
            //  ", pictureBoxMap.Height=" + pictureBoxMap.Height + ", first=" + first + ", newFloatNum=" + newFloatNum);           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelStart.Location = new Point(0, 0);
            this.MaximizeBox = false;
            this.Width = 1280;
            this.Height = 720;
            
            sp.Play();
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
            g.DrawImage(img, x, y, picWidth, picHeight);

            label2.Text = "picW =" + picWidth;
            label3.Text = "scrollW =" + hScrollBar1.Maximum;
            label4.Text = "valueW =" + hScrollBar1.Value;
            label6.Text = "picH =" + picHeight;
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
            string path = @"камеры\" + comboBoxMaps.Text + @"\" + comboBoxCameras.Text + ".jpg";

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
            lastPoint = new Point(e.X, e.Y);
            pictureBoxMap.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBoxMap.Capture)
            {
                x += e.X - lastPoint.X;
                y += e.Y - lastPoint.Y;
                lastPoint = new Point(e.X, e.Y);
                pictureBoxMap.Invalidate();
            }
        }

        private void pictureBoxMinus_Click(object sender, EventArgs e)
        {
            if (zoom == 100)
            {
                picWidth = Convert.ToInt32(picWidth / 2);
                picHeight = Convert.ToInt32(picHeight / 2);
                zoom -= 50;
                x = Convert.ToInt32(x / 2);
                y = Convert.ToInt32(y / 2);
            }

            else if (zoom > 100)
            {
                picWidth = Convert.ToInt32(picWidth / 1.5);
                picHeight = Convert.ToInt32(picHeight / 1.5);
                zoom -= 25;
                x = Convert.ToInt32(x / 1.5);
                y = Convert.ToInt32(y / 1.5);
            }

           // x = Convert.ToInt32(x / 2.4);
            //y = Convert.ToInt32(y / 2);
            labelZoom.Text = zoom + "%";
            pictureBoxMap.Invalidate();
        }

        private void pictureBoxPlus_Click(object sender, EventArgs e)
        {
            if (zoom == 50)
            {
                picWidth = Convert.ToInt32(picWidth * 2);
                picHeight = Convert.ToInt32(picHeight * 2);
                zoom += 50;
                x = Convert.ToInt32 (x * 2);
                y = Convert.ToInt32 (y * 2);
            }

            else if (zoom < 200)
            {
                picWidth = Convert.ToInt32(picWidth * 1.5);
                picHeight = Convert.ToInt32(picHeight * 1.5);
                zoom += 25;
                x = Convert.ToInt32(x * 1.5);
                y = Convert.ToInt32(y * 1.5);
            }

            
            labelZoom.Text = zoom + "%";
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

        private void buttonOpenMap_Click(object sender, EventArgs e)
        {
            LoadMap(comboBoxMaps.Text);
        }

        private void panelStart_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panelStart_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBoxSound_Click(object sender, EventArgs e)
        {
            pictureBoxSound.Image = Map.Properties.Resources.mute;
            sp.Stop();
        }
    }
}
