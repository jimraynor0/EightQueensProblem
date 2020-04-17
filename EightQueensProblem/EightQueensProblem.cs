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
        public int size { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Build a problem of x queens, x = size.
        /// </summary>
        /// <param name="size"></param>
        public EightQueensProblem(int size = 8)
        {
            this.size = size;
        }
        #endregion

        /// <summary>
        /// Initial the positions of each queen on the diagonal line from bottom left to top right.
        /// So that each queen has a unique position.
        /// In the process of solving the problem, we don't change a queen's position, but only swap it with another queen.
        /// To make sure no 2 queens are in the same column or in the same row from the beginning.
        /// So that the problem is only to prevent 2 or more queens from diagonally connected.
        /// </summary>555
        public List<int[]> findSolutions() {
            return PlaceQueenOnRow(0, Enumerable.Range(0, size).ToArray());
        }


        #region Private
        /// <summary>
        /// Check if given position can place a queen by checking if any queen in previous rows are diagonally lined up with this position.
        /// </summary>
        /// <param name="row">the y axis value of the position being validated</param>
        /// <param name="col">the x axis value of the position being validated</param>
        /// <returns>        
        /// return true if a queen can be placed at this position (row, col)
        /// </returns>
        private bool isValidPosition(int row, int col, int[] board)
        {
            // check if the first queen with the swapped position
            // diagonally connected with any queen in the columns before her.
            for (int i = 0; i < row; i++)
            {
                if (Math.Abs(col - board[i]) == Math.Abs(row - i))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// An actual swap.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void Swap(int from, int to, int[] board)
        {
            int newPos = board[to];
            board[to] = board[from];
            board[from] = newPos;
        }
        #endregion

        #region Public
        private List<int[]> PlaceQueenOnRow(int row, int[] board)
        {
            List<int[]> result = new List<int[]>();
            // 遍历所有可行的swap, 从swap自己开始到最后一列
            for (int potentialSwapRowNo = row; potentialSwapRowNo < size; potentialSwapRowNo++)
            {
                if (isValidPosition(row, board[potentialSwapRowNo], board))
                {
                    var branchedBoard = (int[]) board.Clone();
                    Swap(row, potentialSwapRowNo, branchedBoard);
                    // 如果x已经是最后一列，则可得到一个解。将解加入全解列表
                    if (row == size - 1)
                        result.Add(branchedBoard);
                    // 否则递归
                    else
                        result = result.Union(PlaceQueenOnRow(row + 1, branchedBoard)).ToList();
                }
            }
            return result;
        }
        #endregion
    }
}
