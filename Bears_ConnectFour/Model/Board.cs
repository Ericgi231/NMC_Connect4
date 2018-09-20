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

        public Board(int h, int w)
        {
            InstantiateGrid(h, w);
        }

        /// <summary>
        /// fill the Grid with blank spaces
        /// </summary>
        private void InstantiateGrid(int h, int w)
        {
            Piece generic = new Piece { Id = -1, Icon = ' ', Color = ConsoleColor.White};
            Grid = new Piece[h, w];
            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    Grid[r, c] = generic;
                }
            }
        }

        /// <summary>
        /// determine if a player won the game
        /// Function will return an Id of the winning player, or 0 if the move was not a winning move
        /// </summary>
        /// <returns>winning Pieces id</returns>
        public int CheckWin(int row, int col)
        {
            int idToMatch = Grid[row, col].Id;
            int matchingPieces = 1;
            bool win = false;
            int counter = 4;

            // TODO create function to dynamically pull Grid upper/lower bound for bound check

            while (!win)
            {
                // Check Horizontal
                for (int i = 0; i < counter; i++)
                {
                    if (Grid[row, col + i].Id == idToMatch)
                    {
                        matchingPieces++;
                    }
                    else { break; }
                }

                // Check left
                for (int i = 0; i < counter; i++)
                {
                    if (Grid[row, col - i].Id == idToMatch)
                    {
                        matchingPieces++;
                    }
                    else { break; }
                }

                if (matchingPieces >= 4)
                {
                    win = true;
                }


                //
                // Check Vertical
                //


                //
                // Check Diag 1
                //


                //
                // Check Diag 2
                //
            }











            //
            // Check Vertical
            //
            // reset matching pieces
            matchingPieces = 1;


            if (win == true)
            {
                return idToMatch;
            }
            else
            {
                return -1;
            }
        }
    }
}
