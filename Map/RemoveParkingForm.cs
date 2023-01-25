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
        public event EventHandler OnRemove; 

        public RemoveParkingForm(Parking parking)
        {
            InitializeComponent();

            labelParkingNumber.Text = parking.Number;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Close();
            OnRemove?.Invoke(this, null);           
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
