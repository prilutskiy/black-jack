using System;

namespace BlackJack.Common
{
    public enum ServerResponseType
    {
        NotSet,
        GameState,
        NetworkRelated,
    }
    [Serializable]
    public class ServerResponse
    {
        public ServerResponse()
        {
            
        }

        public ServerResponse(GameState state, bool callSuccessful)
        {
            GameState = state;
            MethodCallSucceed = callSuccessful;
        }
        public GameState GameState { get; set; }
        public Boolean MethodCallSucceed { get; set; }
    }

}