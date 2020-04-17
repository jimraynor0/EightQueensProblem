using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensProblem
{
    public class EightQueensProblem
    {
        #region Properties
        int size;

        /// <summary>
        /// put a queen in each column, a int represents which row a queen is in.
        /// </summary>
        public int[] pos { get; set; }

        public List<int[]> solutions = new List<int[]>();
        #endregion

        #region Constructor
        /// <summary>
        /// Build a problem of x queens, x = size.
        /// Initial the positions of each queen on the diagonal line from bottom left to top right.
        /// So that each queen has a unique position.
        /// In the process of solving the problem, we don't change a queen's position, but only swap it with another queen.
        /// To make sure no 2 queens are in the same column or in the same row from the beginning.
        /// So that the problem is only to prevent 2 or more queens from diagonally connected.
        /// </summary>
        /// <param name="size"></param>
        public EightQueensProblem(int size = 8)
        {
            this.size = size;
            pos = Enumerable.Range(0, size).ToArray();
            Execute(0);
        }
        #endregion

        #region Private
        /// <summary>
        /// Hypothetically swap the position of a queen with another, or even herself.
        /// </summary>
        /// <param name="from">the index of current queen we are validating</param>
        /// <param name="to">a index of a queen after the previous</param>
        /// <returns>        
        /// return true if after the swap, the current queen has a valid position,
        /// comparing to all queens BEFORE her.
        /// </returns>
        private bool ValidateASwap(int from, int to)
        {
            int newPos = pos[to];

            // check if the first queen with the swapped position
            // diagonally connected with any queen in the columns before her.
            for (int i = 0; i < from; i++)
                if (Math.Abs(newPos - pos[i]) == Math.Abs(from - i))
                    return false;

            return true;
        }

        /// <summary>
        /// An actual swap.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void Swap(int from, int to)
        {
            int newPos = pos[to];

            pos[to] = pos[from];
            pos[from] = newPos;
        }
        #endregion

        #region Public
        public void Execute(int from)
        {
            // 遍历所有可行的swap, 从swap自己开始到最后一列
            for (int target = from; target < size; target++)
            {
                if (ValidateASwap(from, target))
                {
                    Swap(from, target);
                    // 如果x已经是最后一列，则可得到一个解。将解加入全解列表
                    if (from == size - 1)
                        solutions.Add(pos.Clone() as int[]);
                    // 否则递归
                    else
                        Execute(from + 1);
                    // 循环的最后swap回来，以进行下一次循环。
                    Swap(from, target);
                }
            }
        }

        public void PrintSolutions(List<int[]> solutions)
        {
            foreach (var item in solutions)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine("尺寸为" + size + "的棋盘共有 " + solutions.Count + " 个解。");
        }
        #endregion
    }
}
