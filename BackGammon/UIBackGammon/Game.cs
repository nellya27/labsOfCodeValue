using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammonLogic;

namespace UIBackGammon
{
    public class Game
    {
       private Board gameBoard=new Board();
       private Player firstPlayer;
       private Player secondPlayer;
       private Dice roll;
       private GameLogic gameLogic;
       private Field[] field = new Field[27];
     

       public GameLogic GetGameLogic
        {
            get { return gameLogic; }
            set
            {
                gameLogic = value;
                Proceed();

            }
        }


        private void GetPlayersData()
        {
            Console.WriteLine("Welcome  to a backgammon game");
            Console.WriteLine("Please Enter your name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Second player please enter your name");
            string secondName = Console.ReadLine();
            string startingFirst = WhoStartFirst(firstName,secondName);
            if (startingFirst == firstName)
            {
                firstPlayer = new Player(SoldierType.O, firstName);
                secondPlayer = new Player(SoldierType.X, secondName);
            }
            else
            {
                firstPlayer = new Player(SoldierType.O, secondName);
                secondPlayer = new Player(SoldierType.X, firstName);
            }

            Console.WriteLine("{0} You start first your checker are O",startingFirst);
            Console.WriteLine("{0} your checkers are X", secondPlayer.GetPlayerName);        
        } 



        private string WhoStartFirst(string name1,string name2)
        {
            Dice firstPlayerRoll;
            Dice secondPlayerRoll;
            string winner = string.Empty;
            do
            {
                firstPlayerRoll = DiceRoll();
                secondPlayerRoll = DiceRoll();
                if (firstPlayerRoll.GetDiceSum > secondPlayerRoll.GetDiceSum)
                    winner= name1;
                else
                    winner= name2;
            }
            while (firstPlayerRoll.GetDiceSum == secondPlayerRoll.GetDiceSum);

            return winner;
        }
   
        
        private Dice DiceRoll()
        {
            Random randomMove = new Random();
            int leftDice = randomMove.Next(6) + 1;
            int rightDice = randomMove.Next(6) + 1;
            Dice newDice = new Dice(leftDice, rightDice);
            return newDice;
                               
        }

        public void InitiallizeGame()
        {
            ConsoleColor color = ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            Console.WriteLine("++++++++BackGammon Game+++++++++");
            ConsoleColor newColor = ConsoleColor.White;
            Console.ForegroundColor = newColor;
            GetPlayersData();
            Console.Clear();
            gameBoard.InitializeBoard(field);
            gameBoard.DrawBoard(field);
            gameLogic = new GameLogic(field,null,SoldierType.O);
            Proceed();
           
        }
        
        private Dice GetDiceRolling(SoldierType currentMove)
        {
            if (currentMove == firstPlayer.GetPlayerColor)
                Console.WriteLine("{0},Please Roll the dice", firstPlayer.GetPlayerName);
            else
                Console.WriteLine("{0},Please Roll the dice", secondPlayer.GetPlayerName);

            Dice currentDice = DiceRoll();
            int[] diceOptions = currentDice.GetPossibleDiceOption;
            Console.WriteLine("Dice Result");
            for(int i=0;i<diceOptions.Length;i++)
            {
                Console.Write("{0} ",diceOptions[i]);
            }
            Console.WriteLine();

            return currentDice;
        }
        
        private void GetPlayerMove(Player player)
        {
            if (gameLogic.GetPossMove.Length > 0)
            {
                Console.WriteLine("dice option left: ");
                foreach(int option in gameLogic.GetDiceOptions.GetPossibleDiceOption)
                {
                    Console.Write("{0} ", option);
                }
                Console.WriteLine();
                Console.WriteLine("{0} Please enter please choose your start colomn",player.GetPlayerName);
                int source = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter your Destination colomn");
                int target = int.Parse(Console.ReadLine());
                Move newMove = new Move(source-1, target-1,player.GetPlayerColor);
                ReciveMove(newMove);                   
                
            }
            else
            {
                Move newMove = new Move(0, 0, gameLogic.GetCurrColor);
                Console.WriteLine("Thre  is no possiable moves you lose yourTurn");
                MoveChecker moveCheck = RegisterMove(newMove);
                if(moveCheck.GetCheckResult!=MoveChecker.ResultType.Positive)
                {
                    Console.WriteLine("Eror");
                }
            }
        } 

        public void ReciveMove(Move m)
        {
            MoveChecker moveCheck = RegisterMove(m);
            if(moveCheck.GetCheckResult==MoveChecker.ResultType.Negative)
            {
                Console.WriteLine(moveCheck.GetDescription);
                Proceed();
            }
         
        }

        public MoveChecker RegisterMove(Move m)
        {
            if(m.IsEmpty)
            {
                if (gameLogic.GetPossMove.Length == 0)
                {
                    GetGameLogic = new GameLogic(gameLogic.GetFields, gameLogic.GetDiceOptions, gameLogic.GetCurrColor);
                    return new MoveChecker(MoveChecker.ResultType.Positive, null);
                }
                else
                    return new MoveChecker(MoveChecker.ResultType.Negative, "cant be empty");
            }

            if(gameLogic.GetCurrColor!=m.GetChecers)
            {
                return new MoveChecker(MoveChecker.ResultType.Negative, "the checker you chose not matching the current turn");
            }
            if(!gameLogic.GetPossMove.Contains<Move>(m))
            {
                return new MoveChecker(MoveChecker.ResultType.Negative, "this move is not possible");
            }

            Field[] newField = gameLogic.GetFields;
            SoldierType newTurn = gameLogic.GetCurrColor;
            Dice newDiceState = gameLogic.GetDiceOptions.ReduceCubeOption(m.GetLengh);
            newField[m.GetSourceField].RemoveFromField(m.GetChecers);
            newField[m.GetTargetField].AddToField(m.GetChecers);
  

            int oout =(int)BordLocation.Oout;
            int Xout = (int)BordLocation.XOut;
            if (newField[m.GetTargetField].GetStoneByType(GetOpposite(m.GetChecers))==1)
            {
                newField[m.GetTargetField].RemoveFromField(GetOpposite(m.GetChecers));
                if (GetOpposite(m.GetChecers) == SoldierType.O)
                    newField[oout].AddToField(SoldierType.O);
                else
                    newField[Xout].AddToField(SoldierType.X);
            }
            if(newDiceState.GetPossibleDiceOption.Length==0)
            {
                newDiceState = null;
                newTurn = GetOpposite(newTurn);
             
            }
            Console.Clear();
            gameBoard.DrawBoard(newField);
            GameLogic newGameState = new GameLogic(newField, newDiceState, newTurn);


            if (gameLogic.GetDiceOptions != null)
            {
                if (gameLogic.GetDiceOptions.GetChoicesLeft == 2 && gameLogic.GetDiceOptions.GetPossibleDiceOption.Length == 2)
                    if (m.GetLengh == gameLogic.GetDiceOptions.GetPossibleDiceOption[0])
                        if (newGameState.GetPossMove.Length == 0)
                            return new MoveChecker(MoveChecker.ResultType.Negative, "Iligal move");

            }

            GetGameLogic = newGameState;

            return new MoveChecker(MoveChecker.ResultType.Positive, null);
        }

     

        private MoveChecker RegisterNewDice()
        {
            if (gameLogic.GetDiceOptions != null)
                return new MoveChecker(MoveChecker.ResultType.Negative, "unessery to throw dice");

            GetGameLogic = new GameLogic(gameLogic.GetFields,roll, gameLogic.GetCurrColor);
            return new MoveChecker(MoveChecker.ResultType.Positive, null);
        }

        private void MakeDiceMove(Player player)
        {

            roll = DiceRoll();
          

            MoveChecker moveCheck = RegisterNewDice();
            if(moveCheck.GetCheckResult==MoveChecker.ResultType.Negative)
            {
                Console.WriteLine(moveCheck.GetDescription);
            }

            Proceed();
        
        }

        private void Proceed()
        {

            if(gameLogic.GetWinner==-1)
            {
                if(gameLogic.GetCurrColor==SoldierType.O)
                {
                    if(gameLogic.GetTurnType==GameLogic.GameType.Move)
                    {
                        GetPlayerMove(firstPlayer);
                    }
                    else
                    {
                        MakeDiceMove(firstPlayer);
                    }
                }
                else
                {
                    if (gameLogic.GetTurnType == GameLogic.GameType.Move)
                    {
                        GetPlayerMove(secondPlayer);
                    }
                    else
                    {
                        MakeDiceMove(secondPlayer);
                    }
                }
            }
            else
            {
                if(gameLogic.GetWinner==(int)SoldierType.O)
                {
                    Console.WriteLine("{0} You Won!!!!", firstPlayer.GetPlayerName);
                }
                else
                    Console.WriteLine("{0} You Won!!!!", secondPlayer.GetPlayerName);
            }
            
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
