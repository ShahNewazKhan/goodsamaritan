using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(assn2.Startup))]
namespace assn2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
