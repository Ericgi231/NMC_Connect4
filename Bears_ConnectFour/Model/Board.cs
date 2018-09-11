using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    class Board
    {
        public Piece[,] Grid { get; set; }

        public Board()
        {
            InstantiateGrid();
        }

        /// <summary>
        /// fill the grid with blank spaces
        /// </summary>
        private void InstantiateGrid()
        {
            Grid = new Piece[6, 7];
            for (int r = 0; r < Grid.GetLength(0); r++)
            {
                for (int c = 0; c < Grid.GetLength(1); c++)
                {
                    Grid[r, c] = new Piece { Id = -1, Icon=' ',Color=ConsoleColor.White};
                }
            }
        }

        /// <summary>
        /// determine if a player won the game
        /// </summary>
        /// <returns>winning Pieces id</returns>
        public int CheckWin()
        {
            //add code to determine winner

            return 1;
        }
    }
}
