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
        private Piece[] _pieces { get; set; }
        private Config _config { get; set; }
        private ConsoleView _view { get; set; }

        #endregion

        #region constructors
        public Controller()
        {
            InstantiateView();
            InstantiateConfig();
            InstantiateBoard();
            InstantiatePieces(_config);
            _view.PrintGrid(_board);
            Console.ReadLine();
        }
        #endregion

        #region methods
        private void InstantiateView()
        {
            _view = new ConsoleView();
        }

        private void InstantiateConfig()
        {
            _config = new Config();
        }

        private void InstantiateBoard()
        {
            _board = new Board();
        }

        private void InstantiatePieces(Config c)
        {
            _pieces = new Piece[c.Players];
            for (int i = 0; i < c.Players; i++)
            {
                _pieces[i] = new Piece()
                {
                    Id = i,
                    Color = c.Colors[i],
                    Icon = c.Icons[i],
                    IsComputer = c.IsComputer[i]
                };
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
