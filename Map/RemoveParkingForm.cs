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
    public partial class RemoveParkingForm : Form
    {
        public RemoveParkingForm(Parking parking)
        {
            InitializeComponent();

            labelParkingNumber.Text = parking.Number;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
