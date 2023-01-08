namespace Map
{
    partial class AddCamerasForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCameras = new System.Windows.Forms.GroupBox();
            this.labelParkingNumber = new System.Windows.Forms.Label();
            this.labelParking = new System.Windows.Forms.Label();
            this.tbFindParkingCameras = new System.Windows.Forms.TextBox();
            this.labelFindParkingCameras = new System.Windows.Forms.Label();
            this.tbFindInAllCameras = new System.Windows.Forms.TextBox();
            this.labelFindInAllCameras = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMoveCameraToLeftTable = new System.Windows.Forms.Button();
            this.btnMoveCameraToRightTable = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableSelectedCameras = new System.Windows.Forms.DataGridView();
            this.tableParkingCamerasCameraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableSelectedCamerasRatingColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableAllCameras = new System.Windows.Forms.DataGridView();
            this.tableCamerasCameraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectedCameras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableAllCameras)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCameras
            // 
            this.gbCameras.Controls.Add(this.labelParkingNumber);
            this.gbCameras.Controls.Add(this.labelParking);
            this.gbCameras.Controls.Add(this.tbFindParkingCameras);
            this.gbCameras.Controls.Add(this.labelFindParkingCameras);
            this.gbCameras.Controls.Add(this.tbFindInAllCameras);
            this.gbCameras.Controls.Add(this.labelFindInAllCameras);
            this.gbCameras.Controls.Add(this.label2);
            this.gbCameras.Controls.Add(this.label1);
            this.gbCameras.Controls.Add(this.btnMoveCameraToLeftTable);
            this.gbCameras.Controls.Add(this.btnMoveCameraToRightTable);
            this.gbCameras.Controls.Add(this.btnCancel);
            this.gbCameras.Controls.Add(this.btnSave);
            this.gbCameras.Controls.Add(this.tableSelectedCameras);
            this.gbCameras.Controls.Add(this.tableAllCameras);
            this.gbCameras.Location = new System.Drawing.Point(22, 12);
            this.gbCameras.Name = "gbCameras";
            this.gbCameras.Size = new System.Drawing.Size(565, 341);
            this.gbCameras.TabIndex = 10;
            this.gbCameras.TabStop = false;
            this.gbCameras.Text = "Камеры";
            // 
            // labelParkingNumber
            // 
            this.labelParkingNumber.AutoSize = true;
            this.labelParkingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParkingNumber.Location = new System.Drawing.Point(369, 16);
            this.labelParkingNumber.Name = "labelParkingNumber";
            this.labelParkingNumber.Size = new System.Drawing.Size(56, 16);
            this.labelParkingNumber.TabIndex = 19;
            this.labelParkingNumber.Text = "Номер";
            // 
            // labelParking
            // 
            this.labelParking.AutoSize = true;
            this.labelParking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParking.Location = new System.Drawing.Point(286, 16);
            this.labelParking.Name = "labelParking";
            this.labelParking.Size = new System.Drawing.Size(77, 16);
            this.labelParking.TabIndex = 18;
            this.labelParking.Text = "Стоянка: ";
            // 
            // tbFindParkingCameras
            // 
            this.tbFindParkingCameras.Location = new System.Drawing.Point(380, 256);
            this.tbFindParkingCameras.Name = "tbFindParkingCameras";
            this.tbFindParkingCameras.Size = new System.Drawing.Size(100, 20);
            this.tbFindParkingCameras.TabIndex = 16;
            // 
            // labelFindParkingCameras
            // 
            this.labelFindParkingCameras.AutoSize = true;
            this.labelFindParkingCameras.Location = new System.Drawing.Point(292, 259);
            this.labelFindParkingCameras.Name = "labelFindParkingCameras";
            this.labelFindParkingCameras.Size = new System.Drawing.Size(41, 13);
            this.labelFindParkingCameras.TabIndex = 17;
            this.labelFindParkingCameras.Text = "Найти:";
            // 
            // tbFindInAllCameras
            // 
            this.tbFindInAllCameras.Location = new System.Drawing.Point(100, 256);
            this.tbFindInAllCameras.Name = "tbFindInAllCameras";
            this.tbFindInAllCameras.Size = new System.Drawing.Size(100, 20);
            this.tbFindInAllCameras.TabIndex = 10;
            // 
            // labelFindInAllCameras
            // 
            this.labelFindInAllCameras.AutoSize = true;
            this.labelFindInAllCameras.Location = new System.Drawing.Point(12, 249);
            this.labelFindInAllCameras.Name = "labelFindInAllCameras";
            this.labelFindInAllCameras.Size = new System.Drawing.Size(41, 13);
            this.labelFindInAllCameras.TabIndex = 10;
            this.labelFindInAllCameras.Text = "Найти:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Выбранные камеры:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Все камеры:";
            // 
            // btnMoveCameraToLeftTable
            // 
            this.btnMoveCameraToLeftTable.Location = new System.Drawing.Point(206, 136);
            this.btnMoveCameraToLeftTable.Name = "btnMoveCameraToLeftTable";
            this.btnMoveCameraToLeftTable.Size = new System.Drawing.Size(75, 23);
            this.btnMoveCameraToLeftTable.TabIndex = 14;
            this.btnMoveCameraToLeftTable.Text = "<=";
            this.btnMoveCameraToLeftTable.UseVisualStyleBackColor = true;
            this.btnMoveCameraToLeftTable.Click += new System.EventHandler(this.btnMoveCameraToLeftTable_Click);
            // 
            // btnMoveCameraToRightTable
            // 
            this.btnMoveCameraToRightTable.Location = new System.Drawing.Point(206, 82);
            this.btnMoveCameraToRightTable.Name = "btnMoveCameraToRightTable";
            this.btnMoveCameraToRightTable.Size = new System.Drawing.Size(75, 23);
            this.btnMoveCameraToRightTable.TabIndex = 13;
            this.btnMoveCameraToRightTable.Text = "=>";
            this.btnMoveCameraToRightTable.UseVisualStyleBackColor = true;
            this.btnMoveCameraToRightTable.Click += new System.EventHandler(this.btnMoveCameraToRightTable_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(457, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(346, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "ОК";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.tableSelectedCameras.Location = new System.Drawing.Point(289, 52);
            this.tableSelectedCameras.Name = "tableSelectedCameras";
            this.tableSelectedCameras.Size = new System.Drawing.Size(243, 194);
            this.tableSelectedCameras.TabIndex = 10;
            // 
            // tableParkingCamerasCameraColumn
            // 
            this.tableParkingCamerasCameraColumn.HeaderText = "Камера";
            this.tableParkingCamerasCameraColumn.Name = "tableParkingCamerasCameraColumn";
            // 
            // tableSelectedCamerasRatingColumn
            // 
            this.tableSelectedCamerasRatingColumn.HeaderText = "Рейтинг";
            this.tableSelectedCamerasRatingColumn.Items.AddRange(new object[] {
            "***",
            "**",
            "*"});
            this.tableSelectedCamerasRatingColumn.Name = "tableSelectedCamerasRatingColumn";
            this.tableSelectedCamerasRatingColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSelectedCamerasRatingColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tableAllCameras
            // 
            this.tableAllCameras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableAllCameras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableAllCameras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableAllCameras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableCamerasCameraColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableAllCameras.DefaultCellStyle = dataGridViewCellStyle4;
            this.tableAllCameras.Location = new System.Drawing.Point(15, 52);
            this.tableAllCameras.Name = "tableAllCameras";
            this.tableAllCameras.ReadOnly = true;
            this.tableAllCameras.Size = new System.Drawing.Size(185, 194);
            this.tableAllCameras.TabIndex = 9;
            // 
            // tableCamerasCameraColumn
            // 
            this.tableCamerasCameraColumn.HeaderText = "Камера";
            this.tableCamerasCameraColumn.Name = "tableCamerasCameraColumn";
            this.tableCamerasCameraColumn.ReadOnly = true;
            // 
            // AddCamerasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 377);
            this.Controls.Add(this.gbCameras);
            this.Name = "AddCamerasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCamerasForm";
            this.gbCameras.ResumeLayout(false);
            this.gbCameras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectedCameras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableAllCameras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCameras;
        private System.Windows.Forms.TextBox tbFindParkingCameras;
        private System.Windows.Forms.Label labelFindParkingCameras;
        private System.Windows.Forms.TextBox tbFindInAllCameras;
        private System.Windows.Forms.Label labelFindInAllCameras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMoveCameraToLeftTable;
        private System.Windows.Forms.Button btnMoveCameraToRightTable;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView tableSelectedCameras;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableParkingCamerasCameraColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn tableSelectedCamerasRatingColumn;
        private System.Windows.Forms.DataGridView tableAllCameras;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableCamerasCameraColumn;
        private System.Windows.Forms.Label labelParkingNumber;
        private System.Windows.Forms.Label labelParking;
    }
}