﻿namespace Map
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.parkingPage = new System.Windows.Forms.TabPage();
            this.btnDownParking = new System.Windows.Forms.Button();
            this.btnUpParking = new System.Windows.Forms.Button();
            this.progressBarParkings = new System.Windows.Forms.ProgressBar();
            this.btnExportParkings = new System.Windows.Forms.Button();
            this.panelParkingPreview = new System.Windows.Forms.Panel();
            this.labelCameraNumber = new System.Windows.Forms.Label();
            this.btnNextImgParking = new System.Windows.Forms.Button();
            this.btnPreviousImgParking = new System.Windows.Forms.Button();
            this.tableSelectedCameras = new System.Windows.Forms.DataGridView();
            this.tableParkingCamerasCameraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableSelectedCamerasRatingColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.borderParkingPreview = new System.Windows.Forms.Panel();
            this.imgParking = new System.Windows.Forms.PictureBox();
            this.btnCancelParking = new System.Windows.Forms.Button();
            this.btnSaveParking = new System.Windows.Forms.Button();
            this.btnAddCameras = new System.Windows.Forms.Button();
            this.tbParkingCameras = new System.Windows.Forms.TextBox();
            this.lblParkingCameras = new System.Windows.Forms.Label();
            this.tbParkingNumber = new System.Windows.Forms.TextBox();
            this.lblParkingNumber = new System.Windows.Forms.Label();
            this.tbAddParking = new System.Windows.Forms.TextBox();
            this.tvParking = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRemoveParking = new System.Windows.Forms.Button();
            this.btnPrepareAddParking = new System.Windows.Forms.Button();
            this.btnAddParking = new System.Windows.Forms.Button();
            this.labelParking = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.parkingPage.SuspendLayout();
            this.panelParkingPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectedCameras)).BeginInit();
            this.borderParkingPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgParking)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.parkingPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1240, 658);
            this.tabControl.TabIndex = 0;
            // 
            // parkingPage
            // 
            this.parkingPage.Controls.Add(this.btnDownParking);
            this.parkingPage.Controls.Add(this.btnUpParking);
            this.parkingPage.Controls.Add(this.progressBarParkings);
            this.parkingPage.Controls.Add(this.btnExportParkings);
            this.parkingPage.Controls.Add(this.panelParkingPreview);
            this.parkingPage.Controls.Add(this.tbAddParking);
            this.parkingPage.Controls.Add(this.tvParking);
            this.parkingPage.Controls.Add(this.btnRemoveParking);
            this.parkingPage.Controls.Add(this.btnPrepareAddParking);
            this.parkingPage.Controls.Add(this.btnAddParking);
            this.parkingPage.Controls.Add(this.labelParking);
            this.parkingPage.Location = new System.Drawing.Point(4, 22);
            this.parkingPage.Name = "parkingPage";
            this.parkingPage.Padding = new System.Windows.Forms.Padding(3);
            this.parkingPage.Size = new System.Drawing.Size(1232, 632);
            this.parkingPage.TabIndex = 0;
            this.parkingPage.Text = "Стоянки ВС";
            this.parkingPage.UseVisualStyleBackColor = true;
            // 
            // btnDownParking
            // 
            this.btnDownParking.BackgroundImage = global::Map.Properties.Resources.sortDown;
            this.btnDownParking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDownParking.Location = new System.Drawing.Point(345, 131);
            this.btnDownParking.Name = "btnDownParking";
            this.btnDownParking.Size = new System.Drawing.Size(23, 23);
            this.btnDownParking.TabIndex = 28;
            this.btnDownParking.UseVisualStyleBackColor = true;
            this.btnDownParking.Click += new System.EventHandler(this.BtnDownParking_Click);
            // 
            // btnUpParking
            // 
            this.btnUpParking.BackgroundImage = global::Map.Properties.Resources.sortUp;
            this.btnUpParking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpParking.Location = new System.Drawing.Point(345, 102);
            this.btnUpParking.Name = "btnUpParking";
            this.btnUpParking.Size = new System.Drawing.Size(23, 23);
            this.btnUpParking.TabIndex = 27;
            this.btnUpParking.UseVisualStyleBackColor = true;
            this.btnUpParking.Click += new System.EventHandler(this.BtnUpParking_Click);
            // 
            // progressBarParkings
            // 
            this.progressBarParkings.Location = new System.Drawing.Point(21, 50);
            this.progressBarParkings.Name = "progressBarParkings";
            this.progressBarParkings.Size = new System.Drawing.Size(318, 10);
            this.progressBarParkings.TabIndex = 26;
            this.progressBarParkings.Visible = false;
            // 
            // btnExportParkings
            // 
            this.btnExportParkings.Location = new System.Drawing.Point(21, 15);
            this.btnExportParkings.Name = "btnExportParkings";
            this.btnExportParkings.Size = new System.Drawing.Size(149, 29);
            this.btnExportParkings.TabIndex = 25;
            this.btnExportParkings.Text = "Экспортировать в Excel";
            this.btnExportParkings.UseVisualStyleBackColor = true;
            this.btnExportParkings.Click += new System.EventHandler(this.BtnExportParkings_Click);
            // 
            // panelParkingPreview
            // 
            this.panelParkingPreview.Controls.Add(this.labelCameraNumber);
            this.panelParkingPreview.Controls.Add(this.btnNextImgParking);
            this.panelParkingPreview.Controls.Add(this.btnPreviousImgParking);
            this.panelParkingPreview.Controls.Add(this.tableSelectedCameras);
            this.panelParkingPreview.Controls.Add(this.borderParkingPreview);
            this.panelParkingPreview.Controls.Add(this.btnCancelParking);
            this.panelParkingPreview.Controls.Add(this.btnSaveParking);
            this.panelParkingPreview.Controls.Add(this.btnAddCameras);
            this.panelParkingPreview.Controls.Add(this.tbParkingCameras);
            this.panelParkingPreview.Controls.Add(this.lblParkingCameras);
            this.panelParkingPreview.Controls.Add(this.tbParkingNumber);
            this.panelParkingPreview.Controls.Add(this.lblParkingNumber);
            this.panelParkingPreview.Location = new System.Drawing.Point(392, 102);
            this.panelParkingPreview.Name = "panelParkingPreview";
            this.panelParkingPreview.Size = new System.Drawing.Size(822, 513);
            this.panelParkingPreview.TabIndex = 24;
            // 
            // labelCameraNumber
            // 
            this.labelCameraNumber.AutoSize = true;
            this.labelCameraNumber.Location = new System.Drawing.Point(271, 272);
            this.labelCameraNumber.Name = "labelCameraNumber";
            this.labelCameraNumber.Size = new System.Drawing.Size(84, 13);
            this.labelCameraNumber.TabIndex = 34;
            this.labelCameraNumber.Text = "Номер камеры";
            // 
            // btnNextImgParking
            // 
            this.btnNextImgParking.Location = new System.Drawing.Point(514, 268);
            this.btnNextImgParking.Name = "btnNextImgParking";
            this.btnNextImgParking.Size = new System.Drawing.Size(24, 24);
            this.btnNextImgParking.TabIndex = 33;
            this.btnNextImgParking.Text = ">";
            this.btnNextImgParking.UseVisualStyleBackColor = true;
            this.btnNextImgParking.Click += new System.EventHandler(this.btnNextImgParking_Click);
            // 
            // btnPreviousImgParking
            // 
            this.btnPreviousImgParking.Location = new System.Drawing.Point(62, 268);
            this.btnPreviousImgParking.Name = "btnPreviousImgParking";
            this.btnPreviousImgParking.Size = new System.Drawing.Size(24, 24);
            this.btnPreviousImgParking.TabIndex = 32;
            this.btnPreviousImgParking.Text = "<";
            this.btnPreviousImgParking.UseVisualStyleBackColor = true;
            this.btnPreviousImgParking.Click += new System.EventHandler(this.btnPreviousImgParking_Click);
            // 
            // tableSelectedCameras
            // 
            this.tableSelectedCameras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSelectedCameras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableSelectedCameras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSelectedCameras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableParkingCamerasCameraColumn,
            this.tableSelectedCamerasRatingColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableSelectedCameras.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableSelectedCameras.Location = new System.Drawing.Point(554, 3);
            this.tableSelectedCameras.Name = "tableSelectedCameras";
            this.tableSelectedCameras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableSelectedCameras.Size = new System.Drawing.Size(243, 436);
            this.tableSelectedCameras.TabIndex = 31;
            // 
            // tableParkingCamerasCameraColumn
            // 
            this.tableParkingCamerasCameraColumn.HeaderText = "Камера";
            this.tableParkingCamerasCameraColumn.Name = "tableParkingCamerasCameraColumn";
            // 
            // tableSelectedCamerasRatingColumn
            // 
            this.tableSelectedCamerasRatingColumn.HeaderText = "Приоритет";
            this.tableSelectedCamerasRatingColumn.Items.AddRange(new object[] {
            "***",
            "**",
            "*"});
            this.tableSelectedCamerasRatingColumn.Name = "tableSelectedCamerasRatingColumn";
            this.tableSelectedCamerasRatingColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSelectedCamerasRatingColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // borderParkingPreview
            // 
            this.borderParkingPreview.BackColor = System.Drawing.Color.Transparent;
            this.borderParkingPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderParkingPreview.Controls.Add(this.imgParking);
            this.borderParkingPreview.Location = new System.Drawing.Point(62, 3);
            this.borderParkingPreview.Name = "borderParkingPreview";
            this.borderParkingPreview.Size = new System.Drawing.Size(476, 261);
            this.borderParkingPreview.TabIndex = 30;
            // 
            // imgParking
            // 
            this.imgParking.BackColor = System.Drawing.Color.Transparent;
            this.imgParking.Location = new System.Drawing.Point(1, 1);
            this.imgParking.Name = "imgParking";
            this.imgParking.Size = new System.Drawing.Size(472, 257);
            this.imgParking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgParking.TabIndex = 14;
            this.imgParking.TabStop = false;
            this.imgParking.Click += new System.EventHandler(this.ImgParking_Click);
            // 
            // btnCancelParking
            // 
            this.btnCancelParking.Location = new System.Drawing.Point(162, 477);
            this.btnCancelParking.Name = "btnCancelParking";
            this.btnCancelParking.Size = new System.Drawing.Size(75, 23);
            this.btnCancelParking.TabIndex = 29;
            this.btnCancelParking.Text = "Отмена";
            this.btnCancelParking.UseVisualStyleBackColor = true;
            this.btnCancelParking.Click += new System.EventHandler(this.btnCancelParking_Click);
            // 
            // btnSaveParking
            // 
            this.btnSaveParking.Location = new System.Drawing.Point(64, 477);
            this.btnSaveParking.Name = "btnSaveParking";
            this.btnSaveParking.Size = new System.Drawing.Size(75, 23);
            this.btnSaveParking.TabIndex = 28;
            this.btnSaveParking.Text = "Сохранить";
            this.btnSaveParking.UseVisualStyleBackColor = true;
            this.btnSaveParking.Click += new System.EventHandler(this.btnSaveParking_Click);
            // 
            // btnAddCameras
            // 
            this.btnAddCameras.Location = new System.Drawing.Point(514, 343);
            this.btnAddCameras.Name = "btnAddCameras";
            this.btnAddCameras.Size = new System.Drawing.Size(24, 24);
            this.btnAddCameras.TabIndex = 27;
            this.btnAddCameras.Text = "...";
            this.btnAddCameras.UseVisualStyleBackColor = true;
            this.btnAddCameras.Click += new System.EventHandler(this.btnAddCameras_Click);
            // 
            // tbParkingCameras
            // 
            this.tbParkingCameras.Location = new System.Drawing.Point(137, 345);
            this.tbParkingCameras.Name = "tbParkingCameras";
            this.tbParkingCameras.ReadOnly = true;
            this.tbParkingCameras.Size = new System.Drawing.Size(371, 20);
            this.tbParkingCameras.TabIndex = 26;
            // 
            // lblParkingCameras
            // 
            this.lblParkingCameras.AutoSize = true;
            this.lblParkingCameras.Location = new System.Drawing.Point(59, 345);
            this.lblParkingCameras.Name = "lblParkingCameras";
            this.lblParkingCameras.Size = new System.Drawing.Size(51, 13);
            this.lblParkingCameras.TabIndex = 25;
            this.lblParkingCameras.Text = "Камеры:";
            // 
            // tbParkingNumber
            // 
            this.tbParkingNumber.Location = new System.Drawing.Point(137, 306);
            this.tbParkingNumber.Name = "tbParkingNumber";
            this.tbParkingNumber.Size = new System.Drawing.Size(371, 20);
            this.tbParkingNumber.TabIndex = 24;
            // 
            // lblParkingNumber
            // 
            this.lblParkingNumber.AutoSize = true;
            this.lblParkingNumber.Location = new System.Drawing.Point(59, 306);
            this.lblParkingNumber.Name = "lblParkingNumber";
            this.lblParkingNumber.Size = new System.Drawing.Size(44, 13);
            this.lblParkingNumber.TabIndex = 23;
            this.lblParkingNumber.Text = "Номер:";
            // 
            // tbAddParking
            // 
            this.tbAddParking.Location = new System.Drawing.Point(76, 73);
            this.tbAddParking.Name = "tbAddParking";
            this.tbAddParking.Size = new System.Drawing.Size(100, 20);
            this.tbAddParking.TabIndex = 23;
            this.tbAddParking.Visible = false;
            // 
            // tvParking
            // 
            this.tvParking.ImageIndex = 0;
            this.tvParking.ImageList = this.imageList1;
            this.tvParking.Location = new System.Drawing.Point(21, 102);
            this.tvParking.Name = "tvParking";
            this.tvParking.SelectedImageIndex = 0;
            this.tvParking.Size = new System.Drawing.Size(318, 513);
            this.tvParking.TabIndex = 13;
            this.tvParking.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvParking_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "parking_square_icon (2).png");
            // 
            // btnRemoveParking
            // 
            this.btnRemoveParking.Location = new System.Drawing.Point(316, 71);
            this.btnRemoveParking.Name = "btnRemoveParking";
            this.btnRemoveParking.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveParking.TabIndex = 11;
            this.btnRemoveParking.Text = "-";
            this.btnRemoveParking.UseVisualStyleBackColor = true;
            this.btnRemoveParking.Click += new System.EventHandler(this.btnRemoveParking_Click);
            // 
            // btnPrepareAddParking
            // 
            this.btnPrepareAddParking.Location = new System.Drawing.Point(287, 71);
            this.btnPrepareAddParking.Name = "btnPrepareAddParking";
            this.btnPrepareAddParking.Size = new System.Drawing.Size(23, 23);
            this.btnPrepareAddParking.TabIndex = 10;
            this.btnPrepareAddParking.Text = "+";
            this.btnPrepareAddParking.UseVisualStyleBackColor = true;
            this.btnPrepareAddParking.Click += new System.EventHandler(this.btnPrepareAddParking_Click);
            // 
            // btnAddParking
            // 
            this.btnAddParking.Location = new System.Drawing.Point(182, 71);
            this.btnAddParking.Name = "btnAddParking";
            this.btnAddParking.Size = new System.Drawing.Size(75, 23);
            this.btnAddParking.TabIndex = 4;
            this.btnAddParking.Text = "Добавить";
            this.btnAddParking.UseVisualStyleBackColor = true;
            this.btnAddParking.Visible = false;
            this.btnAddParking.Click += new System.EventHandler(this.btnAddParking_Click);
            // 
            // labelParking
            // 
            this.labelParking.AutoSize = true;
            this.labelParking.Location = new System.Drawing.Point(18, 74);
            this.labelParking.Name = "labelParking";
            this.labelParking.Size = new System.Drawing.Size(52, 13);
            this.labelParking.TabIndex = 0;
            this.labelParking.Text = "Стоянки:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.tabControl.ResumeLayout(false);
            this.parkingPage.ResumeLayout(false);
            this.parkingPage.PerformLayout();
            this.panelParkingPreview.ResumeLayout(false);
            this.panelParkingPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectedCameras)).EndInit();
            this.borderParkingPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgParking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage parkingPage;
        private System.Windows.Forms.Label labelParking;
        private System.Windows.Forms.Button btnAddParking;
        private System.Windows.Forms.Button btnRemoveParking;
        private System.Windows.Forms.Button btnPrepareAddParking;
        private System.Windows.Forms.TreeView tvParking;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox tbAddParking;
        private System.Windows.Forms.Panel panelParkingPreview;
        private System.Windows.Forms.Panel borderParkingPreview;
        private System.Windows.Forms.PictureBox imgParking;
        private System.Windows.Forms.Button btnCancelParking;
        private System.Windows.Forms.Button btnSaveParking;
        private System.Windows.Forms.Button btnAddCameras;
        private System.Windows.Forms.TextBox tbParkingCameras;
        private System.Windows.Forms.Label lblParkingCameras;
        private System.Windows.Forms.TextBox tbParkingNumber;
        private System.Windows.Forms.Label lblParkingNumber;
        private System.Windows.Forms.DataGridView tableSelectedCameras;
        private System.Windows.Forms.Button btnNextImgParking;
        private System.Windows.Forms.Button btnPreviousImgParking;
        private System.Windows.Forms.Button btnExportParkings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBarParkings;
        private System.Windows.Forms.Button btnDownParking;
        private System.Windows.Forms.Button btnUpParking;
        private System.Windows.Forms.Label labelCameraNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableParkingCamerasCameraColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn tableSelectedCamerasRatingColumn;
    }
}