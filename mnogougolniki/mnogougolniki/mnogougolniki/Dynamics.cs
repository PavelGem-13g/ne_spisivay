using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mnogougolniki
{
    public partial class Dynamics : System.Windows.Forms.Form
    {
        public static event TimeChanged TC;
        public Dynamics()
        {
            InitializeComponent();
            trackBar.Value = Form.T;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            TC(this, new TimeEventArgs(trackBar.Value));
        }
    }
}
