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

        private void SplashScreen(){
            _view.PrintSplashScreen();

        }
        
  
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
                        alive=false;
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
            bool win = false;
            int loopCount = 0;

            while (!win)
	        {
                _view.DrawLoop(loopCount);

                loopCount++;
	        }
            
        }
        //calls options screen
        //calls stats

        //options screen

        //game loop

        //stats

        #endregion

    }
}
