using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Field
    {
       public int NumberOfXStones { get; set; }
       public int NumberOfOStones { get; set; }
   
       
       public Field()
        {
            NumberOfXStones = 0;
            NumberOfOStones = 0;
        }
       
      public int GetStoneByType(SoldierType color)
        {
            if (color == SoldierType.X)
                return NumberOfXStones;
            else
                return NumberOfOStones;
        }  
    
                                   
        public bool IsAccsesibleField(SoldierType type)
        {
            if(type==SoldierType.O)
            {
                if (NumberOfXStones > 1)                
                    return false;              
                else
                    return true;
            }
            else
            {
                if (NumberOfOStones > 1)
                    return false;
                else
                    return true;
            }
        }

        public void AddToField(SoldierType color)
        {
            if (color == SoldierType.X)
                NumberOfXStones++;
            else
                NumberOfOStones++;
        }

        public void RemoveFromField(SoldierType color)
        {
            if (color == SoldierType.X)
            {
                NumberOfXStones--;
            }
            else
                NumberOfOStones--;
        }
    }
}
