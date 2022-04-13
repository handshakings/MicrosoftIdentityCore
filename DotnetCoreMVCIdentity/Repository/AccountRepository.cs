using DotnetCoreMVCIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreMVCIdentity.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> userManager;

        //Inject UserManager
        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignupUserModel userModel)
        {
            //to save user detail, identity provides 2 managers: UserManager and SignInManager
            var user = new IdentityUser
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result =  await userManager.CreateAsync(user,userModel.Password);
            return result;
        }

    }
}
