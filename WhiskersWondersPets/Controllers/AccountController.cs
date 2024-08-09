using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WhiskersWondersPets.Models;

namespace WhiskersWondersPets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManger = userManger;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid) {
                //var user = await _userManger.FindByNameAsync(model.Username!);
                //var res = await _signInManager.PasswordSignInAsync(user, model.Password!, false, false);
                var result = await _signInManager.PasswordSignInAsync(model.Username!,model.Password!, false, false);
                if (result.Succeeded) {
                   return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // TODO create View page like 404
        public IActionResult AccessDenied() {
            return View();
        }
    }
}
