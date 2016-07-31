using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Field
    {
       private int numberOfXStones;
       private int numberOfOStones;
   
       
       public Field()
        {
            numberOfXStones = 0;
            numberOfOStones = 0;
        }
       
      public int GetStoneByType(SoldierType color)
        {
            if (color == SoldierType.X)
                return numberOfXStones;
            else
                return numberOfOStones;
        }  
    
                
         
       public int GetXStoneNumber
        {
            set { numberOfXStones = value; }
            get { return numberOfXStones; }

        }

        public int GetOStoneNumber
        {
            set { numberOfOStones = value; }
            get { return numberOfOStones; }
        }

                      
        public bool IsAccsesibleField(SoldierType type)
        {
            if(type==SoldierType.O)
            {
                if (this.numberOfXStones > 1)                
                    return false;              
                else
                    return true;
            }
            else
            {
                if (this.numberOfOStones > 1)
                    return false;
                else
                    return true;
            }
        }

        public void AddToField(SoldierType color)
        {
            if (color == SoldierType.X)
                numberOfXStones++;
            else
                numberOfOStones++;
        }

        public void RemoveFromField(SoldierType color)
        {
            if (color == SoldierType.X)
            {
                numberOfXStones--;
            }
            else
                numberOfOStones--;
        }
    }
}
