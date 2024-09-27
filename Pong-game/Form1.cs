using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows;
using Point = System.Drawing.Point;

// The following should be implemented: 

// 1) The ball should be bounced, whenever, it hits the "player". 
// 2) When it exceeds the player, the counter/point of the player should be incremented.
// 3) It should be played against computer and eventually against a player. 
// 4) To start, the player should be able to move up and down. Check  
// 5) Add boundary so that player shouldn't be able to move off the boundary. Check

namespace Pong_game
{
    public partial class Form1 : Form
    {
        // X
        // x
        // ||

        private int move_x = 5;
        private int move_y = 5;


        public Form1()
        {
            InitializeComponent();
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            // https://stackoverflow.com/questions/1142828/add-timer-to-a-windows-forms-application
            Timer ballTimer = new Timer();
            ballTimer.Interval = 16; 
            ballTimer.Tick += ball_Move;
            ballTimer.Enabled = true;
            ballTimer.Start();
        }


       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }


        private void ball_Move(object sender, EventArgs e)
        {
            int x_ball = Ball.Location.X;
            int y_ball = Ball.Location.Y;

            x_ball += move_x;

            if(x_ball < 0 || x_ball + Ball.Width > this.ClientSize.Width)
            {
                move_x = -move_x;   
            }

            y_ball += move_y;

            if(y_ball < 0 || y_ball + Ball.Height > this.ClientSize.Height)
            {
                move_y = -move_y;
            }

            if(Ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
               
                int playerCenter = pictureBox1.Location.Y + (pictureBox1.Height / 2);
                int ballCenter = y_ball + (Ball.Height / 2);

                if(playerCenter > ballCenter)
                {
                    move_y = -Math.Abs(move_y);
                }

                else if(playerCenter < ballCenter)
                {
                    move_y = Math.Abs(move_y);
                }
                move_x = -move_x;
            }

            Ball.Location = new Point(x_ball, y_ball);
            this.Invalidate();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int y = pictureBox1.Location.Y;
            int x = pictureBox1.Location.X;
            int Y_Size = Form1.ActiveForm.Height; 
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if(y + pictureBox1.Height <= this.ClientSize.Height)
                    {
                        y += 5;
                    }
                    break;

                case Keys.Up:
                    if(y >= 0)
                    {
                        y -= 5;
                    }
                    break;
            }
   
            pictureBox1.Location = new Point(x, y);
            this.Invalidate();
        } 

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
