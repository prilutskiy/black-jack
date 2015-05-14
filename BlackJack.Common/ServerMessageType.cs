namespace BlackJack.Common
{
    public enum ServerMessageType
    {
        NotSet,
        StartGame,
        InGame,
        Auth,
        Deauth,
        Leaderboard,
        Error,
        CheckAuth,
        IsGameReady,
        AuthInfo
    }
}