using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSSProj.Startup))]
namespace CSSProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
