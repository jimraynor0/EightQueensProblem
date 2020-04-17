using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EightQueensProblem;

namespace EightQueensProblem
{
    class Program
    {
        private static void PrintSolutions(List<int[]> solutions, int size)
        {
            foreach (var item in solutions)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine("尺寸为" + size + "的棋盘共有 " + solutions.Count + " 个解。");
        }

        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("请输入棋盘的尺寸数字");
                int problemSize = Convert.ToInt32(Console.ReadLine());
                var engine = new EightQueensProblem(problemSize);
                PrintSolutions(engine.findSolutions(), problemSize);
            }
        }
    }
}
