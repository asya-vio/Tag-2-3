using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag2_3
{
    class Game2 : Game
    {
        private readonly int counter;
        public Game2(int counter, params int[] value) : base (value)
        {
            int[] perm = Enumerable.Range(0, counter).ToArray(); // 0 1 2 ... (n - 1)
            Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int i = counter - 1; i >= 1; i--)
            {
               int j = r.Next(i + 1);
               int temp = perm[j];
               perm[j] = perm[i];
               perm[i] = temp;
            }

            int cnt = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    this[i, j] = perm[cnt];
                    cnt++;
                }
            }
        }

        public bool IsEnd()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (this[i, j] != i * boardSize + (j + 1) && (i != boardSize - 1 || j != boardSize - 1))

                        return false;
                }
            }
            return true;
        }

        
    }
}
