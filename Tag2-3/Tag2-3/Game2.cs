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
        public Game2(params int[] value) : base(value)
        {
            this.counter = value.Length;
            this.Randomize();

        }
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
