using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
     public interface IGameLogic
    {
        void GetPossibleMoves();
        int GetWinner { get; }
    }
}
