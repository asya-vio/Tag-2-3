using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tag2_3
{
    class Game
    {
        protected readonly int counter;
        public readonly int BoardSize;
        public int[,] GameBoard;
        public Point[] ValueLocation;
        //I - строка, J - столбец
        public Game(params int[] value)
        {
            if (Math.Sqrt(value.Length) % 1 != 0)
            {
                throw new ArgumentException("Количество ячеек не соответствует квадратной игре!");
            }

            this.counter = value.Length;
            int count = 0;
            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    if (value[j] == i)
                    {
                        count++;
                        break;
                    }
                }
            }

            if (count != counter)
            {
                throw new ArgumentException("Введены некорректные данные!");
            }

            this.BoardSize = (int)Math.Sqrt(counter);

            this.GameBoard = new int[BoardSize, BoardSize];

            this.ValueLocation = new Point[counter];

            count = 0;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    GameBoard[i, j] = value[count];
                    ValueLocation[value[count]] = new Point(i, j);
                    count++;
                }
            }
        }

        public int this[int I, int J]
        {
            get
            {
                return GameBoard[I, J];
            }
        }

        public Point GetLocation(int value)
        {
            if (value > counter - 1 || value < 0)
            {
                throw new ArgumentException("Введено неверное значение ячейки!");
            }
            else
            {
                return new Point(ValueLocation[value].I, ValueLocation[value].J);
            }
        }
        protected void Swap(int val1, int val2 = 0)
        {
            int I0 = GetLocation(0).I;
            int J0 = GetLocation(0).J;

            int I = GetLocation(val1).I;
            int J = GetLocation(val1).J;

            GameBoard[I, J] = 0;
            GameBoard[I0, J0] = val1;
            ValueLocation[0].I = I;
            ValueLocation[0].J = J;

            ValueLocation[val1].I = I0;
            ValueLocation[val1].J = J0;
        }
        public bool IsNear(int val1, int val2 = 0)
        {
            int I0 = GetLocation(0).I;
            int J0 = GetLocation(0).J;

            int I = GetLocation(val1).I;
            int J = GetLocation(val1).J;

            return (I == I0 && (J - J0 == 1 || J0 - J == 1) || J == J0 && (I - I0 == 1 || I0 - I == 1));
        }
        public virtual void Shift(int value)
        {
            if (IsNear(value, 0))
                Swap(value, 0);
            else
                throw new ArgumentException("Эту ячейку сдвинуть нельзя!");
        }
        public static Game ReadCSV(string filePath)
        {
            List<int[]> masList = new List<int[]>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var strMas = line.Split(';');
                    int[] intMas = new int[strMas.Length];
                    for (int i = 0; i < strMas.Length; i++)
                    {
                        intMas[i] = int.Parse(strMas[i]);
                    }
                    masList.Add(intMas);
                }
            }
            int[] gameArr = new int[masList.Count * masList.Count];
            int cnt = 0;
            for (int i = 0; i < masList.Count; i++)
            {
                for (int j = 0; j < masList.Count; j++)
                {
                    gameArr[cnt] = masList[i][j];
                    cnt++;
                }
            }

            return new Game(gameArr);

        }

    }
}
