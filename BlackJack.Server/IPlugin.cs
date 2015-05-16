namespace BlackJack.Server
{
    public interface IPlugin
    {
        void DoWork(ServerContext context);
    }
}