using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    class ConsoleView
    {
        const string TITLE = "~ Connect 4 ~\nBy: Eric Grant, Kevin Stout, Connor Hansen";

        #region properties
        

        #endregion

        #region constructors
        public ConsoleView()
        {
            Console.Title = ConsoleConfig.windowTitle;
            Console.SetWindowSize(ConsoleConfig.windowWidth, ConsoleConfig.windowHeight);
            Console.SetBufferSize(ConsoleConfig.windowWidth, ConsoleConfig.windowHeight);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
        }
        #endregion

        #region methods        
        
        public void PrintSplashScreen(){
            Console.WriteLine(TITLE);
            Console.WriteLine();
            Console.WriteLine("This application is designed to allow two players to play a game of connect 4.\n\nThe rules are the standard rules for the game with each player taking a turn.");
            Console.WriteLine();
            PrintContinuePrompt();
        }

        public void PrintContinuePrompt(){
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            
            
        }

        public void PrintExitPrompt(){
            Console.Clear();
            Console.WriteLine(TITLE);
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("Thank you for playing. Press any key to exit");
            Console.ReadKey();

            System.Environment.Exit(1);
            
        }

        public void PrintHelp()
        {
            Console.Clear();
            Console.WriteLine("Left and right arrows to move piece.");
            Console.WriteLine("Down arrow to place piece.");
            Console.WriteLine("");
            Console.WriteLine("The goal is to get four of you pieces in a row in any direction");
            Console.WriteLine("Players take turns one after another. Each player should choose \ntheir piece and only controll that one.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the game.");
            Console.ReadKey();
        }

        public void PrintBoard(Board board, int col, Piece player, bool win = false)
        {
            Console.Clear();
            Console.WriteLine(" H for help");

            //current piece location
            Console.SetCursorPosition((ConsoleConfig.windowWidth / 2) - board.Grid.GetLength(1), Console.CursorTop);
            for (int i = 0; i < board.Grid.GetLength(1); i++)
            {
                
                if (i == col)
                {
                    
                    Console.ForegroundColor = player.Color;
                    Console.Write(" " + player.Icon);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            //the game board
            
            for (int r = 0; r < board.Grid.GetLength(0); r++)
            {
                Console.SetCursorPosition((ConsoleConfig.windowWidth / 2) - board.Grid.GetLength(1), Console.CursorTop);
                for (int c = 0; c < board.Grid.GetLength(1); c++)
                {
                    if (c == 0)
                    {
                        Console.Write("|");
                    }
                    Console.ForegroundColor = board.Grid[r, c].Color;
                    Console.Write(board.Grid[r, c].Icon);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition((ConsoleConfig.windowWidth / 2) - board.Grid.GetLength(1), Console.CursorTop);
            for (int i = 0; i < board.Grid.GetLength(1)*2+1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            //extra info
            Console.SetCursorPosition((ConsoleConfig.windowWidth / 2) - board.Grid.GetLength(1), Console.CursorTop);
            if (!win)
            {
                Console.WriteLine("Player " + (player.Id + 1) + "'s turn.");
            }
            else
            {
                Console.WriteLine("Player " + (player.Id + 1) + " wins!");
                Thread.Sleep(2000);
            }
        }

        public void PrintMenu(List<Enums.MenuOption> options, int pointer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TITLE);
            Console.WriteLine();
            Console.WriteLine("Use arrows to navigate.\nSpace to select.\n");
            for (int i = 0; i < options.Count; i++)
            {
                if (i == pointer)
                    Console.WriteLine("> " + options[i]);
                else
                    Console.WriteLine(" " + options[i]);
            }
        }

        public void PrintStatsMenu(List<Enums.MenuOption> options, int pointer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Player Stats");
            Console.WriteLine();
            Console.WriteLine("Use arrows to navigate.\nSpace to select.\n");

            Console.WriteLine("Total Games Played: " + (Stats.Wins[0] + Stats.Wins[1] + Stats.Wins[2]));
            for (int i = 0; i < Stats.Wins.Length-1; i++)
            {
                Console.Write("Player " + (i + 1) + " Wins: " + Stats.Wins[i]);
                Console.WriteLine();
            }
            Console.Write("Tied Games: " + Stats.Wins[2]);
            Console.WriteLine();

            Console.WriteLine();

            for (int i = 0; i < options.Count; i++)
            {
                if (i == pointer)
                    Console.WriteLine("> " + options[i]);
                else
                    Console.WriteLine(" " + options[i]);
            }
        }

        public void PrintOptionsMenu(List<Enums.OptionsMenuOption> options, int pointer, Config piece)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TITLE);
            Console.WriteLine();
            Console.WriteLine("Use arrows to navigate.\nRight arrow to change style.\n");

            int j = 0;            
            for (int i = 0; i < options.Count; i++)
            {
                if (i <= 2 && i >= 1 )
	            {
                    j = 0;
	            }else if (i >= 3 && i <= 4)
                {
                    j = 1;
	            }
                else
                {
                    j = 2;
                }

                if (i == pointer)
                {
                    if (pointer == 0){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("> " + options[0]);
                    }
                    else if (pointer == 1){
                        Console.ForegroundColor = piece.Colors[j];
                        Console.WriteLine("> " + options[1] + ":  " + piece.Icons[j]);
                    }
                    else if (pointer == 2){
                        Console.ForegroundColor = piece.Colors[j];
                        Console.WriteLine("> " + options[2] + ":  " + piece.Icons[j]);
	                }
                    else if (pointer == 3){
                        Console.ForegroundColor = piece.Colors[j];
                        Console.WriteLine("> " + options[3] + ":  " + piece.Icons[j]);
                    }
                    else if (pointer == 4){
                        Console.ForegroundColor = piece.Colors[j];
                        Console.WriteLine("> " + options[4] + ":  " + piece.Icons[j]);
                    }
                }
                else
                {
                    Console.ForegroundColor = piece.Colors[j];
                    Console.WriteLine(" " + options[i] + " " + piece.Icons[j]);
                }        
            }
        }

        #endregion
    }
}
