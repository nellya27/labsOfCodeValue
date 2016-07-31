using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBackGammon
{
    public class Program
    {
      public static void Main()
        {
            /* Board board = new Board();
             board.DrawBoard(); */

            Game game = new Game();
            game.InitiallizeGame();
        }
    }
}
