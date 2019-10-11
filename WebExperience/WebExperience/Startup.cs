using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebExperience.Startup))]
namespace WebExperience
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
