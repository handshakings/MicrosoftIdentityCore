using DotnetCoreMVCIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreMVCIdentity.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        //Inject UserManager
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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

    }
}
