using System;

namespace BlackJack.Common
{
    public interface IPlayerFactory
    {
        Player Create(PlayerType type, String username = "");
        Player LoadFromDataStorage(string username);
    }
}