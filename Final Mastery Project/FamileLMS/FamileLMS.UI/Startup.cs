using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamileLMS.UI.Startup))]
namespace FamileLMS.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
