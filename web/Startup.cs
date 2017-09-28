using PoliclinicoWeb.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoliclinicoWeb.Startup))]
namespace PoliclinicoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ParamaterConfig.Initialize();
            EnumConfig.Start();
        }
    }
}
