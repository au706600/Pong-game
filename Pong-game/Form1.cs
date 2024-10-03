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
using System.Net.Sockets;
using System.Drawing.Drawing2D;

// The following should be implemented: 

// 1) The ball should be bounced, whenever, it hits the "player". Check
// 2) When it exceeds the player, the counter/point of the player should be incremented. Check
// 3) It should be played against computer and eventually against a player. Check
// 4) To start, the player should be able to move up and down. Check  
// 5) Add boundary so that player shouldn't be able to move off the boundary. Check

// X
// x
// ||

namespace Pong_game
{
    public partial class Form1 : Form
    {
        // X
        // x
        // ||

        private int move_x = 5; // Speed in x-axis
        private int move_y = 5; // Speed in y-axis
        bool isStartingRight = true;


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

            Timer ComputerTimer = new Timer();
            ComputerTimer.Interval = 16;
            ComputerTimer.Tick += computerMovement;
            ComputerTimer.Enabled = true;
            ComputerTimer.Start();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }


        private void ball_Move(object sender, EventArgs e)
        {
                    
            Ball.Left += move_x;
            Ball.Top += move_y;

            int Sc = Int32.Parse(PlayerScore.Text);

            int pc = Int32.Parse(ComputerScore.Text);


            if(Ball.Top < 0 || Ball.Bottom > this.ClientSize.Height)
            {
                move_y = -move_y;
            }

            if (Ball.Left < 0)
            {
                Ball.Left = this.ClientSize.Width / 2;
                isStartingRight = !isStartingRight;
                move_x = isStartingRight ? Math.Abs(move_x) : -Math.Abs(move_x);
                Sc = Sc + 1;
                PlayerScore.Text = Sc.ToString();
            }



            if (Ball.Right > this.ClientSize.Width) 
            {
                Ball.Left = this.ClientSize.Width / 2;
                isStartingRight = !isStartingRight;
                move_x = isStartingRight ? Math.Abs(move_x) : -Math.Abs(move_x);
                pc = pc + 1;
                ComputerScore.Text = pc.ToString();
                             
            }
                
            if(Ball.Bounds.IntersectsWith(computer.Bounds))
            {
                Ball.Left = computer.Right + Ball.Width + 5;
                int x = 7;
                int y = 7;

                int ComputerCenter = computer.Top + (computer.Height / 2);
                int BallCenter = Ball.Top + (Ball.Height / 2);

                int centerRange = 10;

                if(Math.Abs(BallCenter - ComputerCenter) <= centerRange)
                {
                    move_x = 10;
                    move_y = 0;
                }

                else
                {
                    move_x = move_x < 0 ? x : -x;
                    move_y = move_y < 0 ? -y : y;
                }
            }

            //https://www.mooict.com/c-tutorials-create-a-simple-pong-game-in-windows-forms-and-visual-studio/

            if (Ball.Bounds.IntersectsWith(player.Bounds))
            {
                Ball.Left = player.Left - Ball.Width - 5;

                int x = 7;
                int y = 7;

                int playerCenter = player.Top + (player.Height / 2);
                int ballCenter = Ball.Top + (Ball.Height / 2);

                int centerRange = 10;

                if (Math.Abs(ballCenter - playerCenter) <= centerRange)
                {
                    move_x = -10;
                    move_y = 0;
                }

               
                else
                {
                    move_x = move_x < 0 ? x : -x;
                    move_y = move_y < 0 ? -y : y;
                }

            }

            //Ball.Location = new Point(x_ball, y_ball);
            this.Invalidate(); 
        }

        private void computerMovement(object sender, EventArgs e)
        {
            int Computer_y = computer.Location.Y;
            int Computer_x = computer.Location.X;

            if(Ball.Location.X <= this.ClientSize.Width / 2)
            {
                                
                if(Ball.Location.Y > computer.Top + (computer.Height / 2))
                {
                    if (Computer_y + computer.Height <= this.ClientSize.Height)
                    {
                        Computer_y += 5;
                    }
                }

                else if(Ball.Location.Y < computer.Top + (computer.Height/2))
                {
                    if (Computer_y >= 0)
                    {
                        Computer_y -= 5;
                    }
                }

            }

            computer.Location = new Point(Computer_x, Computer_y);
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int y = player.Location.Y;
            int x = player.Location.X;
            int Y_Size = Form1.ActiveForm.Height; 
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if(y + player.Height <= this.ClientSize.Height)
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
   
            player.Location = new Point(x, y);
            this.Invalidate();
        }

       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
