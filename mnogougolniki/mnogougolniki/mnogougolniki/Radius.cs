using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mnogougolniki.UndoRedo;

namespace mnogougolniki
{
    public partial class Radius : System.Windows.Forms.Form
    {
        public static event RadiusChanged RC;
        public int oldValue;
        public Radius()
        {
            InitializeComponent();
            trackBar.Value = MnogugolnikiShapeLibrary.Shape.R;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            RC(this, new RadiusEventArgs(trackBar.Value));
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            Form.instance.ClearRedoStack();
            Form.instance.undo.Push(new ChangeRadius(trackBar.Value - oldValue));
        }

        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            oldValue = trackBar.Value;
        }
        public void ChangeRadius(int delta) 
        {
            trackBar.Value += delta;
            Refresh();
        }
    }
}
