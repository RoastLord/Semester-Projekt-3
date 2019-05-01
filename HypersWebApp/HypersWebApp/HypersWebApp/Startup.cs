using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HypersWebApp.Startup))]
namespace HypersWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
