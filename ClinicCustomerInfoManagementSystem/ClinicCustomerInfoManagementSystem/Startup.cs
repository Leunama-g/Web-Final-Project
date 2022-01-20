using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicCustomerInfoManagementSystem.Startup))]
namespace ClinicCustomerInfoManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
