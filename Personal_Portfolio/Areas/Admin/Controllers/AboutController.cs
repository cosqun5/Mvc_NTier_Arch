using Business.Services.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using Entities.ViewModels.Abouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly IAboutRepository _aboutRepository;

		public AboutController(IAboutService aboutService, IAboutRepository aboutRepository)
		{
			_aboutService = aboutService;
			_aboutRepository = aboutRepository;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _aboutService.GetList();
			return View(result);
		}
		[Authorize(Roles = "Moderator,Admin")]
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AboutCreatVM creatVM)
		{
			if (!ModelState.IsValid)
			{
				return View(creatVM);
			}
			if (await _aboutRepository.IsExistsAsync(p => p.Title == creatVM.Title))
			{
				ModelState.AddModelError("Title", "Bu başlıq artıq mövcuddur.");
				return View(creatVM);
			}
			await _aboutService.Insert(creatVM);
			return RedirectToAction("Index");
		}
        [Authorize(Roles = "Moderator,Admin")]
        public async Task<IActionResult> Delete(int id)
		{
			await _aboutService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
        [Authorize(Roles = "Moderator,Admin")]
        public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			About about = await _aboutService.GetById(id);
			if (about == null)
			{
				return View("Error");
			}
			AboutUpdateVM updateVM = new AboutUpdateVM
			{
				Id = id,
				Title = about.Title,
				Degree = about.Degree,
				Description = about.Description,
				Email = about.Email,
				Phone = about.Phone,
				Age = about.Age,
				City = about.City,

			};
			return View(updateVM);
		}
		[HttpPost]
		public async Task<IActionResult> Update(AboutUpdateVM updateVM)
		{
			await _aboutService.Update(updateVM);

			return RedirectToAction("Index");
		}
	}
}
