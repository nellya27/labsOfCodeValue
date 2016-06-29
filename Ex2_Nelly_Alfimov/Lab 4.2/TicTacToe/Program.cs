using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Program
    {
      public static void Main()
        {
            TicTacToeGame newGame = new TicTacToeGame();
            TicTacToeGame.eBoardCell firstPlayerSymbol =TicTacToeGame.eBoardCell.X,secondPlayerSymbol=TicTacToeGame.eBoardCell.O;
            TicTacToeGame.eBoardCell currentSymbol = firstPlayerSymbol;
            newGame.PrintBoard();
            do
            {
                int xcoord;
                int ycoord;
               
                newGame.MakeMove(currentSymbol, out xcoord, out ycoord);
                Console.Clear();
                newGame.PrintBoard();
                newGame.IsWonGame(xcoord, ycoord);
                if (!newGame.IsGameOver)
                {
                    if (currentSymbol == firstPlayerSymbol)
                    {
                        currentSymbol = secondPlayerSymbol;
                        Console.WriteLine("second player now its your turn");
                    }
                    else
                    {
                        currentSymbol = firstPlayerSymbol;
                        Console.WriteLine("second player now its your turn");
                    }
                }

            }
            while (!newGame.IsGameOver);
            Console.WriteLine("The game over");




        }
    }
}
