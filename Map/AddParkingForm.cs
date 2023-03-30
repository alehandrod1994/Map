﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class AddParkingForm : Form
    {      
        public AddParkingForm()
        {
            InitializeComponent();

            tbParking.Select();
        }

        public Parking Parking { get; private set; }

        private void BtnAddParking_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbParking.Text))
            {
                Parking = new Parking(tbParking.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
