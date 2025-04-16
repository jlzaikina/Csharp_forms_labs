using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        bool up;
        bool down;
        bool up1;
        bool down1;
        int ballx = 7;
        int bally = 7;
        int score = 0;
        int score1 = 0;
        public Form2()
        {
            InitializeComponent();
        }
        int choice;
        public int Choice
        {
            get { return choice; }
            set { choice = value; }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void TimerTick(object sender, EventArgs e)
        {

            label1.Text = "" + score;
            label2.Text = "" + score1;
            ball.Top -= bally;
            ball.Left -= ballx;
            if (choice == 3)
            {
                player1.Visible = true;
                label2.Visible = true;
            }
            //счет
            if (ball.Left < 0)
            {
                ballx = -ballx;
                if (choice == 3)
                {
                    ball.Left = 434;
                    score1++;
                    ballx -= 2;
                }

            }
            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = 434;
                ballx = -ballx;
                score++;
                if (choice == 2 || choice == 3)
                {
                    ballx += 2;
                }
            }
            //контроль мяча
            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                bally = -bally;
            }
            if (choice == 3)
            {
                if (ball.Bounds.IntersectsWith(player2.Bounds) || ball.Bounds.IntersectsWith(player1.Bounds))
                {
                    ballx = -ballx;
                }
            }
            else if (ball.Bounds.IntersectsWith(player2.Bounds))
            {
                ballx = -ballx;
            }
            //движение
            if (up == true && player2.Top > 0)
            {
                player2.Top -= 8;
            }
            if (down == true && player2.Top < 455)
            {
                player2.Top += 8;
            }
            if (up1 == true && player1.Top > 0)
            {
                player1.Top -= 8;
            }
            if (down1 == true && player1.Top < 455)
            {
                player1.Top += 8;
            }
            //конец игры
            if (score > 5 || score1 > 5)
            {
                timer1.Stop();
                label3.Visible = true;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }
            if (e.KeyCode == Keys.W)
            {
                up1 = true;
            }
            if (e.KeyCode == Keys.S)
            {
                down1 = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }
            if (e.KeyCode == Keys.W)
            {
                up1 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down1 = false;
            }
        }
    }
}
