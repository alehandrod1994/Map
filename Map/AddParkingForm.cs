using System;
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
