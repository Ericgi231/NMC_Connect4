using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    class Controller
    {
        #region properties
        private Board _board { get; set; }
        private List<Piece> _pieces { get; set; }
        private Config _config { get; set; }

        #endregion

        #region constructors
        public Controller()
        {
            InstantiateConfig();
            InstantiateBoard();
            InstantiatePieces(2);
            Console.ReadLine();
        }
        #endregion

        #region methods
        private void InstantiateConfig()
        {
            _config = new Config();
        }

        private void InstantiateBoard()
        {
            _board = new Board();
        }

        private void InstantiatePieces(int players)
        {
            Piece p;
            for (int i = 0; i < players; i++)
            {
                p = new Piece()
                {
                    Id = i

                };
                _pieces.Add(p);
            }
        }

        //main menu 
        //calls game loop
        //calls options screen
        //calls stats

        //options screen

        //game loop

        //stats

        #endregion

    }
}
