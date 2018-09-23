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
            //check for a tie
            int emptySpaces = Grid.Length;
            foreach (Piece piece in Grid)
            {
                if (piece.Id != -1)
                {
                    emptySpaces--;
                }
            }
            if (emptySpaces == 0)
            {
                return 2;
            }

            while (!win)
            {
                //
                // Check Horizontal
                //
                // reset matching pieces
                matchingPieces = 1;
                // Check right 
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row, col + i].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                // Check left 
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row, col - i].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }





                //
                // Check Vertical
                //
                // reset matching pieces
                matchingPieces = 1;
                // Check up 
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row - i, col].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                }
                // Check down 
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row + i, col].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }





                //
                // Check Diag 1
                //
                // reset matching pieces
                matchingPieces = 1;
                // Check up and right
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row - i, col + i].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                }
                // Check down and left 
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row + i, col - i].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }





                //
                // Check Diag 2
                //
                // reset matching pieces
                matchingPieces = 1;
                // Check up and left
                for (int i = 1; i < counter; i++)
                {
                    // Bound check
                    try
                    {
                        if (Grid[row - i, col - i].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                }
                // Check down and right 
                for (int i = 1; i < counter; i++)
                {
                    try
                    {
                        if (Grid[row + i, col + i].Id == idToMatch)
                        {
                            matchingPieces++;
                            if (matchingPieces >= 4)
                            {
                                win = true;
                                return idToMatch;
                            }
                        }
                        else { break; }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                }
                return -1;
            }


            return idToMatch;   
        }
    }
}
