using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag2_3
{
    class Game3 : Game2
    {
        private List<int> History;

        public Game3(params int[] value)
            : base(value)
        {
            History = new List<int>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            History.Add(value);
        }

        public void RollBack()
        {
            if (History.Count == 0)
            {
                throw new ArgumentException("Вы не сделали еще ни одного шага");
            }
            else
            {
                int lastSwap = History.Count - 1;

                base.Shift(History[lastSwap]);

                History.Remove(History[lastSwap]);
            }
        }

        public void RollBack(int cnt)
        {
            if (cnt > History.Count - 1)
                throw new ArgumentException("Вы не сделали так много шагов!");
            else
            {
                for (int i = 0; i < cnt; i++)
                    RollBack();
            }
        }

        public List<int> CloneHistory()
        {
            return History;
        }
    }
}
