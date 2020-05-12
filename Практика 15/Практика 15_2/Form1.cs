using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_15_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double s;
            if (double.TryParse(textBox.Text, out s))
            {
                labelOutput.Text = $"Указанное число миль равно:  {s / 0.6237:F2}";
            }
            else 
            {
                labelOutput.Text = "Введите число";
            }
        }
    }
}
