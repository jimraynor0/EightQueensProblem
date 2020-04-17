using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensProblem
{
    class Program
    {


        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("请输入棋盘的尺寸数字");
                int problemSize = Convert.ToInt32(Console.ReadLine());
                var engine = new EightQueensProblem.EightQueensProblem(problemSize);
                PrintSolutions(engine.findSolutions(), problemSize);
            }
        }
    }
}
