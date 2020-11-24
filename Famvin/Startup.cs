using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Famvin.Startup))]
namespace Famvin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
