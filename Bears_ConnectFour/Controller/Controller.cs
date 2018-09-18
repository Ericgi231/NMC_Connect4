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
            SplashScreen();
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
            _board = new Board(_config.BoardHeight, _config.BoardWidth);
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

        /// <summary>
        /// display the splash screen with instructions
        /// </summary>
        private void SplashScreen(){
            _view.PrintSplashScreen();

        }
        
        /// <summary>
        /// display the main menu
        /// </summary>
        private void MainMenu()
        {
            Boolean alive = true;            
            List<Enums.MenuOption> options = new List<Enums.MenuOption> { Enums.MenuOption.START, Enums.MenuOption.OPTIONS, Enums.MenuOption.EXIT};
            int pointer = 0;
            ConsoleKeyInfo key;
            while (alive)
            {                
                _view.PrintMenu(options,pointer);
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
                        if(pointer == 0){
                            GameLoop();
                        }
                        else if(pointer == 1)
	                    {
                            _view.PrintOptionMenu();
	                    }
                        else if(pointer == 2)
                        {
                            _view.PrintExitPrompt();
                        }
                        break;
                    case ConsoleKey.Escape:
                        _view.PrintExitPrompt();
                        break;
                    default:
                        break;
                }
                if (pointer < 0)
                    pointer = options.Count() - 1;
                else if (pointer > options.Count() - 1)
                    pointer = 0;
            }
        }

        /// <summary>
        /// display options menu
        /// </summary>
        private void OptionsMenu()
        {

        }

        /// <summary>
        /// display stats Menu
        /// </summary>
        private void StatsMenu()
        {

        }

        //calls game loop
        private void GameLoop(){
            bool win = false;
            int col = 0;
            int playerTurn = 0;
            ConsoleKeyInfo key;
            //generate players
            Piece[] player = new Piece[_config.Players];
            for (int i = 0; i < player.Length; i++)
            {
                player[i].Id = i;
                player[i].Icon = _config.Icons[i];
                player[i].Color = _config.Colors[i];
                player[i].IsComputer = _config.IsComputer[i];
            }

            //game loop
            while (!win)
	        {
                _view.PrintBoard(_board,col,player[playerTurn]);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        col++;
                        break;
                    case ConsoleKey.LeftArrow:
                        col--;
                        break;
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                    case ConsoleKey.DownArrow:
                        //code for placing piece
                        _board.Grid[6-1, col] = player[playerTurn];
                        break;
                    case ConsoleKey.Escape:
                        _view.PrintExitPrompt();
                        break;
                    default:
                        break;
                }
                if (col < 0)
                    col = _config.BoardWidth-1;
                else if (col > _config.BoardWidth-1)
                    col = 0;
            }
        }

        #endregion

    }
}
