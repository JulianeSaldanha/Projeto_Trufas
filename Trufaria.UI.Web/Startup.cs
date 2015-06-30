using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trufaria.UI.Web.Startup))]
namespace Trufaria.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
