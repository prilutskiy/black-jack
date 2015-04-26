using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public interface IBjGameManager
    {
        /// <summary>
        /// Ctor statements must be placed in here or sort of
        /// </summary>
        /// <returns></returns>
        GameState Initialize(Player player, Player opponent);
        GameState IncreaseBet(int value);
        GameState DecreaseBet(int value);
        GameState Start();
        GameState Stop();
        GameState Double();
        GameState Stand();
        GameState Hit();
        GameState Login(string username , string pass);
        GameState Logoff();
        GameState GetState();
        bool IsAuthenticated();
        GameState GetLeaderboard();
    }
}
