using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag2_3
{
    class Game3 : Game2
    {
        public List<int[]> History= new List<int[]>();

        public Game3(params int[] value) : base(value) 
        { 
            HistoryClear(History); 
        }
        public override void Swap(int val1, int val2 = 0)
        {
            base.Swap(val1,val2);

            var histMas = new int[2];
            histMas[0] = val1;
            histMas[1] = val2;

            History.Add(histMas);
        }

        public void HistoryClear(List<int[]> History)
        {
            for (int i = History.Count; i > 0; i--)
            {
                History.Remove(History[0]);
            }
        }

        public void RollBack()
        {
            var lastSwap = History.Count - 1;
            var val1 = History[lastSwap][0];
            var val2 = History[lastSwap][1];

            base.Swap(val1, val2);

            History.Remove(History[lastSwap]);
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


    }
}
