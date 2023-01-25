using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class SuccessfullyExport : Form
    {
        private string _newFileName;
        public SuccessfullyExport(string newFileName)
        {
            InitializeComponent();

            _newFileName = newFileName;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = _newFileName;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = @"/n, /select, " + file;
            process.StartInfo = psi;
            process.Start();

            Close();
        }
    }
}
