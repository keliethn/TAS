using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(spd_tickets.Startup))]
namespace spd_tickets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
