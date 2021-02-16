using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NETMVC_Upg1.Data
{
    public class AppUserClaims : UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        public AppUserClaims(
           UserManager<AppUser> userManager,
           RoleManager<IdentityRole> roleManager,
           IOptions<IdentityOptions> options)
           : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var _identity = await base.GenerateClaimsAsync(user);

            _identity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}" ?? ""));

            return _identity;
        }
    }
}
