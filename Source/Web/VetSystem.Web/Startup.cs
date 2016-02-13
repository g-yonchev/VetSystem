using Microsoft.Owin;
using Owin;
using VetSystem.Web;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace VetSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
