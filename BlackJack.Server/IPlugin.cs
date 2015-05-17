namespace BlackJack.Server
{
    public interface IPlugin
    {
        string Name { get; }
        void DoWork(ServerContext context);
    }
}