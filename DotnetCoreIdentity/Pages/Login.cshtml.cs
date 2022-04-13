using DotnetCoreIdentity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetCoreIdentity.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login LogModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> onPost(string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(LogModel.Email, LogModel.Password, LogModel.RememberMe, false);
                if(identityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError(string.Empty, "Username or Password is invalid");
            }
            return Page();
        }
    }
}
