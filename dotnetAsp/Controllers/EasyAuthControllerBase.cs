using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetAsp.Controllers
{
    [Authorize]
    public abstract class EasyAuthControllerBase : ControllerBase
    {
        public record AuthDetails(string Username, string Email, string Name);

        public AuthDetails EasyAuthUser
        {
            get
            {
                var allClaims = this.User.Claims.Select(x => new { x.Type, x.Value });
                return new AuthDetails
                (
                    Username: allClaims.FirstOrDefault(x => x.Type == "preferred_username")?.Value,
                    Email: allClaims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value,
                    Name: allClaims.FirstOrDefault(x => x.Type == "name")?.Value
                );
            }
        }
    }
}