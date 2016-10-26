using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrawFigure
{
    class Bar : ObjectsToDraw
    {
        private string barSymbol;

        public Bar(int x, int y)
        {
            barSymbol = "ooooooooooooo";
            SetPosition(x, y);

        }
        public override void Draw(char[] tab)
        {
            for (int i = 0; i < barSymbol.Length; i++)
            {
                tab[(positionX + i) + positionY * 80] = barSymbol[i];
            }
        }

        public override void SetPosition(int x, int y)
        {
            try
            {
                if (x >= 0 && (x + barSymbol.Length - 1) < 79 && y >= 0 && y <= 23)
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
