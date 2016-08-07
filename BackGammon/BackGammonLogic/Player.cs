using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Player
    {

        public SoldierType playerCheckerType { get; private set; }
        public string playerName { get; private set; }

        public Player(SoldierType newPlayerCheker,string newPlayerName)
        {
            playerCheckerType = newPlayerCheker;
            playerName = newPlayerName;
        }
    }
}
