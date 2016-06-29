using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
   
    public class TicTacToeGame
    {
        public enum eBoardCell
        {
            X,
            O,
            empty,
        }

        private eBoardCell[,] m_BoardGame;
        private bool m_IsGameOver;

        public bool IsGameOver
        {
            get { return m_IsGameOver; }
            set { m_IsGameOver = value; }
        }

        public TicTacToeGame()
        {
            m_BoardGame = new eBoardCell [3, 3];
            for(int rowIndex=0;rowIndex<m_BoardGame.GetLength(0); rowIndex++)
            {
                for(int colIndex=0;colIndex<m_BoardGame.GetLength(1);colIndex++)
                {
                    m_BoardGame[rowIndex, colIndex] = eBoardCell.empty;
                }
            }
        }

        public bool IsBoardFull()
        {
            bool isFull = true;
            for(int rowIndex=0;rowIndex<m_BoardGame.GetLength(0);rowIndex++)
            {
                for(int colIndex=0;colIndex<m_BoardGame.GetLength(1);colIndex++)
                {
                    if(m_BoardGame[rowIndex,colIndex]==eBoardCell.empty)
                    {
                        isFull = false;
                        break;
                    }
                }
            }

            return isFull;
        }

        public void IsWonGame(int i_Xcoord,int i_Ycoord)
        {
            eBoardCell winnerSymbol = m_BoardGame[i_Xcoord, i_Ycoord];
            IsGameOver=checkRowsForWin(i_Xcoord, winnerSymbol) || CheckColForWin(i_Ycoord, winnerSymbol) || CheckDiagonal(winnerSymbol) || CheckNegDiagonal(winnerSymbol)||IsBoardFull();
        }

        public bool checkRowsForWin(int i_Xcoord,eBoardCell i_Symbol)
        {
            bool isRowWin = true;

            for(int rowCheck=0;rowCheck<m_BoardGame.GetLength(1);rowCheck++)
            {
                if(i_Symbol!=m_BoardGame[i_Xcoord,rowCheck])
                {
                    isRowWin = false;
                    break;
                }
            }

            return isRowWin;
        }

        public bool CheckColForWin(int i_Ycoord,eBoardCell i_Symbol)
        {
            bool isColWin = true;
            for(int colCheck=0;colCheck<m_BoardGame.GetLength(0);colCheck++)
            {
                if(m_BoardGame[colCheck,i_Ycoord]!=i_Symbol)
                {
                    isColWin = false;
                    break;
                }
            }
            return isColWin;
        }

        public bool CheckDiagonal(eBoardCell i_Symbol)
        {
            bool isDiagonalWin = true;
            for(int diagonal=0;diagonal<m_BoardGame.GetLength(0);diagonal++)
            {
                if(m_BoardGame[diagonal,diagonal]!=i_Symbol)
                {
                    isDiagonalWin = false;
                    break;
                }
            }

            return isDiagonalWin;
        }

        public bool CheckNegDiagonal(eBoardCell i_Symbol)
        {
            bool isNegDiagonalWin = true;
            for(int negDiagonal=0;negDiagonal<m_BoardGame.GetLength(0);negDiagonal++)
            {
                if(m_BoardGame[negDiagonal,m_BoardGame.GetLength(1)-negDiagonal-1]!=i_Symbol)
                {
                    isNegDiagonalWin = false;
                    break;
                }
            }

            return isNegDiagonalWin;
        }


        public void MakeMove(TicTacToeGame.eBoardCell i_PlayerSymbol,out int xcoord,out int ycoord)
        {
            bool validMove = true;
            do
            {
                Console.WriteLine("Please choose your x,y coordinates,");
                bool checkXcoord = int.TryParse(Console.ReadLine(),out xcoord);
                bool checkYcoord = int.TryParse(Console.ReadLine(),out ycoord);
                if (checkXcoord && checkYcoord)
                {
                    validMove = isLegalMove(xcoord, ycoord);
                    if (!validMove)
                    {
                        Console.WriteLine("your move not valid please try again");
                    }
                }
                else
                {
                    Console.WriteLine("your input is invalid");
                }
            }
            while (!validMove);
            m_BoardGame[xcoord, ycoord] = i_PlayerSymbol;
        }

        public bool isLegalMove(int i_Xcoordinates,int i_Ycoordinates)
        {
            bool isLegal = true;

            if (i_Xcoordinates>=m_BoardGame.GetLength(0)||i_Ycoordinates>=m_BoardGame.GetLength(1))
            {
                isLegal = false;
            }
            else if(i_Xcoordinates<0||i_Ycoordinates<0)
            {
                isLegal = false;
            }
            else
            {
                if(m_BoardGame[i_Xcoordinates,i_Ycoordinates]!=eBoardCell.empty)
                {
                    isLegal = false;
                }
            }

            return isLegal;

        }

        public void PrintBoard()
        {
            StringBuilder boarBuilder = new StringBuilder();

           for(int rowIndex=0;rowIndex<m_BoardGame.GetLength(0);rowIndex++)
            {
                boarBuilder.Append("|");

                for(int colIndex=0;colIndex<m_BoardGame.GetLength(1);colIndex++)
                {
                    if(m_BoardGame[rowIndex,colIndex]==eBoardCell.empty)
                    {
                        boarBuilder.Append(" ");
                    }
                    else if(m_BoardGame[rowIndex,colIndex]==eBoardCell.X)
                    {
                        boarBuilder.Append(eBoardCell.X.ToString());
                    }
                    else
                    {
                        boarBuilder.Append(eBoardCell.O.ToString());
                    }

                    boarBuilder.Append("|");
                }
                boarBuilder.AppendLine();
                boarBuilder.AppendLine("=======");
              
             }
            Console.WriteLine(boarBuilder);
        }

    }
}
