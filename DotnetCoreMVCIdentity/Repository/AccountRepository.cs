using DotnetCoreMVCIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotnetCoreMVCIdentity.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHttpContextAccessor httpContext;

        //Inject UserManager
        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContext = httpContext;
        }

        public async Task<IdentityResult> CreateUserAsync(SignupUserModel userModel)
        {
            //to save user detail, identity provides 2 managers: UserManager and SignInManager
            var user = new ApplicationUser
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result =  await userManager.CreateAsync(user,userModel.Password);
            return result;
        }


        public async Task<SignInResult> PasswordSigninAsync(LoginUserModel userModel)
        {
            var result = await signInManager.PasswordSignInAsync(userModel.Email,userModel.Password,userModel.RememberMe,false);
            return result;
        }


        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }


        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            var identityResult = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return identityResult;
        }

    }
}
