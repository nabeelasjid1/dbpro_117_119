using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartSchoolManagementSystem.Startup))]
namespace SmartSchoolManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
