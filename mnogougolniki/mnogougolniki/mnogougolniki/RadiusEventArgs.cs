using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnogougolniki
{
    public class RadiusEventArgs:EventArgs
    {
        int r;
        public RadiusEventArgs(int r) 
        {
            this.r = r;
        }
        public int R 
        {
            set 
            {
                r = value;
            }
            get 
            {
                return r;
            }
        }
    }
    public delegate void RadiusChanged(object sender, RadiusEventArgs e);
}
