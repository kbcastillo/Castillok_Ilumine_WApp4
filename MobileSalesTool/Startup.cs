using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileSalesTool.Startup))]
namespace MobileSalesTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
