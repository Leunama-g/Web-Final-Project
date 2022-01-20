using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clinic_Patient_Info_Management_System.Startup))]
namespace Clinic_Patient_Info_Management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
