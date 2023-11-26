using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _aboutService.GetList();
			return View(result);
		}
		public async Task<IActionResult> Create()
		{
			var result = await _aboutService.GetList();
			return View(result);
		}
	}
}
