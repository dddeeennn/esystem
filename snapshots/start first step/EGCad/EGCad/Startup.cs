using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EGCad.Startup))]
namespace EGCad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
