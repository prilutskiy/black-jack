using System;
using System.ComponentModel;

namespace BlackJack.Common
{
    public class StubPlayerFactory : IPlayerFactory
    {
        public Player Create(PlayerType type, String username = "")
        {
            switch (type)
            {
                case PlayerType.NotSet:
                    throw new InvalidEnumArgumentException("type");
                case PlayerType.Player:
                    //get player from database and return
                    return new Player(type, username);
                case PlayerType.Dealer:
                    return new Player(type, "Dealer");
                case PlayerType.Draw:
                    return new Player(PlayerType.Draw, "Draw");
                default:
                    throw new InvalidEnumArgumentException("type");
            }
        }

        public Player LoadFromDataStorage(string username)
        {
            return Create(PlayerType.Player, username);
        }
    }
}