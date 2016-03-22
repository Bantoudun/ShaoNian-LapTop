using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNetMVC.Startup))]
namespace ASPNetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
