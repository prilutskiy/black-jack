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
            var iuser = repo.GetPlayer(username);
            var player = new Player(iuser.PlayerType,iuser.Username);
            player.Cash = iuser.Cash;
            player.Id = iuser.Id;
            return player;
        }
    }
}
