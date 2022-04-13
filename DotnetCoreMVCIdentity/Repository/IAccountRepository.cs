using DotnetCoreMVCIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreMVCIdentity.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignupUserModel userModel);
    }
}