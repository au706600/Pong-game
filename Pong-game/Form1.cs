﻿using System;
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

// The following should be implemented: 

// 1) The ball should be bounced, whenever, it hits the "player". Check
// 2) When it exceeds the player, the counter/point of the player should be incremented.
// 3) It should be played against computer and eventually against a player. 
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

        //If the racket hits the ball at the top corner, then it should bounce off towards our top border.
        //If the racket hits the ball at the center, then it should bounce off towards the right, and not up or down at all.
        //If the racket hits the ball at the bottom corner, then it should bounce off towards our bottom border.

        private int move_x = 5; // The speed
        private int move_y = 5; // The speed
  

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
         
            Ball.Left += move_x;
            Ball.Top += move_y;

            if(Ball.Top < 0 || Ball.Bottom > this.ClientSize.Height)
            {
                move_y = -move_y;
            }

            // For now, we use this to make it bounce on the left and right walls. 

            if(Ball.Left < 0 || Ball.Right > this.ClientSize.Width)
            {
                move_x = -move_x;
            }



            /*
            if(Ball.Left < -2)
            {
                Ball.Left = this.ClientSize.Width / 2;
                move_x = -move_x;
            }

            if(Ball.Right > this.ClientSize.Width + 2)
            {
                Ball.Left = this.ClientSize.Width / 2;
                move_x = -move_x;
            }
            
            */

            //https://www.mooict.com/c-tutorials-create-a-simple-pong-game-in-windows-forms-and-visual-studio/

            if (Ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                Ball.Left = pictureBox1.Left - Ball.Width - 5;

                int x = 6;
                int y = 6;

                
                move_x = move_x < 0 ? x : -x;
                move_y = move_y < 0 ? -y : y;

            }

            //Ball.Location = new Point(x_ball, y_ball);
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
