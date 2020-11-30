using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnogougolniki
{
    public class TimeEventArgs:EventArgs
    {
        int t;
        public TimeEventArgs(int t) 
        {
            this.t = t;
        }
        public int T
        {
            set
            {
                t = value;
            }
            get
            {
                return t;
            }
        }
    }
    public delegate void TimeChanged(object sender, TimeEventArgs e);
}
