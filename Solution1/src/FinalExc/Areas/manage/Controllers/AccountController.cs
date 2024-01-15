using FinalExc.Areas.ViewModel;
using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExc.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = null;
            user= await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user == null)
                ModelState.AddModelError("", "invalid username or password");
           var result =await _signInManager.PasswordSignInAsync(user,"Admin111",false , false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "invalid username or password");

            }
            return RedirectToAction("Index","DashBoard");
        }


    }
}
