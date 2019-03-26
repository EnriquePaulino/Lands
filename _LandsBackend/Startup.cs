using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LandsBackend.Startup))]
namespace LandsBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
