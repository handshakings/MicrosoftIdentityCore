using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotnetCoreMVCIdentity.Controllers
{
    public class HomeController : Controller
    {
        public IHttpContextAccessor httpContext { get; }
        public HomeController(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public IActionResult Index()
        {
            var isUserAuthenticted = httpContext.HttpContext.User.Identity.IsAuthenticated;
            if(isUserAuthenticted)
            {
                var userId = httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.uid = userId ?? "";
            }
            return View();
        }


    }
}