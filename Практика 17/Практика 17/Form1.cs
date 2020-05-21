using System;
using System.Windows.Forms;
using System.Media;

namespace Практика_17
{
    public partial class Form1 : Form
    {
        //uint binarCodeDec;
        SoundPlayer music = new SoundPlayer();
        
        public Form1()
        {
            InitializeComponent();
            music.Stream = Properties.Resources.s;
        }

        private void Do_Click(object sender, EventArgs e)
        {//Convert.ToInt32(Convert.ToString(Convert.ToInt32(binarCode.Text), 2));Convert.ToInt32(binarCode.Text);
         /*            uint temp=0;
                     if(uint.TryParse(binarCode.Text,out temp))
                     {
                         int checker = 0;
         *//*                for (int i = 0; i < temp.ToString().Length; i++)
                         {

                         }*//*
                         //int temps = Convert.ToInt32(Convert.ToString(Convert.ToInt32(binarCode.Text), 16));
                         //binarCodeString = Convert.ToUInt32(Convert.ToString(temp, 16));
                         //binarCodeDec = Binar.ConvertBinToDec(Convert.ToUInt32(binarCode.Text));
                     }*/
            Voider();
        }

        private void _8_CheckedChanged(object sender, EventArgs e)
        {//Convert.ToString(binarCodeDec, 8);
            uint temp = 0;
            if (uint.TryParse(binarCode.Text, out temp))
            {
                result.Text = Binar.ConvertBinToOct(Convert.ToUInt32(binarCode.Text)).ToString();
            }
        }

        private void _10_CheckedChanged(object sender, EventArgs e)
        {//Convert.ToString(binarCodeDec, 10);
            uint temp = 0;
            if (uint.TryParse(binarCode.Text, out temp))
            {
            result.Text = Binar.ConvertBinToDec(Convert.ToUInt32(binarCode.Text)).ToString();

            }
        }

        private void _16_CheckedChanged(object sender, EventArgs e)
        {
            uint temp = 0;
            if (uint.TryParse(binarCode.Text, out temp))
            {
                result.Text = Binar.ConvertBinToDec(Convert.ToUInt32(binarCode.Text)).ToString("X");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            music.Play();
            System.Threading.Thread.Sleep(200);
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BinarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
/*            if (binarCode.Text.Length == 0) binarCode.Text = "0";
            Voider();
           */
        }
        void Voider()
        {
            if (binarCode.Text.Length == 0) binarCode.Text = "0";
            if (binarCode.Text.Length > 10) binarCode.Text = binarCode.Text.Remove(binarCode.Text.Length - 1, 1);
            if (_8.Checked) result.Text = Binar.ConvertBinToOct(Convert.ToUInt32(binarCode.Text)).ToString();
            if (_10.Checked) result.Text = Binar.ConvertBinToDec(Convert.ToUInt32(binarCode.Text)).ToString();
            if (_16.Checked) result.Text = Binar.ConvertBinToDec(Convert.ToUInt32(binarCode.Text)).ToString("X");
            music.Play();
        }

        private void BinarCode_KeyDown(object sender, KeyEventArgs e)
        {
/*            if (binarCode.Text.Length == 0) binarCode.Text = "0";
            if (binarCode.Text.Length > 10) binarCode.Text = binarCode.Text.Remove(binarCode.Text.Length - 1, 1);*/
            Voider();
        }
    }
}
