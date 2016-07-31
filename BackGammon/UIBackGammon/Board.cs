using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammonLogic;

namespace UIBackGammon
{
    public class Board
    {
      
        public void DrawBoard(Field [] gameBoard)
        {
            int blackFigures = 0;
            int whiteFigures = 0;

            int maxTopPieces = 5;
            Dictionary<int, char[]> fieldDictionary = new Dictionary<int, char[]>();
            fieldDictionary=AddCheckers(gameBoard);           
        
            Console.WriteLine(" 12  11  10  09  08  07                06  05  04  03  02  01\n");
            Console.WriteLine("-------------------------------------------------------------------      OUT OF FEILD\n");
            for (int i = 0; i < maxTopPieces; i++)
            {
                Console.Write("|");

                for (int j = 11; j>= 6; j--)
                {
                    char[] raw = fieldDictionary[j];
                    Console.Write("{0}   ",raw[i]);
                                  
                }

                Console.Write("|      ");
                Console.Write("      |");
                for (int j = 5; j >=0; j--)
                {
                    char[] raw = fieldDictionary[j];
                    Console.Write("{0}   ", raw[i]);
                }

                Console.Write("|");
                Console.WriteLine();
                       
            }

            Console.Write("|                        |            |                        |\n");
            Console.Write("++++++++OuterBoard++++++++            ++++++++HomeBoard+++++++++\n");
            Console.Write("|                        |      Bar   |                        |\n");
            int whiteOut = (int)SoldierType.O;
            int blackOut = (int)SoldierType.X;
            Console.WriteLine("                                                                         O: {0}  ", gameBoard[whiteOut].GetOStoneNumber);
            Console.WriteLine("                                                                         X: {0}  ", gameBoard[blackOut].GetXStoneNumber);
            Console.Write("|                        |            |                        |\n");

            for(int i=0;i<maxTopPieces;i++)
            {
                Console.Write("|");
                for(int j=12;j<18;j++)
                {
                    char[] raw = fieldDictionary[j];
                    Console.Write("{0}   ", raw[4-i]);
                }
                Console.Write("|      ");
                Console.Write("      |");
                for(int j=18;j<24;j++)
                {
                    char[] raw = fieldDictionary[j];
                    Console.Write("{0}   ", raw[4-i]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------------------------------------------\n");
            Console.WriteLine("13  14  15   16  17  18               19  20  21  22  23  24\n");
            

        } 
        public void InitializeBoard(Field [] gameBoard)
        {
            int blackOut = (int)BordLocation.XOut;
            int whiteOut = (int)BordLocation.Oout;
            int nowhare = (int)BordLocation.Nowhere;
            for(int i=0;i<27;i++)
            {
                gameBoard[i] = new Field();
            }
       
            gameBoard[blackOut] = new Field();
            gameBoard[whiteOut] = new Field();
            gameBoard[nowhare] = new Field();

            gameBoard[blackOut].GetXStoneNumber = 0;
            gameBoard[whiteOut].GetOStoneNumber = 0;
            gameBoard[0].GetOStoneNumber = 2;
            gameBoard[5].GetXStoneNumber = 5;
            gameBoard[7].GetXStoneNumber = 3;
            gameBoard[11].GetOStoneNumber = 5;
            gameBoard[12].GetXStoneNumber = 5;
            gameBoard[16].GetOStoneNumber = 3;
            gameBoard[18].GetOStoneNumber = 5;
            gameBoard[23].GetXStoneNumber = 2;
            
        }

        public Dictionary<int,char[]> AddCheckers(Field[] gameField)
        {
            
            Dictionary<int, char[]> raw = new Dictionary<int, char[]>();
            for(int i=0;i<27;i++)
            {
                if(gameField[i].GetXStoneNumber>0)
                {
                    char[] checkers = new char[5];
                    int stoneCount =gameField[i].GetXStoneNumber;
                    for(int j=0;j<checkers.Length;j++)
                    {
                        if (stoneCount > 0)
                        {
                            checkers[j] = 'X';
                            stoneCount--;
                        }
                        else
                            checkers[j] = '.';
                    }
                    raw.Add(i, checkers);
                }
                else if(gameField[i].GetOStoneNumber>0)
                {
                    char[] checkers = new char[5];
                    int stoneCount = gameField[i].GetOStoneNumber;

                    for (int j=0;j<checkers.Length;j++)
                    {
                        if (stoneCount > 0)
                        {
                            checkers[j] = 'O';
                            stoneCount--;
                        }
                        else
                            checkers[j] = '.';
                    }
                    raw.Add(i, checkers);
                }
                else
                {
                    char[] checkers = new char[5];
                    for (int j=0;j<checkers.Length;j++)
                    {
                        checkers[j] = '.';
                    }
                    raw.Add(i, checkers);
                }

            }
            return raw;
        }
    }
}
