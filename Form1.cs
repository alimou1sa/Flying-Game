using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_7_Flying_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lb_over.Visible = false;
        }

        bool up, down;
        int Score;

        void game_result()
        {
            foreach(Control x in this .Controls)
            {
                if(x is PictureBox && x.Tag=="pilar")
                {
                    foreach(Control j in this .Controls)
                    {
                        if(j is PictureBox && j.Tag=="enemy")
                        {
                            if (plyer1.Bounds.IntersectsWith(x.Bounds) ||
                                (plyer1.Bounds.IntersectsWith(j.Bounds)))
                            {
                                lb_over.Visible = true;
                                timer1.Stop();
                            }


                        }
                    }
                }
            }
        }

        void Smoke()
        {
            PictureBox smoke = new PictureBox();
            smoke.BackColor = System.Drawing.Color.Gold;
            smoke.Width = 3;
            smoke.Height = 3;
            smoke.Top = plyer1.Top + plyer1.Height/2 ;
            smoke.Left = plyer1.Left + plyer1.Width - 35;
            smoke.Tag = "smoke";
            this.Controls.Add(smoke);


            foreach(Control x in this.Controls)
            {
                if(x is PictureBox&& x.Tag=="smoke")
                {
                    x.Left -= 10;
                    if (x.Left < 0)
                    {
                        this.Controls.Remove(x);
                        x.Dispose();

                    }
                }
            }

        }

        void enemy_move()
        {
            Random rdn = new Random();
            int x;
            foreach(Control j in this.Controls)
            {
                if(j is PictureBox && j.Tag=="enemy")
                {
                    j.Left -=5;
                    if (j.Left < 0)
                    {

                        x = rdn.Next(80, 300);
                        j.Location = new Point(800, x);
                        Score++;
                        lbl_score.Text = "Score : " + Score;
                    }
                }
            }


        }

        void Plyer_move()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox &&  x.Tag=="pilar")
                {
                    x.Left-= 5;

                    if (x.Left < -250)
                    {
                        x.Left = 700;
                    }
                }
            }

        }


        void Pilar_move()
        {
            if(up==true)
            {
                plyer1.Top -= 5;
            }
            if(down==true)
            {
                plyer1.Top += 5;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.Up:
                    up = true;
                    break;
                case Keys.Down:
                    down = true;
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    up = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Plyer_move();
            Pilar_move();
            enemy_move();
            Smoke();
            game_result();
        }


    }
}
