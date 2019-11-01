using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeIdentification.Startup))]
namespace PracticeIdentification
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
