using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityProvider.Quickstart.Account.PasswordModel;

namespace IdentityProvider.Quickstart.Account
{
    [SecurityHeaders]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PasswordController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public readonly IConfiguration _configuration;

        public PasswordController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<object> ResetPassword(ResetPasswordModel model)
        {
            if (string.IsNullOrEmpty(model.ClientSecrets))
            {
                throw new Exception("ClientSecrets not Empty");
            }
            if (model.ClientSecrets != _configuration.GetValue<string>("ClientSecrets"))
            {
                return new
                {
                    succeeded = false,
                    errors = new List<object>
                     {
                         new
                         {
                             description= "Chữ ký xác thực của server không đúng"
                         }
                     }
                };
            }


            if (!string.IsNullOrEmpty(model.PasswordOld))
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (!await _userManager.CheckPasswordAsync(user, model.PasswordOld))
                {
                    return new
                    {
                        succeeded = false,
                        errors = new List<object>
                        {
                             new
                             {
                                 description= "Mật khẩu cũ không đúng"
                             }
                        }
                    };
                }
            }

            var userData = await _userManager.FindByNameAsync(model.UserName);
            var getToken = await _userManager.GeneratePasswordResetTokenAsync(userData);
            var result = await _userManager.ResetPasswordAsync(userData, getToken, model.Password);
            return result;
        }
    }
}
