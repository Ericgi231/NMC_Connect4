using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    public static class Enums
    {
        public enum MenuOption {
            NEW_GAME,
            OPTIONS,
            STATS,
            BACK,
            EXIT
        };

        public enum OptionsMenuOption{
            BACK,
            P1_ICON,
            P1_COLOR,
            P2_ICON,
            P2_COLOR,
            BOARD_HEIGHT,
            BOARD_WIDTH

        }
    }
}
