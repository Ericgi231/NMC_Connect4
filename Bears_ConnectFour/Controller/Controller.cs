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
            List<Enums.MenuOption> options = new List<Enums.MenuOption> { Enums.MenuOption.START, Enums.MenuOption.OPTIONS, Enums.MenuOption.STATS, Enums.MenuOption.EXIT};
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
                            OptionsMenu();
	                    }
                        else if(pointer == 2)
                        {
                            StatsMenu();
                        }
                        else if (pointer == 3)
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
            Boolean alive = true;            
            List<Enums.OptionsMenuOption> options = new List<Enums.OptionsMenuOption> {Enums.OptionsMenuOption.BACK, Enums.OptionsMenuOption.P1_COLOR, Enums.OptionsMenuOption.P1_ICON, Enums.OptionsMenuOption.P2_COLOR, Enums.OptionsMenuOption.P2_ICON};
            int pointer = 0;
            ConsoleKeyInfo key;
            while (alive)
            {                
                _view.PrintOptionsMenu(options,pointer, _config);
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
                        if (pointer == 0)
                        {
                            MainMenu();
                        }

                        //changes p1 color
                        if (pointer == 1 && _config.Colors[0] == ConsoleColor.Red)
	                    {
                            _config.EditPlayer(0, ConsoleColor.Blue, _config.Icons[0], false);
	                    }
                        else if (pointer == 1 && _config.Colors[0] == ConsoleColor.Blue)
	                    {
                            _config.EditPlayer(0, ConsoleColor.Green, _config.Icons[0], false);
	                    }
                        else if (pointer == 1 && _config.Colors[0] == ConsoleColor.Green)
	                    {
                            _config.EditPlayer(0, ConsoleColor.Red, _config.Icons[0], false);
	                    }

                        //changes p1 icon
                        if (pointer == 2 && _config.Icons[0] == 'O')
	                    {
                            _config.EditPlayer(0, _config.Colors[0], 'X', false);
	                    }
                        else if (pointer == 2 && _config.Icons[0] == 'X')
	                    {
                            _config.EditPlayer(0,  _config.Colors[0], 'N', false);
	                    }
                        else if (pointer == 2 && _config.Icons[0] == 'N')
	                    {
                            _config.EditPlayer(0, _config.Colors[0], 'O', false);
	                    }

                        //changes p2 color
                        else if (pointer == 3 && _config.Colors[1] == ConsoleColor.Red)
	                    {
                            _config.EditPlayer(1, ConsoleColor.Blue, _config.Icons[1], false);
	                    }
                        else if (pointer == 3 && _config.Colors[1] == ConsoleColor.Blue)
	                    {
                            _config.EditPlayer(1, ConsoleColor.Green, _config.Icons[1], false);
	                    }
                        else if (pointer == 3 && _config.Colors[1] == ConsoleColor.Green)
	                    {
                            _config.EditPlayer(1, ConsoleColor.Red, _config.Icons[1], false);
	                    }

                        //changes p2 icon                                      
                        if (pointer == 4 && _config.Icons[1] == 'O')
	                    {
                            _config.EditPlayer(1, _config.Colors[1], 'X', false);
	                    }
                        else if (pointer == 4 && _config.Icons[1] == 'X')
	                    {
                            _config.EditPlayer(1,  _config.Colors[1], 'N', false);
	                    }
                        else if (pointer == 4 && _config.Icons[1] == 'N')
	                    {
                            _config.EditPlayer(1, _config.Colors[1], 'O', false);
	                    }
                        break;
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        //add code to process menu option selected here
                        if(pointer == 0){
                            MainMenu();
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
        /// display stats Menu
        /// </summary>
        private void StatsMenu(int winnerID = -1)
        {
            Boolean alive = true;
            List<Enums.MenuOption> options = new List<Enums.MenuOption> { Enums.MenuOption.START, Enums.MenuOption.EXIT };
            int pointer = 0;
            ConsoleKeyInfo key;
            _view.PrintStatsMenu(options, pointer);
            while (alive)
            {
                _view.PrintMenu(options, pointer);
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
                        if (pointer == 0)
                        {
                            GameLoop();
                        }
                        else if (pointer == 1)
                        {
                            MainMenu();
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

        //calls game loop
        private void GameLoop(){
            InstantiateBoard();
            bool win = false;
            int winnerId = -1;
            int col = 0;
            int playerTurn = 0;
            ConsoleKeyInfo key;
            //generate players
            Piece[] players = new Piece[_config.Players];
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Id = i;
                players[i].Icon = _config.Icons[i];
                players[i].Color = _config.Colors[i];
                players[i].IsComputer = _config.IsComputer[i];
            }

            //game loop
            while (!win)
	        {
                _view.PrintBoard(_board,col,players[playerTurn]);
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
                        //place piece
                        for (int i = _board.Grid.GetLength(0); i > 0; i--)
                        {
                            if (_board.Grid[i - 1, col].Id == -1)
                            {
                                _board.Grid[i - 1, col] = players[playerTurn];
                                winnerId = _board.CheckWin(i - 1, col);
                                break;
                            }
                        }
                        

                        //alter current turn
                        if (winnerId == -1)
                        {
                            playerTurn++;
                            if (playerTurn > players.Length - 1)
                            {
                                playerTurn = 0;
                            }
                        }
                        else
                        {
                            win = true;
                        }
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

            //when winner
            //go to stats screen with winnerId


        }

        #endregion

    }
}
