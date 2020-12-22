using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class CustomProfileService : IProfileService
    {
        public CustomProfileService()
        {
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var nameClaim = context.Subject.FindAll(JwtClaimTypes.Name);
            context.IssuedClaims.AddRange(nameClaim);

            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
            context.IssuedClaims.AddRange(roleClaims);

            var firstNameClaim = context.Subject.FindAll(JwtClaimTypes.GivenName);
            context.IssuedClaims.AddRange(firstNameClaim);

            var lastnameClaim = context.Subject.FindAll(JwtClaimTypes.FamilyName);
            context.IssuedClaims.AddRange(lastnameClaim);

            var usernameClaim = context.Subject.FindAll(JwtClaimTypes.PreferredUserName);
            context.IssuedClaims.AddRange(usernameClaim);

            var emailClaim = context.Subject.FindAll(JwtClaimTypes.Email);
            context.IssuedClaims.AddRange(emailClaim);

            await Task.CompletedTask;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.CompletedTask;
        }
    }
}
