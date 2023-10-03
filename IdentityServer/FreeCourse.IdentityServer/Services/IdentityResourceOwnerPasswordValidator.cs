using FreeCourse.IdentityServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
                _userManager = userManager;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);

            if (existUser==null)
            {
               var error = new Dictionary<string, object>();
                error.Add("error",new List<string> { "Email or password is wrong hehehhe"});
                context.Result.CustomResponse = error;
                return;
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser,context.Password);
            if (passwordCheck == false)
            {
                var error = new Dictionary<string, object>();
                error.Add("error", new List<string> { "Email or password is wrong" });
                context.Result.CustomResponse = error;
                return;
            }
            //so that identity server can understand
            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
