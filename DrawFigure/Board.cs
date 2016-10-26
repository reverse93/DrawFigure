using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFigure
{
    class Board
    {
        private char[] buffer;


        public Board()
        {
            buffer = new char[80 * 24];
        }

        public void ClearBoard()
        {
            for (int i = 0; i < 80 * 24; i++)
            {
                buffer[i] = ' '; 
            }
            Console.Clear();
        }

        public void Add(ObjectsToDraw draw)
        {
            draw.Draw(buffer);
        }

        public void DrawAll()
        {
            string buff = new string(buffer);
            Console.Write(buff);
        }
    }
}
