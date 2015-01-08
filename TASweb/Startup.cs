using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TASweb.Startup))]
namespace TASweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
