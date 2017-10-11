using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IngeDolan.Startup))]
namespace IngeDolan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
