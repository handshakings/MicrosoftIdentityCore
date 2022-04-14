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


        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRepository.PasswordSigninAsync(loginModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentiel");
                }
            }
            return View(loginModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
