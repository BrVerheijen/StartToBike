using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartToBike.Startup))]
namespace StartToBike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
