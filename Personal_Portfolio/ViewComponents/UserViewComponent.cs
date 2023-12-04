using Entities.Concrate.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Personal_Portfolio.Areas.Admin.ViewModels;
using System.Data;
using System.Security.Claims;

namespace Personal_Portfolio.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserViewComponent(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    var userViewModel = new UserViewModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        CurrentRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                    };

                    return View(new List<UserViewModel> { userViewModel });
                }
            }

            return View(new List<UserViewModel>());
        }
    }

}
