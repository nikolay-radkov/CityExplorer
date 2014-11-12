using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CityExplorer.Web.Startup))]
namespace CityExplorer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
