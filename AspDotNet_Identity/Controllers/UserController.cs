using AspDotNet_Identity.Models;
using AspDotNet_Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspDotNet_Identity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize] // if(User.Identity.IsAuthenticated == true)
        public async Task<IActionResult> Index()
        {
            // get user data
            //User.Identity.Name;
            //User.Identity.IsAuthenticated;

            Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            ApplicationUser user = await userManager.FindByIdAsync(userId);

            string color = User.Claims.FirstOrDefault(c => c.Type == "Color").Value;
            return View(user);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        /*
         * - Deals with part of model
         * - Validation
         * - extra data
         * 
         * 
         * => ViewModel
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                // mapping
                ApplicationUser user = new()
                {
                    UserName = registerVM.Username,
                    Email = registerVM.Email,
                    Address = registerVM.Address,
                    PasswordHash = registerVM.Password                  
                };
                //IdentityResult result = await userManager.CreateAsync(user);  // external hasing algorithm
                IdentityResult result = await userManager.CreateAsync(user,registerVM.Password);
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Index", "Instructors");

                    // add user to role
                    await userManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction("Login", "Account");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerVM);
        }
    }
}
