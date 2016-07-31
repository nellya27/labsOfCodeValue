using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class GameLogic
    {
        public enum GameType
        {
            Roll,
            Move
        }

        private Field[] fields;
        private Move[] possibleMoves;
        private GameType currentType;
        private Dice diceOptions;
        private int[] possibleSources;
        private int winner;
        private Dictionary<int,int[]> possibleTargets;
        private SoldierType currentChecker;

        public GameLogic(Field [] gameFields,Dice CurDiceOptions,SoldierType curColor)
        {
            diceOptions = CurDiceOptions;
            fields = gameFields;
            currentChecker = curColor;
            GetPossibleMoves();
        }
        public Field[] GetFields
        {
            get { return fields; }
        }
        public SoldierType GetCurrColor
        {
            get { return currentChecker; }
        }

        public Move[] GetPossMove
        {
            get { return possibleMoves; }
        }

        public Dice GetDiceOptions
        {
            get { return diceOptions; }
        }

        public Dictionary<int,int[]> GetTargets
        {
            get { return possibleTargets; }
        }

        public int [] GetSources
        {
            get { return possibleSources; }
        }

        public GameType GetTurnType
        {
            get
            {
                if (diceOptions == null)
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
                int oOut = (int)BordLocation.Oout;
                int xOut = (int)BordLocation.XOut;
                winner = -1;

                if (fields[oOut].GetOStoneNumber == 15)
                    winner = (int)SoldierType.O;
                if (fields[xOut].GetXStoneNumber == 15)
                    winner = (int)SoldierType.X;

                return winner;
            }
        }

        private void GetPossibleMoves()
        {
            Dice state = diceOptions;

            if (state == null)
            {
                possibleMoves = new Move[0];
                possibleSources = new int[0];
                possibleTargets = new Dictionary<int, int[]>();
                return;
            }

            Dictionary<Move, object> moves = new Dictionary<Move, object>();
            int oOut = (int)BordLocation.Oout;
            if (currentChecker == SoldierType.O)
            {
                if (fields[oOut].GetOStoneNumber == 0)
                {
                    for (int i = 0; i < diceOptions.GetPossibleDiceOption.Length; i++)
                    {
                        int diceNumber = diceOptions.GetPossibleDiceOption[i];

                        for (int j = 0; j < fields.Length; j++)
                        {
                            if (fields[j].IsAccsesibleField(currentChecker))
                                if (j - diceNumber >= 0)
                                    if (fields[j - diceNumber].GetOStoneNumber > 0)
                                    {
                                        Move currentMove = new Move(j - diceNumber, j, currentChecker);
                                        if (!moves.ContainsKey(currentMove))
                                            moves.Add(currentMove, null);
                                    }

                        }
                    }
                }
                else
                {
                    int fieldsLeft = 6;

                    for (int i = 0; i < diceOptions.GetPossibleDiceOption.Length; i++)
                    {
                        int movesLeft = diceOptions.GetPossibleDiceOption[i];
                        int target = fieldsLeft - movesLeft;
                        if (fields[target].IsAccsesibleField(currentChecker))
                        {
                            Move currentMove = new Move(oOut, target, currentChecker);
                            if (!moves.ContainsKey(currentMove))
                            {
                                moves.Add(currentMove, null);
                            }
                        }

                    }


                }

                if(isWhiteHome())
                {
                    int bar = (int)BordLocation.Nowhere;
                    for(int i=0;i<diceOptions.GetPossibleDiceOption.Length;i++)
                    {
                        int diceNumber = diceOptions.GetPossibleDiceOption[i];
                        int source = 24 - diceNumber;
                        if(source>0 && source<23)
                        {
                            if(fields[source].GetOStoneNumber>0)
                            {
                                Move currentMove = new Move(source, bar, currentChecker);
                                if (!moves.ContainsKey(currentMove))
                                    moves.Add(currentMove,null);
                            }
                        }
                    }

                }


            }
            else
            {
                int xOut =(int)BordLocation.XOut;
                if(fields[xOut].GetXStoneNumber==0)
                {
                    for(int i=0;i<diceOptions.GetPossibleDiceOption.Length;i++)
                    {
                        int diceNumber = diceOptions.GetPossibleDiceOption[i];
                        for(int j=0;j<24;j++)
                        {
                            if(fields[j].IsAccsesibleField(SoldierType.X))
                               if(j+diceNumber<fields.Length-3)
                                    if(fields[j+diceNumber].GetXStoneNumber>0)
                                    {
                                        Move currentMove = new Move(j + diceNumber, j, currentChecker);
                                        if(!moves.ContainsKey(currentMove))
                                        {
                                            moves.Add(currentMove, null);
                                        }
                                    }
                        }
                    }
                }
                else
                {
                    for(int i=0;i<diceOptions.GetPossibleDiceOption.Length;i++)
                    {
                        int DiceNumber = diceOptions.GetPossibleDiceOption[i];
                        int target = xOut + DiceNumber - 8;
                        if(fields[target].IsAccsesibleField(currentChecker))
                        {
                            Move currentMove = new Move(xOut, target, currentChecker);
                            if(!moves.ContainsKey(currentMove))
                            {
                                moves.Add(currentMove, null);
                            }
                        }
                    }

                }

                if(isBlackHome())
                {
                    int bar = (int)BordLocation.Nowhere;
                    for(int i=0;i<diceOptions.GetPossibleDiceOption.Length;i++)
                    {
                        int diceNumber = diceOptions.GetPossibleDiceOption[i];
                        int source = diceNumber - 1;
                        if(source>0 && source<23)
                        {
                            if(fields[source].GetOStoneNumber>0)
                            {
                                Move currentMove = new Move(source, bar, currentChecker);
                                if(!moves.ContainsKey(currentMove))
                                {
                                    moves.Add(currentMove, null);
                                }
                            }
                        }
                    }
                }
               
            }

            InitializePossibleMoves(moves);
          
        } 

        private void InitializePossibleMoves(Dictionary<Move,object> moves)
        {
            Move[] moveResult = moves.Keys.ToArray<Move>();
            Dictionary<int, List<int>> temporery = new Dictionary<int, List<int>>();
            for (int i = 0; i < moveResult.Length; i++)
            {
                int source = moveResult[i].GetSourceField;
                int target = moveResult[i].GetTargetField;
                if (!temporery.ContainsKey(source))
                {
                    temporery.Add(source, new List<int>());
                }

                temporery[source].Add(target);
            }

            possibleSources = temporery.Keys.ToArray<int>();
            possibleTargets = new Dictionary<int, int[]>();
            foreach (KeyValuePair<int, List<int>> item in temporery)
            {
                possibleTargets.Add(item.Key, item.Value.ToArray<int>());
            }

            possibleMoves = moveResult;

        }


        private bool isWhiteHome()
        {
            int oOut = (int)BordLocation.Oout;
            bool isHome = true;
            if(fields[oOut].GetXStoneNumber>0)
            {
                return false;
            }
            for(int i=6;i<24;i++)
            {
                if(fields[i].GetOStoneNumber>0)
                {
                    return false;
                    break;
                }
            }
            return isHome;
        }

        private bool isBlackHome()
        {
            int xOut = (int)BordLocation.XOut;
            bool isHome = true;
            if(fields[xOut].GetOStoneNumber>0)
            {
                return false;
            }
            for(int i=0;i<18;i++)
            {
                if(fields[i].GetOStoneNumber>=0)
                {
                    return false;
                }
            }
            return isHome;
        }
       }
    }
    
