using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Butterfly_Catching_Game_MOO_ICT
{
    internal class Butterfly
    {
        public Image butterfly_image;
        public int positionX;
        public int positionY;
        public int height;
        public int width;
        public int speedX, speedY, limit, moveLimit;
        Random rand = new Random();

        public Butterfly()
        {
            limit = rand.Next(200,400);
            moveLimit = limit;

            speedX = rand.Next(-5, 5);
            speedY = rand.Next(-5, 5);

            height = 43;
            width = 60;

        }

        public void MoveButterfly()
        {
            moveLimit--;

            if (moveLimit < 0)
            {
                if (speedX < 0)
                {
                    speedX = rand.Next(2, 5);
                }
                else
                {
                    speedX = rand.Next(-5, -2);
                }
                if (speedY < 0)
                {
                    speedY = rand.Next(2, 5);
                }
                else
                {
                    speedY = rand.Next(-5, -2);
                }

                moveLimit = rand.Next(200, limit);
            }
        }
    }
}
