using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackJack.Ui.Startup))]
namespace BlackJack.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
