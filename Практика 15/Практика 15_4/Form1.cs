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
    public class UnHappy
    {
        int attemp;
        int unHappyAttemp;
        public UnHappy()
        {
            attemp = 0;
            unHappyAttemp = 0;
        }
        public int  Attemp
        {
            get { return attemp; }
            set { attemp = value; }
        }
        public int UnHappyAttemp
        {
            get { return unHappyAttemp; }
            set { unHappyAttemp = value; }
        }
    }
    public partial class Form1 : Form
    {
        UnHappy unHappy = new UnHappy();
        public Form1()
        {
            InitializeComponent();
            unHappy = new UnHappy();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            int a;
            Random random = new Random();
            if (int.TryParse(textBox.Text, out a)&& 0<=a&&a<10&& unHappy.Attemp >= 0)
            {//
                resultText.Location = new Point(resultText.Location.X+14,resultText.Location.Y);
                if (a == random.Next(0, 10))
                {
                    resultText.Text = "Результат: число угадано";
                }
                else 
                {
                    unHappy.UnHappyAttemp++;
                    resultText.Text = "Результат: число не угадано";
                }
                unHappy.Attemp++;
            }
            else 
            {
                resultText.Text = "Ошибка: введите число";
            }
            if (unHappy.Attemp >= 10) 
            {
                resultText.Text = "Результат: " + (double)unHappy.UnHappyAttemp / 10;
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
