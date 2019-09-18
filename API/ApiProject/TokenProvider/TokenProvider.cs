using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ApiProject.TokenProvider
{
    public class TokenProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        /// <summary>
        /// Called when a request to the Token endpoint arrives with a "grant_type" of "password".
        /// This occurs when the user has provided name and password credentials directly into the client application's user interface,
        /// and the client application is using those to acquire an "access_token" and optional "refresh_token"
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (context.UserName == "BurganWallet" && context.Password == "123456")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "surname", "Smith"
                    },
                    {
                        "age", "20"
                    },
                    {
                    "gender", "Male"
                    }
                });

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Unauthorized");
                context.Rejected();
            }
        }
        /// <summary>
        /// Called at the final stage of a successful Token endpoint request. 
        /// An application may implement this call in order to do any final modification of the claims being used to issue access or refresh tokens. 
        /// This call may also be used in order to add additional response parameters to the Token endpoint's json response body.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}