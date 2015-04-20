using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(firstWeek.Startup))]
namespace firstWeek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
