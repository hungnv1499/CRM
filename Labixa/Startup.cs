using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Labixa.Startup))]
namespace Labixa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
