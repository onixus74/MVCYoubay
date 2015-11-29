using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCYoubay.Startup))]
namespace MVCYoubay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
