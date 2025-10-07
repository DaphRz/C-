using System;
using System.Drawing;

namespace Butterfly_Catching_Game_MOO_ICT
{
    internal class Butterfly
    {
        public Image butterfly_image;

        // tamanhos e velocidade
        public int width;
        public int height;
        public float speedX;
        public float speedY;

        // posições internas em float (movimento suave)
        public float posX;
        public float posY;

        // compatibilidade com código que use positionX/positionY
        public int positionX { get => (int)posX; set => posX = value; }
        public int positionY { get => (int)posY; set => posY = value; }

        // construtor: usa o Random compartilhado passado pelo GameWindow
        public Butterfly(Random rnd, int difficultyLevel = 1)
        {
            // tamanhos por nível
            width = 60;
            height = 43;
            if (difficultyLevel >= 2) { width = 50; height = 35; }
            if (difficultyLevel >= 3) { width = 40; height = 30; }

            // define velocidade base (float), com pequena variação por nível
            double baseMin, baseRange;
            switch (difficultyLevel)
            {
                case 1:
                    baseMin = 0.35; baseRange = 3.5;   // lento
                    break;
                case 2:
                    baseMin = 3.0; baseRange = 3.0;    // moderado 
                    break;
                /* case 3:
                    baseMin = 1.0; baseRange = 1.2;    // mais rápido
                    break; */
                default:
                    baseMin = 0.35; baseRange = 0.6;
                    break;
            }

            float sx = (float)(rnd.NextDouble() * baseRange + baseMin);
            float sy = (float)(rnd.NextDouble() * baseRange + baseMin);

            // aplica sinal aleatório
            speedX = (rnd.Next(0, 2) == 0) ? sx : -sx;
            speedY = (rnd.Next(0, 2) == 0) ? sy : -sy;

            posX = 0;
            posY = 0;
        }

        // Move atualiza as posições (utilize sempre isso no loop do timer)
        public void MoveButterfly()
        {
            posX += speedX;
            posY += speedY;
        }
    }
}