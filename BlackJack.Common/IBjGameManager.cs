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
        GameState IncreaseBet(int value);
        GameState DecreaseBet(int value);
        GameState Start();
        GameState Double();
        GameState Stand();
        GameState Hit();
        GameState Terminate();
    }
}
