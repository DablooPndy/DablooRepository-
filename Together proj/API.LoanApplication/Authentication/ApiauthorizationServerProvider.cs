using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace API.LoanApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiauthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "underwriter" && context.Password == "underwriter")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "underwriter"));
                identity.AddClaim(new Claim("username", "underwriter"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Underwriter"));
                context.Validated(identity);
            }
            else if (context.UserName == "broker" && context.Password == "broker")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "broker"));
                identity.AddClaim(new Claim("username", "broker"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Broker"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}