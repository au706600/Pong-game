using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// The following should be implemented: 

// 1) The ball should be bounced, whenever, it hits the "players". 
// 2) When it exceeds the player, the counter/point of the player should be incremented.
// 3) It should be played against computer and eventually against a player. 
// 4) To start, the player should be able to move up and down. Check
// 5) Add boundary so that player shouldn't be able to move off the boundary. Check

namespace Pong_game
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.KeyUp += new KeyEventHandler(Form1_KeyUp); 
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        // The right side player
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
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
