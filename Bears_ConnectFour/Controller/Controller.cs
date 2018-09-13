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
            MainMenu();
        }
        #endregion

        #region methods
        /// <summary>
        /// build the view
        /// </summary>
        private void InstantiateView()
        {
            _view = new ConsoleView();
        }

        /// <summary>
        /// build the config class
        /// </summary>
        private void InstantiateConfig()
        {
            _config = new Config();
        }

        /// <summary>
        /// build the board
        /// </summary>
        private void InstantiateBoard()
        {
            _board = new Board();
        }

        /// <summary>
        /// build the pieces used in the current game
        /// </summary>
        /// <param name="c">the config class to draw piece settings from</param>
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

        
        private void MainMenu()
        {
            Boolean alive = true;
            string title = "Connect 4\nBy: Eric Grant, Kevin Stout, Connor Hansen";
            List<Enums.MenuOption> options = new List<Enums.MenuOption> { Enums.MenuOption.START, Enums.MenuOption.OPTIONS, Enums.MenuOption.EXIT};
            int pointer = 0;
            ConsoleKeyInfo key;
            while (alive)
            {
                _view.PrintMenu(title,options,pointer);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        pointer--;
                        break;
                    case ConsoleKey.DownArrow:
                        pointer++;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        //add code to process menu option selected here
                        break;
                    case ConsoleKey.Escape:
                        alive=false;
                        break;
                    default:
                        break;
                }
            }
        }

        //calls game loop
        //calls options screen
        //calls stats

        //options screen

        //game loop

        //stats

        #endregion

    }
}
