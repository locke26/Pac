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

        bool goup, godown, goleft, goright;
       
        int score, playerSpeed, redGhostSpeed, pinkGhostSpeed, orangeGhostSpeed, lives;


        public Form1()
        {
            InitializeComponent();

            winLabel.Visible = true;
            winLabel.Text = "Welcome to Pac-Man! Space to play Esc to exit";



            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = false;
                }
            }

        }

        // key down for movement
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

        // key up for movement
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
            if (e.KeyCode == Keys.Space)
            {
                resetGame();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            
        }

        // game timer
        private void mainGameTimer(object sender, EventArgs e)
        {
            // update score
            scoreLabel.Text = "Score: " + score;
            // update lives
            livesLabel.Text = "Lives: " + lives;

            // movement for pacman
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

            // teleport to other side of the screen
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
            if (orangeGhost.Left < -30)
            {
                orangeGhost.Left = 500;
            }
            if (orangeGhost.Left > 500)
            {
                orangeGhost.Left = -30;
            }
            if (pinkGhost.Left < -30)
            {
                pinkGhost.Left = 500;
            }
            if (pinkGhost.Left > 500)
            {
                pinkGhost.Left = -30;
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {    // check if player is touching a coin
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
                    
                    
                }
            }


            // red ghost movement
            redGhost.Left -= redGhostSpeed;
            redGhost.Top -= redGhostSpeed;

            if(redGhost.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            if (redGhost.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            // pink ghost movement
            pinkGhost.Left += pinkGhostSpeed;
            pinkGhost.Top -= pinkGhostSpeed;

            if (pinkGhost.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                pinkGhostSpeed = -pinkGhostSpeed;
            }

            if (pinkGhost.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                pinkGhostSpeed = -pinkGhostSpeed;
            }

            // orange ghost movement
            orangeGhost.Left += orangeGhostSpeed;
            orangeGhost.Top += orangeGhostSpeed;

            if (orangeGhost.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                orangeGhostSpeed = -orangeGhostSpeed;
            }

            if (orangeGhost.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                orangeGhostSpeed = -orangeGhostSpeed;
            }

           // if player touches a ghost remove a life
            
            if(pacman.Bounds.IntersectsWith(orangeGhost.Bounds))
            {
                pacman.Left = 60;
                pacman.Top = 90;

                redGhost.Left = 190;
                redGhost.Top = 70;

                orangeGhost.Left = 100;
                orangeGhost.Top = 325;

                pinkGhost.Left = 300;
                pinkGhost.Top = 220;

                lives -= 1;
            }
            
            if(pacman.Bounds.IntersectsWith(pinkGhost.Bounds))
            {
                pacman.Left = 60;
                pacman.Top = 90;

                redGhost.Left = 190;
                redGhost.Top = 70;

                orangeGhost.Left = 100;
                orangeGhost.Top = 325;

                pinkGhost.Left = 300;
                pinkGhost.Top = 220;

                lives -= 1;
            }
            
            
            if(pacman.Bounds.IntersectsWith(redGhost.Bounds))
            {
                pacman.Left = 60;
                pacman.Top = 90;

                redGhost.Left = 190;
                redGhost.Top = 70;

                orangeGhost.Left = 100;
                orangeGhost.Top = 325;

                pinkGhost.Left = 300;
                pinkGhost.Top = 220;

                lives -= 1;
            }
            
            // victory screen
            if (score == 30)
            {
                winLabel.Visible = true;
                winLabel.Text = "You win! Space to restart Esc to exit";
                pacmanImage.Visible = true;
               
                
                foreach (Control x in this.Controls)
                {
                    if(x is PictureBox)
                    {
                        x.Visible = false;
                    }
                }

                gameTimer.Stop();
                
            }

            // restart game if lives = 0
            if (lives == 0)
            {
                winLabel.Visible = true;
                winLabel.Text = "Game over! Space to restart Esc to exit";
                pacmanImage.Visible = true;


                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox)
                    {
                        x.Visible = false;
                    }
                }

                gameTimer.Stop();
            }

        }
        
        
        
        // restart game
        private void resetGame()
        {

            pacmanImage.Visible = false;

            winLabel.Visible = false;

            scoreLabel.Text = "Score: 0";
            score = 0;

            lives = 3;

            redGhostSpeed = 5;
            pinkGhostSpeed = 5;
            orangeGhostSpeed = 5;
            playerSpeed = 8;

            pacman.Left = 60;
            pacman.Top = 90;

            redGhost.Left = 190;
            redGhost.Top = 70;

            orangeGhost.Left = 100;
            orangeGhost.Top = 325;

            pinkGhost.Left = 300;
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

    }
}
