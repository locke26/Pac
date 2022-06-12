using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {

        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, GhostSpeed;
        
        public Form1()
        {
            InitializeComponent();
            
            resetGame();
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            scoreLabel.Text = "Score: " + score;

            if(goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;  
            }
            if(goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;
            }
            if(godown == true && pacman.Top < 360)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }
            if(goup == true && pacman.Top > 45)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }

            if(pacman.Left < -30)
            {
                pacman.Left = 500;
            }
            if(pacman.Left > 500)
            {
                pacman.Left = -30;
            }
            if (redGhost.Left < -30)
            {
                redGhost.Left = 500;
            }
            if (redGhost.Left > 500)
            {
                redGhost.Left = -30;
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                    if((string)x.Tag == "wall")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            
                        }
                    }
                    if((string)x.Tag == "ghost")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            //game over
                        }
                    }    
                }
            }

            redGhost.Left += GhostSpeed;
            redGhost.Top += GhostSpeed;

            if(redGhost.Top > 360)
            {
                redGhost.Left -= GhostSpeed;
                redGhost.Top -= GhostSpeed;
            }
            
            if(score == 30)
            {
                //game over
            }

        }

        private void resetGame()
        {
            scoreLabel.Text = "Score: 0";
            score = 0;
            
            GhostSpeed = 5;
            playerSpeed = 5;

            isGameOver = false;

            pacman.Left = 60;
            pacman.Top = 90;

            redGhost.Left = 230;
            redGhost.Top = 70;

            orangeGhost.Left = 260;
            orangeGhost.Top = 325;

            pinkGhost.Left = 400;
            pinkGhost.Top = 220;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gameTimer.Start();


        }

        private void gameOver(string message) 
        {
        
        }
    }
}
