namespace Map
{
    partial class RemoveParkingForm
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
            this.labelParkingNumber = new System.Windows.Forms.Label();
            this.labelParking = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelParkingNumber
            // 
            this.labelParkingNumber.AutoSize = true;
            this.labelParkingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParkingNumber.Location = new System.Drawing.Point(267, 37);
            this.labelParkingNumber.Name = "labelParkingNumber";
            this.labelParkingNumber.Size = new System.Drawing.Size(41, 13);
            this.labelParkingNumber.TabIndex = 23;
            this.labelParkingNumber.Text = "Номер";
            // 
            // labelParking
            // 
            this.labelParking.AutoSize = true;
            this.labelParking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParking.Location = new System.Drawing.Point(46, 37);
            this.labelParking.Name = "labelParking";
            this.labelParking.Size = new System.Drawing.Size(215, 13);
            this.labelParking.TabIndex = 22;
            this.labelParking.Text = "Вы уверены, что хотите удалить стоянку:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(88, 84);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 23);
            this.btnRemove.TabIndex = 20;
            this.btnRemove.Text = "Да";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // RemoveParkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 133);
            this.Controls.Add(this.labelParkingNumber);
            this.Controls.Add(this.labelParking);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRemove);
            this.Name = "RemoveParkingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveParkingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelParkingNumber;
        private System.Windows.Forms.Label labelParking;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
    }
}