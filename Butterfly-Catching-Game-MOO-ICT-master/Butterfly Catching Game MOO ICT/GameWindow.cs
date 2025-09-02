using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Butterfly_Catching_Game_MOO_ICT
{
    public partial class GameWindow : Form
    {
        float timeLeft = 4f;
        int caught = 0;
        int spawnTime = 0;
        int spawnLimit = 30;
        int currentLevel = 1;

        List<Butterfly> butterfly_list = new List<Butterfly>();
        Random rand = new Random();

        Image[] butterfly_images = { Properties.Resources._01, Properties.Resources._02, Properties.Resources._03, Properties.Resources._04, Properties.Resources._05, Properties.Resources._06, Properties.Resources._07, Properties.Resources._08, Properties.Resources._09, Properties.Resources._10 };



        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            lblTime.Text = "Tempo Restante: " + timeLeft.ToString("#") + ".s";
            lblCaught.Text = "Borboletas: " + caught;
            timeLeft -= 0.03f;

            if (butterfly_list.Count < spawnLimit)
            {
                spawnTime--;

                if (spawnTime < 1)
                {
                    MakeButterfly();
                    spawnTime = spawnLimit;
                }
            }

            foreach (Butterfly butterfly in butterfly_list)
            {
                butterfly.MoveButterfly();

                butterfly.positionX += butterfly.speedX;

                if (butterfly.positionX < 0 || butterfly.positionX + butterfly.width > this.ClientSize.Width)
                {
                    butterfly.speedX = -butterfly.speedX;

                    if (butterfly.positionX < 0)
                    {
                        butterfly.positionX = butterfly.positionX + 10;
                    }
                    else if (butterfly.positionX + butterfly.width > this.ClientSize.Width)
                    {
                        butterfly.positionX = butterfly.positionX - 10;
                    }
                }

                butterfly.positionY += butterfly.speedY;

                if (butterfly.positionY < 0 || butterfly.positionY + butterfly.height > this.ClientSize.Height - 50)
                {
                    butterfly.speedY = -butterfly.speedY;

                    if (butterfly.positionY < 0)
                    {
                        butterfly.positionY = butterfly.positionY + 10;
                    }
                    else if (butterfly.positionY + butterfly.height > this.ClientSize.Height - 50)
                    {
                        butterfly.positionY = butterfly.positionY - 10;
                    }
                }


            }


            if (timeLeft < 1)
            {
                GameOver();
            }

            this.Invalidate();

        }

        private void FormClickEvent(object sender, EventArgs e)
        {
            foreach (Butterfly butterfly in butterfly_list.ToList())
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                if (mouse.X >= butterfly.positionX && mouse.Y >= butterfly.positionY && mouse.X < butterfly.positionX + butterfly.width && mouse.Y < butterfly.positionY + butterfly.height)
                {
                    butterfly_list.Remove(butterfly);
                    caught++;
                }
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();

            foreach (Butterfly butterfly in butterfly_list)
            {
                e.Graphics.DrawImage(butterfly.butterfly_image, butterfly.positionX, butterfly.positionY, butterfly.width, butterfly.height);
            }

        }

        private void MakeButterfly()
        {
            int i = rand.Next(butterfly_images.Length);

            Butterfly newButterFly = new Butterfly();
            newButterFly.butterfly_image = butterfly_images[i];
            newButterFly.positionX = rand.Next(50, this.ClientSize.Width - 200);
            newButterFly.positionY = rand.Next(50, this.ClientSize.Height - 200);
            butterfly_list.Add(newButterFly);
            ImageAnimator.Animate(newButterFly.butterfly_image, this.OnFrameChangedHandler);
        }

        private void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void RestartGame()
        {
            this.Invalidate();
            butterfly_list.Clear();
            caught = 0;
            timeLeft = 4f;
            spawnTime = 0;
            lblTime.Text = "Tempo: 00";
            lblCaught.Text = "Caught: 0";
            currentLevel = 1;

            this.BackgroundImage = Properties.Resources.background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            GameTimer.Start();
        }

        private void NextGame()
        {
            this.Invalidate();
            butterfly_list.Clear();
            caught = 0;
            timeLeft = 10f; // ou outro tempo maior para fases seguintes
            spawnTime = 0;
            lblTime.Text = "Tempo: 00";
            lblCaught.Text = "Caught: 0";

            currentLevel++;

            // muda o plano de fundo dependendo da fase

            switch (currentLevel)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources.background;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.fase2;
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources.fase3;
                    break;
                default:
                    this.BackgroundImage = null;  // sem imagem ou fundo padrão
                    break;
            }

            this.BackgroundImageLayout = ImageLayout.Stretch;

            GameTimer.Start();
        }

        private void GameOver()
        {
            GameTimer.Stop();

            if (caught == 1)
            {
                MessageBox.Show("Tempo Esgotado!!  Você pegou " + caught + " borboleta.\n\nClique em OK para tentar novamente.", "Game Over ");
                RestartGame();
            }
            else
            {
                MessageBox.Show("Tempo Esgotado!!  Você pegou " + caught + " borboletas.\n\nClique em OK para ir à Próxima Fase.", "Fase Concluída ");
                NextGame();
            }
        }

        private void lblCaught_Click(object sender, EventArgs e)
        {

        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
