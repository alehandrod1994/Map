
namespace Map
{
    partial class FlashbackForm
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
            this.cbRange = new System.Windows.Forms.ComboBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.imgMusic = new System.Windows.Forms.PictureBox();
            this.imgScreen = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRange
            // 
            this.cbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRange.FormattingEnabled = true;
            this.cbRange.Items.AddRange(new object[] {
            "За всё время",
            "Текущий"});
            this.cbRange.Location = new System.Drawing.Point(66, 48);
            this.cbRange.Name = "cbRange";
            this.cbRange.Size = new System.Drawing.Size(121, 21);
            this.cbRange.TabIndex = 2;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.Location = new System.Drawing.Point(307, 325);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(133, 43);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // imgMusic
            // 
            this.imgMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgMusic.Image = global::Map.Properties.Resources.note;
            this.imgMusic.Location = new System.Drawing.Point(679, 36);
            this.imgMusic.Name = "imgMusic";
            this.imgMusic.Size = new System.Drawing.Size(24, 24);
            this.imgMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMusic.TabIndex = 20;
            this.imgMusic.TabStop = false;
            // 
            // imgScreen
            // 
            this.imgScreen.Location = new System.Drawing.Point(12, 85);
            this.imgScreen.Name = "imgScreen";
            this.imgScreen.Size = new System.Drawing.Size(691, 216);
            this.imgScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgScreen.TabIndex = 1;
            this.imgScreen.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Map.Properties.Resources.Рамка;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(715, 396);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Период:";
            // 
            // FlashbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 396);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgMusic);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.cbRange);
            this.Controls.Add(this.imgScreen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FlashbackForm";
            this.Text = "FlashbackForm";
            ((System.ComponentModel.ISupportInitialize)(this.imgMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox imgScreen;
        private System.Windows.Forms.ComboBox cbRange;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox imgMusic;
        private System.Windows.Forms.Label label1;
    }
}