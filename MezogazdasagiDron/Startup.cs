using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MezogazdasagiDron.Startup))]
namespace MezogazdasagiDron
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}