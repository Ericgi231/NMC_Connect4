using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    public class Config
    {
        #region properties
        public int Players { get; set; }
        public ConsoleColor[] Colors { get; set; } 
        public Char[] Icons { get; set; }
        public Boolean[] IsComputer { get; set; }
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        #endregion

        #region constructors
        public Config()
        {
            SetDefaultConfig();
        }
        #endregion

        #region methods
        /// <summary>
        /// sets the default config settings
        /// </summary>
        private void SetDefaultConfig()
        {
            Players = 3;
            Colors = new ConsoleColor[3] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.White};
            Icons = new Char[3] { 'O', 'O', ' '};
            IsComputer = new Boolean[3] { false, false, false};
            BoardWidth = 7;
            BoardHeight = 6;
        }

        /// <summary>
        /// changes the config to user set settings
        /// </summary>
        /// <param name="players">ammount of players in game</param>
        public void SetNewConfig(int players)
        {
            Players = players;
            Colors = new ConsoleColor[Players];
            Icons = new Char[Players];
            IsComputer = new Boolean[Players];
        }

        /// <summary>
        /// adds a new player to the config
        /// </summary>
        public void EditPlayer(int id, ConsoleColor color, Char icon, Boolean isComputer)
        {
            Colors[id] = color;
            Icons[id] = icon;
            IsComputer[id] = isComputer;
        }
        #endregion
    }
}
