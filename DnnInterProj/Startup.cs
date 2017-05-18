using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DnnInterProj.Startup))]
namespace DnnInterProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
