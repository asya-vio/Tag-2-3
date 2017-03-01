using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag2_3
{
    class Game2 : Game
    {
        public Game2(params int[] value) : base (value){}

        public bool IsEnd()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (GameBoard[i, j] != i * boardSize + (j + 1) && (i != boardSize - 1 || j != boardSize - 1))

                        return false;
                }
            }
            return true;
        }

        
    }
}
