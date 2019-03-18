using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LawyerApp.Startup))]
namespace LawyerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
