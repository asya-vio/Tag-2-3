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
        public Game2(params int[] value)
            : base(value)
        {
            this.counter = value.Length;
            this.Randomize();



        }
        //public Game2(int counter)
        //    : base(Game2.getFinishedField(counter))
        //{
        //    this.boardSize = counter;
        //}

        //private static int[] getFinishedField(int size)
        //{
        //    return new int[] {1,2,3,4,5,6,7,8,0};
        //}

        //private void Randomize1()
        //{
        //    int[] perm = Enumerable.Range(0, counter).ToArray();
        //    Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        //    for (int i = counter - 1; i >= 0; i--)
        //    {
        //        int j = r.Next(i + 1);
        //        int temp = perm[j];
        //        perm[j] = perm[i];
        //        perm[i] = temp;
        //    }

        //    int cnt = 0;
        //    for (int i = 0; i < boardSize; i++)
        //    {
        //        for (int j = 0; j < boardSize; j++)
        //        {
        //            this[i, j] = perm[cnt];
        //            ValueLocation[perm[cnt]].I = i;
        //            ValueLocation[perm[cnt]].J = j;
        //            cnt++;
        //        }
        //    }
        //}

        private void Randomize()
        {
            Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int i = 0; i < 100; i++)
            {
                var val = r.Next(counter);
                try
                {
                    Shift(val);
                }
                catch (ArgumentException)
                {
                    continue;
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
