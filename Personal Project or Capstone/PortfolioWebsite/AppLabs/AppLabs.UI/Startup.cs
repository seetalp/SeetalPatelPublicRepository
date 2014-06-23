using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppLabs.UI.Startup))]
namespace AppLabs.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
