using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNet_Identity.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController(RoleManager<IdentityRole> roleManager) : Controller
    {

        public IActionResult Index()
        {
            List<IdentityRole> roles = roleManager.Roles.ToList();
            
            return View(roles);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IdentityRole role)
        {
            if(ModelState.IsValid)
            {
               IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach(var error in  result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(role);
        }
    }
}
