using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetConnection.Startup))]
namespace PetConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
