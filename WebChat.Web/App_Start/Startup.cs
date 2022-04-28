using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using WebChat.BLL.Interfaces;
using WebChat.BLL.Services;

[assembly: OwinStartup(typeof(WebChat.Web.App_Start.Startup))]

namespace WebChat.Web.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            app.MapSignalR();
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("AccountController");
        }
    }
}
