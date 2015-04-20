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
        GameState Initialize();
        GameState IncreaseBet(int value);
        GameState DecreaseBet(int value);
        GameState Start();
        GameState Double();
        GameState Stand();
        GameState Hit();
        GameState Terminate();
        GameState Login(string username , string pass);
    }
}
