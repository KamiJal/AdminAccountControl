using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminAccountControl.Startup))]
namespace AdminAccountControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
