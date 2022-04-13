using DotnetCoreMVCIdentity.Models;
using DotnetCoreMVCIdentity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreMVCIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        //Inject account repository
        //before using this repository, register it as service in program.cs class
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }



        [Route("signup")]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }


        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignupUserModel userModel)
        {
            if(ModelState.IsValid)
            {
                var result = await accountRepository.CreateUserAsync(userModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }                    
                }
            }
            return View();
        }
    }
}
