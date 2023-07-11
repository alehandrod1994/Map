using System;
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
