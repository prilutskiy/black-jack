using System;
using System.ComponentModel;

namespace BlackJack.Common
{
    public abstract class PlayerFactory
    {
        public virtual Player Create(PlayerType type, String username = "")
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
        public abstract Player LoadFromDataStorage(string username);
    }
}