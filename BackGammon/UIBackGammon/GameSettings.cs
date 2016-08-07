using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammonLogic;

namespace UIBackGammon
{
    public class GameSettings
    {
       public Player firstPlayer { get; private set; }
       public Player secondPlayer { get; private set; }

        public GameSettings()
        {
            GetPlayersData();
        }

        public void GetPlayersData()
        {
            Console.WriteLine("Welcome  to a backgammon game");
            Console.WriteLine("Please Enter your name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Second player please enter your name");
            string secondName = Console.ReadLine();
            SetPlayers(firstName, secondName);
        }

        private void SetPlayers(string firstName, string secondName)
        {

            string startingFirst = WhoStartFirst(firstName, secondName);
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

            Console.WriteLine("{0} You start first your checker are O", startingFirst);
        }

        private string WhoStartFirst(string name1, string name2)
        {
            Dice firstPlayerRoll;
            Dice secondPlayerRoll;
            string winner = string.Empty;
            do
            {
                firstPlayerRoll = DiceRoll();
                secondPlayerRoll = DiceRoll();
                if (firstPlayerRoll.GetDiceSum > secondPlayerRoll.GetDiceSum)
                    winner = name1;
                else
                    winner = name2;
            }
            while (firstPlayerRoll.GetDiceSum == secondPlayerRoll.GetDiceSum);

            return winner;
       }

        public Dice DiceRoll()
        {
            Random randomMove = new Random();
            int leftDice = randomMove.Next(6) + 1;
            int rightDice = randomMove.Next(6) + 1;
            Dice newDice = new Dice(leftDice, rightDice);
            return newDice;

        }


        public void PrintCurrentDiceOption(GameLogic gameLogic)
        {
            Console.WriteLine("dice option left: ");
            foreach (int option in gameLogic.DiceOptions.DiceChoices)
            {
                Console.Write("{0} ", option);
            }
        }

        public void PrintMovesAvailable(GameLogic gameLogic)
        {
            foreach (Move move in gameLogic.PossibleMoves)
            {
                Console.WriteLine("possible source:{0},possible target{1}", move.sourceField + 1, move.targetField + 1);
            }
        }

    }
}
