using Entities.Concrate.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Personal_Portfolio.Areas.Admin.ViewModels;
using System.Data;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;


        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ViewUsers()
        {
            var usersWithRoles = _userManager.Users.Select(user => new UserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                CurrentRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
            }).ToList();

            return View(usersWithRoles);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // İstifadəçinin cari rolu silinir
                var currentRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                if (!string.IsNullOrEmpty(currentRole))
                {
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                }

                // Yeni rolu əlavə et
                await _userManager.AddToRoleAsync(user, newRole);
            }

            return RedirectToAction(nameof(ViewUsers));
        }
    }
}
