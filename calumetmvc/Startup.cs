using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(calumetmvc.Startup))]
namespace calumetmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
