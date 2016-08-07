using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGammonLogic;

namespace UIBackGammon
{
    public interface IGame
    {
        void GameEnd();
        void Play();
        void DoAction(Player player);
        void StartGame();
    }
}
