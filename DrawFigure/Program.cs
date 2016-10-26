using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace DrawFigure
{
    class Program
    {
        static void Draw(Board screen, List<Bar> bar, List<Symbols> symbol)
        {
            screen.ClearBoard();
            foreach (Bar b in bar) screen.Add(b);
            foreach (Symbols s in symbol) screen.Add(s); 
            screen.DrawAll();
        }
        enum Data
        {
            zero = 0,

        };

        static void Main(string[] args)
        {
            Board screen = new Board();
            List<Bar> bar = new List<Bar>();
            List<Symbols> symbol = new List<Symbols>();
            bool end = false;
            int choose = (int)Data.zero;
            int dataToConvert;
            int a;

            while (!end)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape) end = true;
                }

                Console.WriteLine("Wybierz  swoj nastroj.\n Jeżeli jestes wesoły wciśnij 1\n Jeżeli jestes smutny to 2 \n Jeżeli chcesz przekonwertować liczby na kod binarny to 3");
                Console.WriteLine("Jeżeli chcesz narysować kwadrat naciśnij 4\n");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Nie podales liczby!");
                }

                switch (choose)
                {
                    case 1:

                        Happy();
                        break;
                    case 2:
                        Sad();

                        break;
                    case 3:
                        Console.WriteLine("Podaj zmienna, którą chcesz przekonwerować\n");
                        try {
                            dataToConvert= Convert.ToInt32(Console.ReadLine());
                            ToConvert(dataToConvert);
                        }
                        catch (Exception){
                            Console.WriteLine("Tylko liczby!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Podaj wymiar boku kwadratu");
                        try
                        {
                            symbol.Clear();
                            a = Convert.ToInt32(Console.ReadLine());
                            Rectangle(a);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Tylko liczby!");
                        }
                        break;


                    default:
                        Console.WriteLine("Wybierz 1,2 lub 3");
                        break;

                }
            

            }
        }
        static void Rectangle(int a)
        {
            Board screen = new Board();
            List<Bar> bar = new List<Bar>();

            List<Symbols> symbol = new List<Symbols>();
            for (int i = 0; i < a; i++)
            {
                symbol.Add(new Symbols(i, a));
                symbol.Add(new Symbols(i, 2 * a));
                symbol.Add(new Symbols(0, i + a));
                symbol.Add(new Symbols(a - 1, i + a));


            }
            Draw(screen,bar, symbol);
        }
        static void Happy()
        {
            Board screen = new Board();
            List<Bar> bar = new List<Bar>();
            List<Symbols> symbol = new List<Symbols>();
            symbol.Clear();
            symbol.Remove(new Symbols(13, 18));
            symbol.Remove(new Symbols(19, 18));
            bar.Add(new Bar(10, 10));
            bar.Add(new Bar(10, 20));
            for (int i = 11; i < 20; i++)
            {
                symbol.Add(new Symbols(9, i));
                symbol.Add(new Symbols(23, i));
                if (i > 13 && i < 19)
                {
                    symbol.Add(new Symbols(i, 17));
                }

            }
            symbol.Add(new Symbols(19, 16));
            symbol.Add(new Symbols(13, 16));
            symbol.Add(new Symbols(13, 14));
            symbol.Add(new Symbols(19, 14));
            Draw(screen, bar, symbol);
        }

        static void Sad()
        {
            Board screen = new Board();
            List<Bar> bar = new List<Bar>();
            List<Symbols> symbol = new List<Symbols>();
            symbol.Clear();
            bar.Add(new Bar(10, 10));
            bar.Add(new Bar(10, 20));
            for (int i = 11; i < 20; i++)
            {
                symbol.Add(new Symbols(9, i));
                symbol.Add(new Symbols(23, i));
                if (i > 13 && i < 19)
                {
                    symbol.Add(new Symbols(i, 17));
                }

            }
            symbol.Add(new Symbols(19, 18));
            symbol.Add(new Symbols(13, 18));
            ;
            symbol.Remove(new Symbols(19, 14));
            symbol.Add(new Symbols(13, 15));
            symbol.Add(new Symbols(19, 15));

            Draw(screen, bar, symbol);
        }
        static void ToConvert(int dataToConvert)
        {
            int[] tab = new int[64];
            if (dataToConvert < 0x3A || dataToConvert >= 0x30)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (dataToConvert % 2 == 0) tab[j] = 0;
                    else tab[j] = 1;
                    dataToConvert = dataToConvert / 2;
                }
                for (int j = 0; j < 8; j++) Console.WriteLine(tab[j]);
            }
            else Console.WriteLine("Tylko liczby ! \n ");
        }
    }
}
