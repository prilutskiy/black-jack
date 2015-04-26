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

        public ServerResponse(GameState state, bool callSuccessful, string msg = "Hello!")
        {
            GameState = state;
            MethodCallSucceed = callSuccessful;
            Message = msg;
        }
        public GameState GameState { get; set; }
        public Boolean MethodCallSucceed { get; set; }
        public String Message { get; set; }
    }

}