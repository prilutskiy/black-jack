namespace BlackJack.Common
{
    public interface IBjGameManager
    {
        /// <summary>
        ///     Ctor statements must be placed in here or sort of
        /// </summary>
        /// <returns></returns>
        GameState Initialize();

        GameState IncreaseBet(int value);
        GameState DecreaseBet(int value);
        GameState Start(GameType gameType);
        GameState Stop();
        GameState Double();
        GameState Stand();
        GameState Hit();
        GameState Login(string username, string pass);
        GameState Logoff();
        GameState GetState();
        bool IsAuthenticated();
        GameState GetLeaderboard();
    }
}