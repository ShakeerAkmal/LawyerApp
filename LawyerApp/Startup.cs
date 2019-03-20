using Microsoft.Owin;
using Owin;
using LawyerApp.Models;

[assembly: OwinStartupAttribute(typeof(LawyerApp.Startup))]
namespace LawyerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext appDb = new ApplicationDbContext();
            
        }
    }
}
