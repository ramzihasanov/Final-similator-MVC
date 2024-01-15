using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FinalExc.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DashBoardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser()
            {
                Fullname = "Admin",
                UserName="Admin111"
            };
           await userManager.CreateAsync(user, "Admin111");
           return View();
        }
        public async Task<IActionResult> CreateRoll()
        {
            IdentityRole rol1 = new IdentityRole("Admin");
            IdentityRole rol2 = new IdentityRole("user");

            await roleManager.CreateAsync(rol1);
            await roleManager.CreateAsync(rol2);
            return View();

        }
        public async Task<IActionResult> AddRoll()
        {
            var appuser = await userManager.FindByNameAsync("Admin111");
            if(appuser != null)
            await userManager.AddToRoleAsync(appuser, "Admin");
            return View();
        }
    }
}
