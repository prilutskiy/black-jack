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
        void Start();
        void Hit();
        void Stand();
        void Double();
        void Exit();
    }
}
