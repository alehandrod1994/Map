using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Map
{
    public partial class SuccessfullyExport : Form
    {
        private readonly string _newFileName;
        public SuccessfullyExport(bool topMost, string newFileName)
        {
            InitializeComponent();

            TopMost = topMost;
            _newFileName = newFileName;
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
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
