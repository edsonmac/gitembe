using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gitembe.Startup))]
namespace gitembe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
