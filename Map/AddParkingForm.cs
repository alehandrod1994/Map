using System;
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
        public event EventHandler OnAdd;

        public AddParkingForm()
        {
            InitializeComponent();           
        }

        private void btnAddParking_Click(object sender, EventArgs e)
        {
            Close();
            OnAdd?.Invoke(tbParking.Text, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
