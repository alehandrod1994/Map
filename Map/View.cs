using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public abstract class View
    {
        public static void EnableTopLevel(Form form, bool enable)
        {
            form.TopMost = enable;
            form.Focus();
        }
    }
}
