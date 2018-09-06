using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bears_ConnectFour
{
    class Controller
    {
        public Controller()
        {
            Board _board = new Board();
            _board.PrintGrid();
            Console.ReadLine();
        }
        

    }
}
