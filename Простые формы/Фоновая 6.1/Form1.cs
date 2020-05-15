using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Фоновая_6._1
{

    public partial class Form1 : Form
    {
        Random random = new Random();
        SoundPlayer soundPlayer = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();

            if (File.Exists(Directory.GetCurrentDirectory() + "\\s.wav"))
            {
                soundPlayer.SoundLocation = Directory.GetCurrentDirectory() + "\\s.wav";
                //..\Music\
                soundPlayer.Load();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void A_Click(object sender, EventArgs e)
        {
            if (B.Location.X - A.Location.X >= 65)
            {
                B.Location = new Point(B.Location.X - 5, B.Location.Y);
                A.Location = new Point(A.Location.X + 5, A.Location.Y);
                ColorCanger();

            }

        }

        private void B_Click(object sender, EventArgs e)
        {
            if (A.Location.X > 5)
            {
                A.Location = new Point(A.Location.X - 5, A.Location.Y);
                ColorCanger();
            }
            if (B.Location.X < Size.Width - 80)
            {
                B.Location = new Point(B.Location.X + 5, B.Location.Y);
                ColorCanger();
            }
        }
        void ColorCanger()
        {
            A.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            B.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            if (File.Exists(Directory.GetCurrentDirectory() + "\\s.wav"))
            {
                soundPlayer.Play();
                ///SystemSounds.Beep.Play();
            }


        }

    }
}
