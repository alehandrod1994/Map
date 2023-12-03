using System.Windows.Forms;

namespace Map
{
    public partial class AboutForm : Form
    {
        public AboutForm(bool topMost)
        {
            InitializeComponent();
            TopMost = topMost;
        }      
    }
}
