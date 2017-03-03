using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag2_3
{
    class Program
    {
        public static void PrintBoard(Game g)
        {
            for (int i = 0; i < g.boardSize; i++)
            {
                for (int j = 0; j < g.boardSize; j++)
                {
                    if (g[i, j] / 10 > 0) Console.Write("{0} ", g[i, j]);
                    else Console.Write("{0}  ", g[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintHistory(Game3 g)
        {
            for (int i = 0; i < g.History.Count; i++)
                Console.WriteLine(String.Format("Шаг {0} сдвиг фишки {1} и {2} ",i, g.History[i][0], g.History[i][1]));
        }

        static void Main(string[] args)
        {
            int[] gameArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15 };
            //Game2 game2 = null;

            //try
            //{
            //    game2 = new Game2(gameArr);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine("{0} ", ex);
            //}

            //int step = 0;
            //while (!game2.IsEnd())
            //{
            //    Console.Clear();
            //    PrintBoard(game2);
            //    Console.WriteLine("Ведите номер сдвигаемой фишки");
            //    int value = int.Parse(Console.ReadLine());

            //    try
            //    {
            //        game2.Shift(value);
            //        step++;
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine("{0}", ex.Message);
            //        Console.ReadLine();
            //    }

            //}

            //Console.Clear();
            //PrintBoard(game2);

            //Console.WriteLine("Игра завершена за {0} шагов", step);

            //Console.WriteLine("Координаты фишки 15 I = {0}, J = {1} \n", game2.GetLocation(15).I, game2.GetLocation(15).J);

            //Console.ReadLine();

            Game3 game3 = null;

            try
            {
                game3 = new Game3(gameArr);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0} ", ex);
            }

            int step = 0;
            while (!game3.IsEnd())
            {
                Console.Clear();
                PrintBoard(game3);
                Console.WriteLine("Ведите номер сдвигаемой фишки");
                int value = int.Parse(Console.ReadLine());

                try
                {
                    game3.Shift(value);
                    step++;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                    Console.ReadLine();
                }

            }

            Console.Clear();
            PrintBoard(game3);

            Console.WriteLine("Игра завершена за {0} шагов", step);

            Console.WriteLine("Координаты фишки 15 I = {0}, J = {1} \n", game3.GetLocation(15).I, game3.GetLocation(15).J);

            PrintHistory(game3);

            Console.ReadLine(); 


        }
    }
}
