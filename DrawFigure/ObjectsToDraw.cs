using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFigure
{
    class ObjectsToDraw
    {
        private char symbol;
        public int positionX { get; set; }
        public int positionY { get; set; }


        public virtual void Draw(char[] tab)
        {
            tab[positionX + positionY * 80] = symbol;
        }

        public void LookCharacter(char lch)
        {
            symbol = lch;
        }
        public virtual void SetPosition(int x, int y)
        {
            try
            {
                if (x > 0 || x < 79 || y > 0 || y < 23)
                {
                    this.positionX = x;
                    this.positionY = y;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Obiekt poza obszarem");

            }
            

        }
    }
}
