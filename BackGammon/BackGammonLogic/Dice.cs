using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Dice
    {
        private int firstCube;
        private int secondCube;
        private int[] moveChoices;
        private int choisesLeft;
        private int sumOfDice;
      


        public Dice(int firstCubeResult,int SecondCubeResult)
        {
            firstCube = firstCubeResult;
            secondCube = SecondCubeResult;

            if (firstCubeResult==SecondCubeResult)
            {
                moveChoices = new  int[]{ firstCubeResult, firstCubeResult, firstCubeResult, firstCubeResult };
                choisesLeft = 4;
            }
            if (firstCubeResult < SecondCubeResult)
            {
                moveChoices = new int[] { firstCubeResult, SecondCubeResult };
                choisesLeft = 2;
            }
            else
            {
                moveChoices = new int[] { SecondCubeResult, firstCubeResult };
                choisesLeft = 2;
            }
        }

        public Dice(int[] newMoveChoises,int newChoisesLeft)
        {
            moveChoices = newMoveChoises;
            choisesLeft = newChoisesLeft;
        }
        public int GetChoicesLeft
        {
            get { return choisesLeft; }
        }
         

        public int [] GetPossibleDiceOption
        {
            get { return moveChoices; }
        }

        public int GetDiceSum
        {
            get
            {
                sumOfDice = firstCube + secondCube;
                return sumOfDice;
            }
        }
        
        public Dice ReduceCubeOption(int number)
        {
           if(moveChoices.Length==0)
            {
                throw new Exception("all dice options are used");
            }

            bool isNotUsed = true;
            int[] updatedChoises = new int[moveChoices.Length - 1];
            int choicesLeft = 0;

            for(int i=0;i<moveChoices.Length;i++)
            {
                if(isNotUsed && number==moveChoices[i])
                {
                    isNotUsed = false;
                    continue;
                }
                else
                {
                    updatedChoises[choicesLeft++] = moveChoices[i];   
                }
            }
            if (!isNotUsed)
            {
                return new Dice(updatedChoises, choicesLeft);
            }
            else
                throw new Exception("the number not match any dice options");


        }

    }
}
