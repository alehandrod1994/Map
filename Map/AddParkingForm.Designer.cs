namespace Map
{
    partial class AddParkingForm
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
            this.labelParking = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddParking = new System.Windows.Forms.Button();
            this.tbParking = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelParking
            // 
            this.labelParking.AutoSize = true;
            this.labelParking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParking.Location = new System.Drawing.Point(109, 31);
            this.labelParking.Name = "labelParking";
            this.labelParking.Size = new System.Drawing.Size(131, 13);
            this.labelParking.TabIndex = 26;
            this.labelParking.Text = "Введите номер стоянки:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnAddParking
            // 
            this.btnAddParking.Location = new System.Drawing.Point(83, 98);
            this.btnAddParking.Name = "btnAddParking";
            this.btnAddParking.Size = new System.Drawing.Size(82, 23);
            this.btnAddParking.TabIndex = 24;
            this.btnAddParking.Text = "Сохранить";
            this.btnAddParking.UseVisualStyleBackColor = true;
            this.btnAddParking.Click += new System.EventHandler(this.BtnAddParking_Click);
            // 
            // tbParking
            // 
            this.tbParking.Location = new System.Drawing.Point(44, 57);
            this.tbParking.Name = "tbParking";
            this.tbParking.Size = new System.Drawing.Size(259, 20);
            this.tbParking.TabIndex = 28;
            // 
            // AddParkingForm
            // 
            this.AcceptButton = this.btnAddParking;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 133);
            this.Controls.Add(this.tbParking);
            this.Controls.Add(this.labelParking);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddParking);
            this.Name = "AddParkingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddParkingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelParking;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddParking;
        private System.Windows.Forms.TextBox tbParking;
    }
}