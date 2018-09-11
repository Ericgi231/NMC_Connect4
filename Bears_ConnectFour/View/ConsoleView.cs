using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    class ConsoleView
    {
        #region properties

        #endregion

        #region constructors
        public ConsoleView()
        {

        }
        #endregion

        #region methods
        public void PrintGrid(Board board)
        {
            for (int r = 0; r < board.Grid.GetLength(0); r++)
            {
                for (int c = 0; c < board.Grid.GetLength(1); c++)
                {
                    Console.ForegroundColor = board.Grid[r, c].Color;
                    Console.Write(board.Grid[r, c].Icon);
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
