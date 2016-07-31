using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Player
    {

        private SoldierType playerCheckerType;
        private string playerName;

        public Player(SoldierType newPlayerCheker,string newPlayerName)
        {
            playerCheckerType = newPlayerCheker;
            playerName = newPlayerName;
        }

        public SoldierType GetPlayerColor
        {
            get { return playerCheckerType; }
        }

        public string GetPlayerName
        {
            get { return playerName; }
        }

    }
}
