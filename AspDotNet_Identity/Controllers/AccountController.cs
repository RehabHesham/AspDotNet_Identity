using AspDotNet_Identity.Models;
using AspDotNet_Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspDotNet_Identity.Controllers
{
    public class AccountController
        (UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginVM.username);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (found)
                    {
                        // create cookie
                        //await signInManager.SignInAsync(user, isPersistent: loginVM.IsPresistent);

                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim("Color","Red"),
                            new Claim("Address",user.Address),
                        };
                        await signInManager.SignInWithClaimsAsync(user, loginVM.IsPresistent, claims);
                        return RedirectToAction("Index", "User");
                    }
                }

                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(loginVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
