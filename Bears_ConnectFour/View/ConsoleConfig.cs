using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    /// <summary>
    /// Struct to store the initial settings for the console window
    /// </summary>
    public struct ConsoleConfig
    {
        public const int windowWidth = 50;
        public const int windowHeight = 15;

        public const int windowLeft = 20;
        public const int windowTop = 20;

        public const string headerText = "- set header text -";

        public const ConsoleColor headerBackgroundColor = ConsoleColor.White;
        public const ConsoleColor headerForegroundColor = ConsoleColor.Red;

        public const ConsoleColor bodyBackgroundColor = ConsoleColor.Black;
        public const ConsoleColor bodyForegroundColor = ConsoleColor.White;

        public const string windowTitle = " - Connect4 by Eric, Kevin, & Connor - ";

        public const int displayHorizontalMargin = 3;
    }
}
