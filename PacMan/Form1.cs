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

        int score, playerSpeed, redGhostX, redGhostY, pinkGhostX, pinkGhostY, orangeGhostX, orangeGhostY, lives;

       
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
                pacman.Image = Properties.Resources.up_image;               
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
                pacman.Image = Properties.Resources.down_image;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.left_image;               
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
                pacman.Image = Properties.Resources.right_image;              
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


            //space to restart game
            
            if(e.KeyCode == Keys.Space)
            {
                resetGame();
            }
            
           
            // escape to exit game
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            
            // testing mode
            if (e.KeyCode == Keys.T)
            {
                lives = 1000;
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
            if(goleft == true && pacman.Left > 0)
            {
                pacman.Left -= playerSpeed;
                            }
            if(goright == true && pacman.Left < 470)
            {
                pacman.Left += playerSpeed;
                
                
            }
            if(godown == true && pacman.Top < 400)
            {
                pacman.Top += playerSpeed;
                
            }
            if(goup == true && pacman.Top > 0)
            {
                pacman.Top -= playerSpeed;
            
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
            redGhost.Left += redGhostX;
            redGhost.Top -= redGhostY;

            if (redGhost.Top < 0 || redGhost.Top + redGhost.Height > ClientSize.Height)
            {
                
                redGhostY= -redGhostY;
            }
            if (redGhost.Left < 0 || redGhost.Left + redGhost.Width > ClientSize.Width)
            {
                redGhostX= -redGhostX;
            }

            // pink ghost movement
            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top += pinkGhostY;

            if (pinkGhost.Top < 0 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height)
            {

                pinkGhostY = -pinkGhostY;
            }
            if (pinkGhost.Left < 0 || pinkGhost.Left + pinkGhost.Width > ClientSize.Width)
            {
                pinkGhostX = -pinkGhostX;
            }

            // orange ghost movement
            orangeGhost.Left += orangeGhostX;
            orangeGhost.Top += orangeGhostY;

            if (orangeGhost.Top < 0 || orangeGhost.Top + orangeGhost.Height > ClientSize.Height)
            {

                orangeGhostY = -orangeGhostY;
            }
            if (orangeGhost.Left < 0 || orangeGhost.Left + orangeGhost.Width > ClientSize.Width)
            {
                orangeGhostX = -orangeGhostX;
            }


            // if player touches a ghost remove a life

            if (pacman.Bounds.IntersectsWith(orangeGhost.Bounds))
            {
                pacman.Left = 60;
                pacman.Top = 200;

                redGhost.Left = 300;
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
                pacman.Top = 200;

                redGhost.Left = 300;
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
                pacman.Top = 200;

                redGhost.Left = 300;
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
                scoreLabel.Text = "Score: 30";
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
                livesLabel.Text = "Lives: 0";
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

            redGhostX = 5;
            redGhostY = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            orangeGhostX = 5;
            orangeGhostY = 5;
            playerSpeed = 5;

            pacman.Left = 60;
            pacman.Top = 200;

            redGhost.Left = 300 ;
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
