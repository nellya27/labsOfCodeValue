using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammonLogic;

namespace UIBackGammon
{
    public class Board:IDrawBoard
    {
        private const int maxTopPieces= 5;

        public void DrawBoard(Field [] gameBoard)
        {
            Dictionary<int, char[]> fieldDictionary = new Dictionary<int, char[]>();
            fieldDictionary=AddCheckers(gameBoard);
            StringBuilder boardBuilder = new StringBuilder();
            BuildUpperBoard(boardBuilder, fieldDictionary);
            BuildMiddleBoard(boardBuilder, gameBoard);
            BuildBottomBoard(boardBuilder, fieldDictionary);          
            Console.WriteLine(boardBuilder);
        }

        public void BuildUpperBoard(StringBuilder boardBuilder,Dictionary<int,char[]> fieldDictionary)
        {
            boardBuilder.Append(" 12  11  10  09  08  07                06  05  04  03  02  01\n");
            boardBuilder.Append("-------------------------------------------------------------------      OUT OF FEILD\n");
            for (int i = 0; i < maxTopPieces; i++)
            {
                boardBuilder.Append("|");
                for (int j = 11; j >= 6; j--)
                {
                    char[] raw = fieldDictionary[j];
                    boardBuilder.AppendFormat("{0}   ", raw[i]);

                }
                boardBuilder.Append("|      ");
                boardBuilder.Append("      |");
                for (int j = 5; j >= 0; j--)
                {
                    char[] raw = fieldDictionary[j];
                    boardBuilder.AppendFormat("{0}   ", raw[i]);
                }
                boardBuilder.Append("|");
                boardBuilder.AppendLine();
            }
        }

        public void BuildMiddleBoard(StringBuilder boardBuilder,Field[] gameBoard)
        {
            int noWhere = (int)BordLocation.Nowhere;
            int oOut = (int)BordLocation.Oout;
            int xOut = (int)BordLocation.XOut;
            boardBuilder.Append("|                        |            |                        |\n");
            boardBuilder.Append("++++++++OuterBoard++++++++            ++++++++HomeBoard+++++++++\n");
            boardBuilder.Append("|                        |      Bar   |                        |\n");
            boardBuilder.AppendFormat("|                        |  X:{0} O:{1}   |                        |\n",gameBoard[xOut].NumberOfXStones,gameBoard[oOut].NumberOfOStones);

            
            boardBuilder.AppendFormat("|                        |            |                        |                 O: {0}  \n", gameBoard[noWhere].NumberOfOStones);
            boardBuilder.AppendFormat("|                        |            |                        |                 X: {0}  \n", gameBoard[noWhere].NumberOfXStones);
        }

        public void BuildBottomBoard(StringBuilder boardBuilder,Dictionary<int,char[]>fieldDictionary)
        {
            for (int i = 0; i < maxTopPieces; i++)
            {
                boardBuilder.Append("|");

                for (int j = 12; j < 18; j++)
                {
                    char[] raw = fieldDictionary[j];
                    boardBuilder.AppendFormat("{0}   ", raw[4 - i]);

                }
                boardBuilder.Append("|      ");
                boardBuilder.Append("      |");
                for (int j = 18; j < 24; j++)
                {
                    char[] raw = fieldDictionary[j];
                    boardBuilder.AppendFormat("{0}   ", raw[4 - i]);
                }

                boardBuilder.Append("|");
                boardBuilder.AppendLine();
            }

            boardBuilder.Append("-------------------------------------------------------------------\n");
            boardBuilder.Append("13  14  15   16  17  18               19  20  21  22  23  24\n");
        }

        public void InitializeBoard(Field [] gameBoard)
        {
            for(int i=0;i<27;i++)
            {
                gameBoard[i] = new Field();
            }       
            gameBoard[0].NumberOfOStones = 2;
            gameBoard[5].NumberOfXStones = 5;
            gameBoard[7].NumberOfXStones = 3;
            gameBoard[11].NumberOfOStones = 5;
            gameBoard[12].NumberOfXStones = 5;
            gameBoard[16].NumberOfOStones = 3;
            gameBoard[18].NumberOfOStones = 5;
            gameBoard[23].NumberOfXStones = 2;           
        }

        public Dictionary<int,char[]> AddCheckers(Field[] gameField)
        {
            
            Dictionary<int, char[]> raw = new Dictionary<int, char[]>();
            for(int i=0;i<24;i++)
            {
                if(gameField[i].NumberOfXStones>0)
                {
                    AddXChecker(raw, gameField[i].NumberOfXStones, i);                 
                }
                else if(gameField[i].NumberOfOStones>0)
                {
                    AddOChecker(raw, gameField[i].NumberOfOStones, i);
                }
                else
                {
                    EmptyFeilds(raw, i);
                }
            }
            return raw;
        }

        public void AddXChecker(Dictionary<int, char[]> raw ,int stoneCount,int index)
        {
            char[] checkers = new char[5];

            for (int j = 0; j < checkers.Length; j++)
            {
                if (stoneCount > 0)
                {
                    checkers[j] =char.Parse(SoldierType.X.ToString()); 
                    stoneCount--;
                }
                else
                    checkers[j] = '.';
            }
            raw.Add(index, checkers);
        }

        public void AddOChecker(Dictionary<int, char[]> raw, int stoneCount, int index)
        {
            char[] checkers = new char[5];
    
            for (int j = 0; j < checkers.Length; j++)
            {
                if (stoneCount > 0)
                {
                    checkers[j] = char.Parse(SoldierType.O.ToString());
                    stoneCount--;
                }
                else
                    checkers[j] = '.';
            }
            raw.Add(index, checkers);
        }

        public void EmptyFeilds(Dictionary<int, char[]> raw, int index)
        {
             char[] checkers = new char[5];
                    for (int j=0;j<checkers.Length;j++)
                    {
                        checkers[j] = '.';
                    }
                    raw.Add(index, checkers);
        }

    }
}
