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
        public int CheckWin(int pieceRow, int pieceCol)
        {
            int idToMatch = Grid[pieceRow, pieceCol].Id;
            int matchingPieces = 1;
            bool win = false;

            // TODO create function to dynamically pull Grid upper/lower bound for bound check


            //
            // Next check up/right (increment row and increment column)
            //
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow + counter;
                var col = pieceCol + counter;

                // Bound check
                if (row > Grid.GetLength(0) -1 || col > Grid.GetLength(1) - 1) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }

            //
            // Check down/right - (decrement row and increment col)
            //
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow - counter;
                var col = pieceCol + counter;

                // Make sure we stay within our board
                if (row > Grid.GetLength(0) || col > Grid.GetLength(1)) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }

            //
            // Check down/left - (decrement row and decrement column)
            //
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow - counter;
                var col = pieceCol - counter;

                // Make sure we stay within our board
                if (row > Grid.GetLength(0) || col < 0) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }

            //
            // Next check up/left (increment row and decrement column)
            //
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow + counter;
                var col = pieceCol - counter;

                // Make sure we stay within our board
                if (row < 0 || col < 0) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }

            //
            // Check Up
            //
            for (int counter = 0; counter < 4; counter++)
            {
                var row = pieceRow - counter;
                var col = pieceCol;

                // Bound check
                if (row < 0) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }

            }

            //
            // Check Down
            //
            for (int counter = 0; counter < 4; counter++)
            {
                var row = pieceRow + counter;
                var col = pieceCol;

                // Bound check
                if (row > Grid.GetLength(0) - 1) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }

            //
            // Check Left
            //
            for (int counter = 0; counter < 4; counter++)
            {
                var row = pieceRow;
                var col = pieceCol - counter;

                // Bound check
                if (col < 0) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }

            //
            // Check Right
            //
            for (int counter = 0; counter < 4; counter++)
            {
                var row = pieceRow;
                var col = pieceCol + counter;

                // Bound check
                if (col > Grid.GetLength(1)) { break; }

                // Check for a match
                if (Grid[row, col].Id == idToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return idToMatch;
                }
                else { break; }
            }


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
