using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class GameLogic:IGameLogic
    {
        public enum GameType
        {
            Roll,
            Move
        }

        private int winner;
        private GameType currentType;
        public Field[] Fields { get; private set;}
        public Move[] PossibleMoves { get;  private set;}
        public Dice DiceOptions { get; private set; }
        public int[] PossibleSources { get; private set; }
        public Dictionary<int,int[]> PossibleTargets { get; private set; }
        public SoldierType CurrentChecker { get; private set; }

        public GameLogic(Field [] gameFields,Dice curDiceOptions,SoldierType curColor)
        {
            DiceOptions = curDiceOptions;
            Fields = gameFields;
            CurrentChecker = curColor;
            GetPossibleMoves();
        }
 

        public GameType GetTurnType
        {
            get
            {
                if (DiceOptions == null)
                {
                    return GameType.Roll;
                }
                
                  return GameType.Move;
            }
        }

        public int GetWinner
        {
            get
            {
                int outAll= (int)BordLocation.Nowhere;
                winner = -1;

                if (Fields[outAll].NumberOfOStones == 15)
                    winner = (int)SoldierType.O;
                if (Fields[outAll].NumberOfXStones == 15)
                    winner = (int)SoldierType.X;

                return winner;
            }
        }

        private void CalcOMovesOnField(List<Move>moves)
        {
            for (int i = 0; i < DiceOptions.DiceChoices.Length; i++)
            {
                int diceNumber = DiceOptions.DiceChoices[i];

                for (int j = 0; j < Fields.Length; j++)
                {
                    if (Fields[j].IsAccsesibleField(CurrentChecker))
                    {
                        if (j - diceNumber >= 0)
                        {
                            if (Fields[j - diceNumber].NumberOfOStones > 0 && Fields[j].NumberOfOStones<5)
                            {
                                AddNewPossibleMove(moves, j - diceNumber, j);
                            }
                        }
                        else
                            continue;
                    }
                    else
                        continue;                   
                }
            }
        }

        private void CalcMovesWhenOCheckerOut(List<Move>moves)
        {
            int fieldsLeft = 6;
            int oOut = (int)BordLocation.Oout;

            for (int i = 0; i < DiceOptions.DiceChoices.Length; i++)
            {
                int movesLeft = DiceOptions.DiceChoices[i];
                int target = fieldsLeft - movesLeft;
                if (Fields[target].IsAccsesibleField(CurrentChecker))
                {
                    AddNewPossibleMove(moves, oOut, target);                 
                }
            }
        }

        private void CalcMovesWhenOCheckerHome(List<Move>moves)
        {
            int bar = (int)BordLocation.Nowhere;
            for (int i = 0; i < DiceOptions.DiceChoices.Length; i++)
            {
                int diceNumber = DiceOptions.DiceChoices[i];
                int source = 24 - diceNumber;
                if (source > 0 && source < 23)
                {
                    if (Fields[source].NumberOfOStones > 0)
                    {
                        AddNewPossibleMove(moves, source, bar);                     
                    }
                }
                
            }
        }

        private void CalcXMovesOnField(List<Move>moves)
        {
            for (int i = 0; i < DiceOptions.DiceChoices.Length; i++)
            {
                int diceNumber = DiceOptions.DiceChoices[i];
                for (int j = 0; j < 24; j++)
                {
                    if (Fields[j].IsAccsesibleField(SoldierType.X))
                    {
                        if (j + diceNumber < Fields.Length)
                        {
                            if (Fields[j + diceNumber].NumberOfXStones > 0 && Fields[j].NumberOfXStones < 5)
                            {
                                AddNewPossibleMove(moves, j + diceNumber, j);
                            }
                        }
                        else
                            continue;
                    }
                    else
                        continue;
                }
            }
        }
        private void CalcMovesWhenXCheckerOut(List<Move>moves)
        {
            int xOut = (int)BordLocation.XOut;
            for (int i = 0; i < DiceOptions.DiceChoices.Length; i++)
            {
                int DiceNumber = DiceOptions.DiceChoices[i];
                int target = xOut + DiceNumber - 8;
                if (Fields[target].IsAccsesibleField(CurrentChecker))
                {
                    AddNewPossibleMove(moves, xOut, target);                 
                }
            }
        }

        private void CalcMovesWhenXCheckerHome(List<Move> moves)
        {
            int bar = (int)BordLocation.Nowhere;
            for (int i = 0; i < DiceOptions.DiceChoices.Length; i++)
            {
                int diceNumber = DiceOptions.DiceChoices[i];
                int source = diceNumber - 1;
                if (source > 0 && source < 23)
                {
                    if (Fields[source].NumberOfXStones > 0)
                    {
                        AddNewPossibleMove(moves, source, bar);
                    }
                }
            }
        }
        private void GetListOfOMoves(List<Move>moves)
        {
            int oOut = (int)BordLocation.Oout;

            if (Fields[oOut].NumberOfOStones == 0)
            {
                CalcOMovesOnField(moves);
            }
            else
            {
                CalcMovesWhenOCheckerOut(moves);
            }

            if (IsOHome())
            {
                CalcMovesWhenOCheckerHome(moves);
            }
        }

        private void GetListOfXMoves(List<Move>moves)
        {
            int xOut = (int)BordLocation.XOut;

            if (Fields[xOut].NumberOfXStones == 0)
            {
                CalcXMovesOnField(moves);
            }
            else
            {
                CalcMovesWhenXCheckerOut(moves);

            }
            if (IsXHome())
            {
                CalcMovesWhenXCheckerHome(moves);
            }
        }

        private void AddNewPossibleMove(List<Move>moves,int source,int target)
        {
            Move currentMove = new Move(source, target, CurrentChecker);
            if (!moves.Contains(currentMove))
            {
                moves.Add(currentMove);
            }
        }

        public void GetPossibleMoves()
        {
            Dice state = DiceOptions;

            if (state == null)
            {
                PossibleMoves = new Move[0];
                PossibleSources = new int[0];
                PossibleTargets = new Dictionary<int, int[]>();
                return;
            }
            List<Move> moves = new List<Move>();

            if (CurrentChecker == SoldierType.O)
            {
                GetListOfOMoves(moves);
            }
            else
            {
                GetListOfXMoves(moves);               
            }

            InitializePossibleMoves(moves);          
        }
      
        private void InitializePossibleMoves(List<Move> moves)
        {
            Move[] moveResult = moves.ToArray<Move>();
            Dictionary<int, List<int>> temporery = new Dictionary<int, List<int>>();
            for (int i = 0; i < moveResult.Length; i++)
            {
                int source = moveResult[i].sourceField;
                int target = moveResult[i].targetField;
                if (!temporery.ContainsKey(source))
                {
                    temporery.Add(source, new List<int>());
                }

                temporery[source].Add(target);
            }

            PossibleSources = temporery.Keys.ToArray<int>();
            PossibleTargets = new Dictionary<int, int[]>();
            foreach (KeyValuePair<int, List<int>> item in temporery)
            {
                PossibleTargets.Add(item.Key, item.Value.ToArray<int>());
            }

            PossibleMoves = moveResult;
        }


        private bool IsOHome()
        {
            int oOut = (int)BordLocation.Oout;
            bool isHome = true;
            if(Fields[oOut].NumberOfOStones>0)
            {
                return false;
            }
            for(int i=0;i<18;i++)
            {
                if(Fields[i].NumberOfOStones>0)
                {
                    return false;
                    break;
                }
            }
            return isHome;
        }

        private bool IsXHome()
        {
            int xOut = (int)BordLocation.XOut;
            bool isHome = true;
            if(Fields[xOut].NumberOfXStones>0)
            {
                return false;                
            }
            for(int i=6;i<24;i++)
            {
                if(Fields[i].NumberOfXStones>=0)
                {
                    return false;
                    break;                   
                }
            }
            return isHome;
        }

      
    }
    }
    
