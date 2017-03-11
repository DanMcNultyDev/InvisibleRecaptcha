using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvisibleRecaptcha.Startup))]
namespace InvisibleRecaptcha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
