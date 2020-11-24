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
    public partial class Radius : Form
    {
        public static event RadiusChanged RC;
        public Radius()
        {
            InitializeComponent();
            trackBar.Value = Shape.R;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            RC(this, new RadiusEventArgs(trackBar.Value));
        }
    }
}
