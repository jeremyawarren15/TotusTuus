using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotusTuus.Web.Startup))]
namespace TotusTuus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
