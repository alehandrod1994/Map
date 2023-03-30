
namespace Map
{
    partial class FormParkingCameras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParkingCameras));
            this.table = new System.Windows.Forms.DataGridView();
            this.tableCameraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableRatingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelParking = new System.Windows.Forms.Label();
            this.labelParkingNumber = new System.Windows.Forms.Label();
            this.imgCameraLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCameraLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableCameraColumn,
            this.tableRatingColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table.DefaultCellStyle = dataGridViewCellStyle3;
            this.table.Location = new System.Drawing.Point(42, 51);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(243, 314);
            this.table.TabIndex = 0;
            this.table.DoubleClick += new System.EventHandler(this.Table_DoubleClick);
            // 
            // tableCameraColumn
            // 
            this.tableCameraColumn.HeaderText = "Камера";
            this.tableCameraColumn.Name = "tableCameraColumn";
            this.tableCameraColumn.ReadOnly = true;
            // 
            // tableRatingColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tableRatingColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableRatingColumn.HeaderText = "Приоритет";
            this.tableRatingColumn.Name = "tableRatingColumn";
            this.tableRatingColumn.ReadOnly = true;
            // 
            // labelParking
            // 
            this.labelParking.AutoSize = true;
            this.labelParking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParking.Location = new System.Drawing.Point(42, 13);
            this.labelParking.Name = "labelParking";
            this.labelParking.Size = new System.Drawing.Size(77, 16);
            this.labelParking.TabIndex = 1;
            this.labelParking.Text = "Стоянка: ";
            // 
            // labelParkingNumber
            // 
            this.labelParkingNumber.AutoSize = true;
            this.labelParkingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParkingNumber.Location = new System.Drawing.Point(125, 13);
            this.labelParkingNumber.Name = "labelParkingNumber";
            this.labelParkingNumber.Size = new System.Drawing.Size(56, 16);
            this.labelParkingNumber.TabIndex = 2;
            this.labelParkingNumber.Text = "Номер";
            // 
            // imgCameraLogo
            // 
            this.imgCameraLogo.Image = global::Map.Properties.Resources.parking_square_icon1;
            this.imgCameraLogo.Location = new System.Drawing.Point(95, 7);
            this.imgCameraLogo.Name = "imgCameraLogo";
            this.imgCameraLogo.Size = new System.Drawing.Size(29, 29);
            this.imgCameraLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCameraLogo.TabIndex = 22;
            this.imgCameraLogo.TabStop = false;
            this.imgCameraLogo.Visible = false;
            // 
            // FormParkingCameras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 402);
            this.Controls.Add(this.imgCameraLogo);
            this.Controls.Add(this.labelParkingNumber);
            this.Controls.Add(this.labelParking);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormParkingCameras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стоянки ВС";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCameraLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Label labelParking;
        private System.Windows.Forms.Label labelParkingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableCameraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableRatingColumn;
        private System.Windows.Forms.PictureBox imgCameraLogo;
    }
}