using System;
using System.ComponentModel;

namespace BlackJack.Common
{
    public class StubPlayerFactory : PlayerFactory
    {
        public override Player LoadFromDataStorage(string username)
        {
            return Create(PlayerType.Player, username);
        }
    }
}