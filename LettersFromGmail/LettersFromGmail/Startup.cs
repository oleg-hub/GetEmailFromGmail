using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LettersFromGmail.Startup))]
namespace LettersFromGmail
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
