using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErieHackChloroData.Startup))]
namespace ErieHackChloroData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
