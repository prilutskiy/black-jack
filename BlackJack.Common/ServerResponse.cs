using System;

namespace BlackJack.Common
{
    public enum MatchState
    {
        NotSet,
        Waiting,
        GameFound
    }
    [Serializable]
    public class ServerResponse
    {
        public GameState GameState { get; set; }
        public ServerMessageType ResponseType { get; set; }

        #region Auth
        public Boolean AuthSucceed { get; set; }
        public bool IsAuthenticated { get; set; }
        public String Username { get; set; }
        #endregion

        #region Error
        public String ErrorMessage { get; set; }
        #endregion

        #region Start game
        public MatchState MatchState { get; set; }
        public bool IsReady { get; set; }

        #endregion
    }

}