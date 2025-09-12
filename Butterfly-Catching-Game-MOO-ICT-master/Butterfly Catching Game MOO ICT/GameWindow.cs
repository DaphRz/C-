using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Butterfly_Catching_Game_MOO_ICT
{
    public partial class GameWindow : Form
    {
        float timeLeft = 4f;
        int caught = 0;

        int spawnLimit = 30;        // máximo de borboletas na tela
        int spawnCooldown = 30;     // ticks entre spawns
        int spawnTimer = 0;         // contador do cooldown

        int currentLevel = 1;

        List<Butterfly> butterfly_list = new List<Butterfly>();
        Random rand = new Random();

        // DEBUG / TEST
bool useAnimatedGIFs = false; // false desliga animação para teste; deixe true para voltar a animar
Dictionary<Image, Image> imageCache = new Dictionary<Image, Image>();
System.Diagnostics.Stopwatch frameTimer = new System.Diagnostics.Stopwatch();


        Image[] butterfly_images = {
            Properties.Resources._01, Properties.Resources._02,
            Properties.Resources._03, Properties.Resources._04,
            Properties.Resources._05, Properties.Resources._06,
            Properties.Resources._07, Properties.Resources._08,
            Properties.Resources._09, Properties.Resources._10
        };

        public GameWindow()
        {
            InitializeComponent();

            // ativa double buffering e estilos de pintura otimizados
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            // garante um intervalo de timer estável (30ms = ~33 FPS)
            GameTimer.Interval = 30;

            // DEBUG / TEST
            bool useAnimatedGIFs = false; // coloque false para TESTAR sem animação, true para voltar
            Dictionary<Image, Image> imageCache = new Dictionary<Image, Image>();
            System.Diagnostics.Stopwatch frameTimer = new System.Diagnostics.Stopwatch();
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                // desenha o primeiro frame da imagem no bitmap (se img for GIF animado, DrawImage usa o frame atual)
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            frameTimer.Restart();

            lblTime.Text = "Tempo Restante: " + timeLeft.ToString("#") + "s";
            lblCaught.Text = "Borboletas: " + caught;
            timeLeft -= 0.03f;

            if (spawnTimer > 0)
            {
                spawnTimer--;
            }
            else
            {
                if (butterfly_list.Count < spawnLimit)
                {
                    MakeButterfly();
                }
                spawnTimer = spawnCooldown;
            }

            foreach (Butterfly butterfly in butterfly_list)
            {
                // atualiza posição (MoveButterfly usa floats)
                butterfly.MoveButterfly();

                // colisões com as bordas (mantendo dentro dos limites)
                if (butterfly.posX < 0)
                {
                    butterfly.posX = 0;
                    butterfly.speedX = -butterfly.speedX;
                }
                else if (butterfly.posX + butterfly.width > this.ClientSize.Width)
                {
                    butterfly.posX = this.ClientSize.Width - butterfly.width;
                    butterfly.speedX = -butterfly.speedX;
                }

                if (butterfly.posY < 0)
                {
                    butterfly.posY = 0;
                    butterfly.speedY = -butterfly.speedY;
                }
                else if (butterfly.posY + butterfly.height > this.ClientSize.Height - 50)
                {
                    butterfly.posY = this.ClientSize.Height - 50 - butterfly.height;
                    butterfly.speedY = -butterfly.speedY;
                }
            }

            if (timeLeft < 1)
            {
                GameOver();
            }

            frameTimer.Stop();
            // loga no Output do Visual Studio (ou console). 
            System.Diagnostics.Debug.WriteLine($"Frame ms={frameTimer.ElapsedMilliseconds}, sprites={butterfly_list.Count}");

            this.Invalidate();
        }

        private void FormClickEvent(object sender, EventArgs e)
        {
            foreach (Butterfly butterfly in butterfly_list.ToList())
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                if (mouse.X >= (int)butterfly.posX && mouse.Y >= (int)butterfly.posY &&
    mouse.X < (int)butterfly.posX + butterfly.width && mouse.Y < (int)butterfly.posY + butterfly.height)
                {
                    butterfly_list.Remove(butterfly);
                    caught++;
                }
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            if (useAnimatedGIFs)
                ImageAnimator.UpdateFrames();

            foreach (Butterfly butterfly in butterfly_list)
            {
                Image toDraw = butterfly.butterfly_image;
                if (!useAnimatedGIFs && imageCache.ContainsKey(butterfly.butterfly_image))
                    toDraw = imageCache[butterfly.butterfly_image];

                e.Graphics.DrawImage(
                    toDraw,
                    (int)butterfly.posX,
                    (int)butterfly.posY,
                    butterfly.width,
                    butterfly.height
                );
            }
        }

        private void MakeButterfly()
        {
            int i = rand.Next(butterfly_images.Length);

            Butterfly newButterFly = new Butterfly(rand, currentLevel);
            newButterFly.butterfly_image = butterfly_images[i];

            // posição segura dentro da janela
            int maxX = Math.Max(50, this.ClientSize.Width - newButterFly.width - 50);
            int maxY = Math.Max(50, this.ClientSize.Height - newButterFly.height - 50);
            newButterFly.posX = rand.Next(50, maxX);
            newButterFly.posY = rand.Next(50, maxY);

            butterfly_list.Add(newButterFly);

            // NÃO chamar ImageAnimator.Animate aqui (já animado no Load)
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
            spawnTimer = 0;
            spawnLimit = 30;
            spawnCooldown = 10;
            lblTime.Text = "Tempo: 00";
            lblCaught.Text = "Caught: 0";
            currentLevel = 1;

            this.BackgroundImage = Properties.Resources.background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            GameTimer.Start();
        }

        private void NextGame()
        {
            // limpa estado anterior
            this.Invalidate();
            butterfly_list.Clear();
            caught = 0;
            spawnTimer = 0;

            // avança o nível
            currentLevel++;

            switch (currentLevel)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources.background;
                    timeLeft = 10f;
                    spawnLimit = 30;
                    spawnCooldown = 30;  // spawn mais lento
                    break;

                case 2:
                    this.BackgroundImage = Properties.Resources.fase2;
                    timeLeft = 8f;
                    spawnLimit = 12;
                    spawnCooldown = 10;   // spawn mais rápido
                    break;

                /* case 3:
                    this.BackgroundImage = Properties.Resources.fase3;
                    timeLeft = 6f;
                    spawnLimit = 70;
                    spawnCooldown = 3;   // spawn ainda mais rápido
                    break; */

                default:
                    this.BackgroundImage = null;  // sem imagem ou fundo padrão
                    timeLeft = 10f;
                    spawnLimit = 30;
                    spawnCooldown = 10;
                    currentLevel = 1;
                    break;
            }

            // decide quantas borboletas criar ao iniciar a fase
            int initialButterflies;
            if (currentLevel == 2)
                initialButterflies = 1;   // exatamente 1 na fase 2
            else
                initialButterflies = Math.Min(3, spawnLimit); // padrão (ajuste se quiser)

            for (int i = 0; i < initialButterflies; i++)
                MakeButterfly();

            GameTimer.Start();
        }

        private void GameOver()
        {
            GameTimer.Stop();

            if (caught == 1)
            {
                MessageBox.Show("Tempo Esgotado!! Você pegou " + caught + " borboleta.\n\nClique em OK para tentar novamente.", "Game Over");
                RestartGame();
            }
            else
            {
                MessageBox.Show("Tempo Esgotado!! Você pegou " + caught + " borboletas.\n\nClique em OK para ir à Próxima Fase.", "Fase Concluída");
                NextGame();
            }
        }

        private void lblCaught_Click(object sender, EventArgs e)
        {
            // Pode deixar vazio ou remover se não for usar
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            // Teste: torna o loop mais leve enquanto diagnosticamos
            GameTimer.Interval = 60; // 60 ms => ~16 FPS (testar suavidade)
            spawnTimer = spawnCooldown;

            if (useAnimatedGIFs)
            {
                // anima gifs (comportamento anterior)
                foreach (var img in butterfly_images)
                    ImageAnimator.Animate(img, OnFrameChangedHandler);
            }
            else
            {
                // cria uma cópia redimensionada (cache) para desenhar ESTÁTICO — reduz custo de animação
                imageCache.Clear();
                int w = 48, h = 48; // ou use os tamanhos que sua borboleta usa
                foreach (var img in butterfly_images)
                    imageCache[img] = ResizeImage(img, w, h);
            }

            // reduzir carga inicial para testar
            for (int i = 0; i < 2; i++) MakeButterfly();

            if (!GameTimer.Enabled) GameTimer.Start();
        }
    }
}