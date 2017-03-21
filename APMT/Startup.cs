using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APMT.Startup))]
namespace APMT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
