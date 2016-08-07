using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammonLogic;

namespace UIBackGammon
{
    public class Game:IGame
    {
        private Board gameBoard = new Board();
        private Player firstPlayer;
        private Player secondPlayer;
        private Dice roll;
        private GameLogic gameLogic;
        private Field[] field = new Field[27];
        private GameSettings gameset;

        public GameLogic GetGameLogic
        {
            get { return gameLogic; }

            set
            {
                gameLogic = value;
                Play();
            }
        }


        public void StartGame()
        {
            ConsoleColor color = ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            Console.WriteLine("++++++++BackGammon Game+++++++++");
            ConsoleColor newColor = ConsoleColor.White;
            Console.ForegroundColor = newColor;
            gameset = new GameSettings();
            firstPlayer = gameset.firstPlayer;
            secondPlayer = gameset.secondPlayer;
            Console.Clear();
            gameBoard.InitializeBoard(field);
            gameBoard.DrawBoard(field);
            gameLogic = new GameLogic(field, null, SoldierType.O);
            Play();

        }

        private void AskForMove(Player player, ref int source, ref int target)
        {
            Console.WriteLine("{0} Please enter please choose your start colomn", player.playerName);
            source = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your Destination colomn");
            target = int.Parse(Console.ReadLine());
        }

        private void GetPlayerMove(Player player)
        {
            if (gameLogic.PossibleMoves.Length > 0)
            {
                int source = 0;
                int target = 0;
                gameset.PrintCurrentDiceOption(gameLogic);
                Console.WriteLine();
                gameset.PrintMovesAvailable(gameLogic);
                AskForMove(player, ref source, ref target);
                Move newMove = new Move(source - 1, target - 1, player.playerCheckerType); ReciveMove(newMove);
            }
            else
            {
                Move newMove = new Move(0, 0, gameLogic.CurrentChecker);
                Console.WriteLine("Thre  is no possiable moves you lose yourTurn");
                MoveChecker moveCheck = RegisterMove(newMove);
                if (moveCheck.CheckResult != MoveChecker.ResultType.Positive)
                {
                    Console.WriteLine("Eror");
                }
            }
        }

        public void ReciveMove(Move m)
        {
            MoveChecker moveCheck = RegisterMove(m);
            if (moveCheck.CheckResult == MoveChecker.ResultType.Negative)
            {
                Console.WriteLine(moveCheck.Description);
                Play();
            }
        }

        public MoveChecker RegisterMove(Move m)
        {
            if (m.IsEmpty)
            {
                if (gameLogic.PossibleMoves.Length == 0)
                {
                    GetGameLogic = new GameLogic(gameLogic.Fields, gameLogic.DiceOptions, gameLogic.CurrentChecker);
                    return new MoveChecker(MoveChecker.ResultType.Positive, null);
                }
                else
                    return new MoveChecker(MoveChecker.ResultType.Negative, "cant be empty");
            }

            if (gameLogic.CurrentChecker != m.checkerType)
            {
                return new MoveChecker(MoveChecker.ResultType.Negative, "the checker you chose not matching the current turn");
            }
            if (!gameLogic.PossibleMoves.Contains<Move>(m))
            {
                return new MoveChecker(MoveChecker.ResultType.Negative, "this move is not possible");
            }

            Field[] newField = gameLogic.Fields;
            GameLogic currentGameState = RegisterValidMove(m, newField);
            UpdateBoard(newField);
            GetGameLogic = currentGameState;

            return new MoveChecker(MoveChecker.ResultType.Positive, null);
        }

        private void UpdateBoard(Field[] newField)
        {
            Console.Clear();
            gameBoard.DrawBoard(newField);
        }
    
        private GameLogic RegisterValidMove(Move m,Field[] newField)
        {
           
            SoldierType newTurn = gameLogic.CurrentChecker;
            try
            {
                Dice newDiceState = gameLogic.DiceOptions.GetDiceOptions(m.GetLengh);
                newField[m.sourceField].RemoveFromField(m.checkerType);
                newField[m.targetField].AddToField(m.checkerType);
                CheckForBlot(m, newField);
                if (newDiceState.DiceChoices.Length == 0)
                {
                    newDiceState = null;
                    newTurn = GetOpposite(newTurn);
                }
                GameLogic newGameState = new GameLogic(newField, newDiceState, newTurn);
                return newGameState;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        private void CheckForBlot(Move m,Field [] newField)
        {
            int oOut = (int)BordLocation.Oout;
            int xOut = (int)BordLocation.XOut;
            if (newField[m.targetField].GetStoneByType(GetOpposite(m.checkerType)) == 1)
            {
                newField[m.targetField].RemoveFromField(GetOpposite(m.checkerType));
                if (GetOpposite(m.checkerType) == SoldierType.O)
                    newField[oOut].AddToField(SoldierType.O);
                else
                    newField[xOut].AddToField(SoldierType.X);
            }
        }

        private MoveChecker RegisterNewDice()
        {
            if (gameLogic.DiceOptions != null)
                return new MoveChecker(MoveChecker.ResultType.Negative, "unessery to throw dice");

            GetGameLogic = new GameLogic(gameLogic.Fields,roll, gameLogic.CurrentChecker);
            return new MoveChecker(MoveChecker.ResultType.Positive, null);
        }

        private void MakeDiceMove(Player player)
        {

            roll =gameset.DiceRoll();
          
            MoveChecker moveCheck = RegisterNewDice();

            if (moveCheck.CheckResult==MoveChecker.ResultType.Negative)
            {
                Console.WriteLine(moveCheck.Description);
            }

            Play();        
        }

        public void Play()
        {

            if(gameLogic.GetWinner==-1)
            {
                GameState();
            }
            else
            {
                GameEnd();
            }            
        }

        public void DoAction(Player player)
        {

            if (gameLogic.GetTurnType == GameLogic.GameType.Move)
            {
                GetPlayerMove(player);
            }
            else
            {
                MakeDiceMove(player);
            }
        }

        private void GameState()
        {
            if (gameLogic.CurrentChecker == SoldierType.O)
            {
                DoAction(firstPlayer);
            }
            else
            {
                DoAction(secondPlayer);
            }
        }

        public void GameEnd()
        {
            Console.WriteLine("Game over");
            if (gameLogic.GetWinner == (int)SoldierType.O)
            {
                Console.WriteLine("{0} You Won!!!!", firstPlayer.playerName);
            }
            else
                Console.WriteLine("{0} You Won!!!!", secondPlayer.playerName);
        }

        public SoldierType GetOpposite(SoldierType type)
        {
            if (type == SoldierType.X)
                return SoldierType.O;
            else
                return SoldierType.X;
        }

    }
}
