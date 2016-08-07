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
        public int[] DiceChoices { get; private set; }
        public int ChoisesLeft { get; private set; }
        private int sumOfDice;
      


        public Dice(int firstCubeResult,int secondCubeResult)
        {
            firstCube = firstCubeResult;
            secondCube = secondCubeResult;

            if (firstCubeResult==secondCubeResult)
            {
                DiceChoices = new  int[]{ firstCubeResult, firstCubeResult, firstCubeResult, firstCubeResult };
                ChoisesLeft = 4;
            }
            if (firstCubeResult < secondCubeResult)
            {
                DiceChoices = new int[] { firstCubeResult, secondCubeResult };
                ChoisesLeft = 2;
            }
            else
            {
                DiceChoices = new int[] { secondCubeResult, firstCubeResult };
                ChoisesLeft = 2;
            }
        }

        public Dice(int[] newMoveChoises,int newChoisesLeft)
        {
            DiceChoices = newMoveChoises;
            ChoisesLeft = newChoisesLeft;
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
          
            bool isNotUsed = true;
            int[] updatedChoises = new int[DiceChoices.Length - 1];
            int choicesLeft = 0;

            for(int i=0;i<DiceChoices.Length;i++)
            {
                if(isNotUsed && number==DiceChoices[i])
                {
                    isNotUsed = false;
                    continue;
                }
                else
                {
                    updatedChoises[choicesLeft++] = DiceChoices[i];   
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
