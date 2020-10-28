using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPerfildeAcesso.Startup))]
namespace WebPerfildeAcesso
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
