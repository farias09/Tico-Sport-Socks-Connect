using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicoSportSocksConnect.UI.Startup))]
namespace TicoSportSocksConnect.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
