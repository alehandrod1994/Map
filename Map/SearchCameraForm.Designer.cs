
namespace Map
{
    partial class SearchCameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchCameraForm));
            this.imgCameraLogo = new System.Windows.Forms.PictureBox();
            this.btnSearchCamera = new System.Windows.Forms.Button();
            this.tbCamera = new System.Windows.Forms.TextBox();
            this.borderPreview = new System.Windows.Forms.Panel();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvMaps = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCameraLogo)).BeginInit();
            this.borderPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCameraLogo
            // 
            this.imgCameraLogo.Image = global::Map.Properties.Resources.Image0;
            this.imgCameraLogo.Location = new System.Drawing.Point(27, 21);
            this.imgCameraLogo.Name = "imgCameraLogo";
            this.imgCameraLogo.Size = new System.Drawing.Size(46, 29);
            this.imgCameraLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCameraLogo.TabIndex = 21;
            this.imgCameraLogo.TabStop = false;
            // 
            // btnSearchCamera
            // 
            this.btnSearchCamera.Location = new System.Drawing.Point(238, 21);
            this.btnSearchCamera.Name = "btnSearchCamera";
            this.btnSearchCamera.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCamera.TabIndex = 20;
            this.btnSearchCamera.Text = "Поиск";
            this.btnSearchCamera.UseVisualStyleBackColor = true;
            this.btnSearchCamera.Click += new System.EventHandler(this.BtnSearchCamera_Click);
            // 
            // tbCamera
            // 
            this.tbCamera.Location = new System.Drawing.Point(89, 21);
            this.tbCamera.Name = "tbCamera";
            this.tbCamera.Size = new System.Drawing.Size(121, 20);
            this.tbCamera.TabIndex = 1;
            // 
            // borderPreview
            // 
            this.borderPreview.BackColor = System.Drawing.Color.Transparent;
            this.borderPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderPreview.Controls.Add(this.imgPreview);
            this.borderPreview.Location = new System.Drawing.Point(27, 56);
            this.borderPreview.Name = "borderPreview";
            this.borderPreview.Size = new System.Drawing.Size(286, 157);
            this.borderPreview.TabIndex = 31;
            // 
            // imgPreview
            // 
            this.imgPreview.BackColor = System.Drawing.Color.Transparent;
            this.imgPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgPreview.Location = new System.Drawing.Point(1, 1);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(282, 153);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPreview.TabIndex = 14;
            this.imgPreview.TabStop = false;
            this.imgPreview.Click += new System.EventHandler(this.ImgPreview_Click);
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Location = new System.Drawing.Point(29, 471);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(144, 23);
            this.btnOpenMap.TabIndex = 33;
            this.btnOpenMap.Text = "Открыть схему";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.BtnOpenMap_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(236, 471);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "map.png");
            // 
            // tvMaps
            // 
            this.tvMaps.ImageIndex = 0;
            this.tvMaps.ImageList = this.imageList1;
            this.tvMaps.ItemHeight = 20;
            this.tvMaps.Location = new System.Drawing.Point(27, 272);
            this.tvMaps.Name = "tvMaps";
            this.tvMaps.SelectedImageIndex = 0;
            this.tvMaps.Size = new System.Drawing.Size(284, 166);
            this.tvMaps.TabIndex = 35;
            this.tvMaps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMaps_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Схемы:";
            // 
            // SearchCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(349, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvMaps);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpenMap);
            this.Controls.Add(this.borderPreview);
            this.Controls.Add(this.tbCamera);
            this.Controls.Add(this.imgCameraLogo);
            this.Controls.Add(this.btnSearchCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchCameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск камер";
            ((System.ComponentModel.ISupportInitialize)(this.imgCameraLogo)).EndInit();
            this.borderPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCameraLogo;
        private System.Windows.Forms.Button btnSearchCamera;
        private System.Windows.Forms.TextBox tbCamera;
        private System.Windows.Forms.Panel borderPreview;
        private System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView tvMaps;
        private System.Windows.Forms.Label label1;
    }
}