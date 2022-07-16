using IdentityModel;
using IdentityProvider.Dao;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityProvider.Quickstart
{
    public class IdentityClaimsProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<IdentityUser> _claimsFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _kt1;

        public IdentityClaimsProfileService(UserManager<IdentityUser> userManager,
            IUserClaimsPrincipalFactory<IdentityUser> claimsFactory,
            ApplicationDbContext kt1)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _kt1 = kt1;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = principal.Claims.ToList();
            var userKt = await _kt1.User.FirstOrDefaultAsync(x => x.UserName == user.UserName);

            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            claims.Add(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.UserName));
            claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.IdentityProvider, user.Id));


            if (userKt != null)
            {

                claims.Add(new System.Security.Claims.Claim("POSCode", userKt.POSCode));
                var shiftHandover = (from sh in _kt1.ShiftHandover
                                     join s in _kt1.Shift on new { sh.ShiftCode, sh.POSCode } equals new { s.ShiftCode, s.POSCode }
                                     where sh.POSCode == userKt.POSCode
                                     orderby sh.StartTime descending
                                     select new
                                     {
                                         ShiftHandoverID = sh.ShiftHandoverID,
                                         HandoverIndex = sh.HandoverIndex
                                     }
                            ).OrderByDescending(o => o.HandoverIndex).AsQueryable();

                var shData = await shiftHandover.FirstOrDefaultAsync();
                if (shData != null)
                {
                    claims.Add(new System.Security.Claims.Claim("ShiftHandover", shData.ShiftHandoverID.ToString()));
                }
                else
                {
                    claims.Add(new System.Security.Claims.Claim("ShiftHandover", null));
                }
            }
            else
            {
                claims.Add(new System.Security.Claims.Claim("POSCode", null));
                claims.Add(new System.Security.Claims.Claim("ShiftHandover", null));
            }


            foreach (string role in roles)
            {
                claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.Role, role));
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
