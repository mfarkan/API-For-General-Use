using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ApiProject.TokenProvider;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ApiProject.Infrastructure;

[assembly: OwinStartup(typeof(ApiProject.Startup))]

namespace ApiProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());

            WebApiConfig.Register(config, container);

            SwaggerConfig.Register(config);




            OAuthBearerAuthenticationOptions options = new OAuthBearerAuthenticationOptions
            {
                Description = new AuthenticationDescription
                {
                    AuthenticationType = "password",
                    Caption = "Bearer Token"
                },
                AuthenticationMode = AuthenticationMode.Active
            };
            OAuthAuthorizationServerOptions serverOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                AllowInsecureHttp = true,
                Provider = new TokenProvider.TokenProvider(),
            };

            app.UseOAuthAuthorizationServer(serverOptions);
            app.UseOAuthBearerAuthentication(options);

            app.UseWebApi(config);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
