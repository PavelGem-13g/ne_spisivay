using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UserNameAsk_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (userName.Text.Length > 0)
            {
                resultText.Text = "Hello, " + userName.Text+"!";
            }
            else 
            {
                resultText.Text = "Hello, world!";
            }
        }
    }
}
