using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_II.Startup))]
namespace Vidly_II
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
