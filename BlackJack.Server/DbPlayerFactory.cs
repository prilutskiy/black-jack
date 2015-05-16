using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.Server
{
    class DbPlayerFactory : PlayerFactory
    {
        public override  Player LoadFromDataStorage(string username)
        {
            var repo = new BlackJackRepository();
            var user = repo.GetPlayer(username) as Player;
            return user;
        }
    }
}
