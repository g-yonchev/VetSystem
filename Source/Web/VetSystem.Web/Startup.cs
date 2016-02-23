using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(VetSystem.Web.Startup))]

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
