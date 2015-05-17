using System;

namespace BlackJack.Server
{
    public interface IPlugin : IDisposable
    {
        string Name { get; }
        void DoWork(ServerContext context);
    }
}