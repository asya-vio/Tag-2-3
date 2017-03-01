﻿using System;
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
        static void Main(string[] args)
        {
            int[] gameArr = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,0,15};
            Game2 g2 = new Game2(16, gameArr);
            PrintBoard(g2);

        }
    }
}
