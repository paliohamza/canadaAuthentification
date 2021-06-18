using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentif.Controllers
{
    public class RolsController : Controller
    {
        public UserManager<IdentityUser> um;
        public RoleManager<IdentityRole> rm;

        public RolsController(UserManager<IdentityUser> _um, RoleManager<IdentityRole> _rm)
        {
            um = _um;
            rm = _rm;
        }
        public async Task<IActionResult> Index()
        {
            IdentityRole adminrol = new IdentityRole { Name = "Admin" };
            IdentityRole inviterol = new IdentityRole { Name = "Guest" };


            IdentityUser user1 = await um.FindByIdAsync("54eee5dc-e9e6-429e-ac7e-8fd63e474e8d");//hicham
            IdentityUser user2 = await um.FindByIdAsync("a2577dbd-807d-4594-8ac5-0503c666cdf0");//hamza
            IdentityResult result = await rm.CreateAsync(adminrol);
            IdentityResult result2 = await rm.CreateAsync(inviterol);

            result = await um.AddToRoleAsync(user1, "Admin");
            result2 = await um.AddToRoleAsync(user2, "Guest");
            if (result.Succeeded)
            {
                return RedirectToPage("/");
            }
            return View();
        }
    }
}
