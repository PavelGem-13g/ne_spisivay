using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_15_4
{
    public partial class Form1 : Form
    {
        int attemp;
        int unHappyAttemp;
        public Form1()
        {
            InitializeComponent();
            attemp = 0;
            unHappyAttemp = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            int a;
            Random random = new Random();
            if (int.TryParse(textBox.Text, out a)&& 0<=a&&a<10&&attemp>=0)
            {//
                resultText.Location = new Point(resultText.Location.X+14,resultText.Location.Y);
                if (a == random.Next(0, 10))
                {
                    resultText.Text = "Результат: число угадано";
                }
                else 
                {
                    unHappyAttemp++;
                    resultText.Text = "Результат: число не угадано";
                }
                attemp++;
            }
            else 
            {
                resultText.Text = "Ошибка: введите число";
            }
            if (attemp >= 10) 
            {
                resultText.Text = "Результат: " + (double)unHappyAttemp / 10;
            }
        }

        private void Button_LocationChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void resultText_Click(object sender, EventArgs e)
        {

        }
    }
}
