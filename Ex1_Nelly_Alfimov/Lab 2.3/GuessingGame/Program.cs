using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program GussingGame = new Program();
            int secretNumber = new Random().Next(1, 100);
            int userGuess = 0, numberOfShots = 1;
            Console.WriteLine("Please guess The secret number");
            userGuess = int.Parse(Console.ReadLine());

            while ((userGuess != secretNumber) && (numberOfShots!=7))
            {
               
                    if (GussingGame.IsTooBig(secretNumber, userGuess))
                    {
                        Console.WriteLine("The number you guessed is to big\n");
                        numberOfShots++;
                    }
                    else if (GussingGame.isTooSmall(secretNumber, userGuess))
                    {
                        Console.WriteLine("The number you guessed is to small\n");
                        numberOfShots++;
                    }

                userGuess = int.Parse(Console.ReadLine());                
            }
            if(numberOfShots==7)
            {
                Console.WriteLine("you Failed");
            }
            else
            {
                Console.WriteLine("you won");
            }
           
        }

        public bool IsTooBig(int i_secretNumber, int i_userGuess)//checking if the number is bigger than the secret number
        {
            bool isBigger = false;

            if (i_secretNumber < i_userGuess)
            {
                isBigger = true;
            }

            return isBigger;
        }

        public bool isTooSmall(int i_SecretNumber, int i_UserGuess)//cheking if the number is smaller than the secret number
        {
            bool isSmaller = false;

            if (i_SecretNumber > i_UserGuess)
            {
                isSmaller = true;
            }
            return isSmaller;
        }
    }
}

