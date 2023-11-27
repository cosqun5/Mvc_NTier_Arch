using Business.Services.Abstract;
using Entities.Concrate;
using Entities.ViewModels.Abouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		public IActionResult Create()
		{
			
			return View();
		}
		[HttpPost]
		public async Task< IActionResult> Create(AboutCreatVM creatVM)
		{
			await _aboutService.Insert(creatVM);
			return RedirectToAction("Index");
		}
		public async Task< IActionResult> Delete(int id)
		{
			  await _aboutService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task< IActionResult> Update(int id)
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
		public async Task< IActionResult> Update(AboutUpdateVM updateVM)
		{
			await _aboutService.Update(updateVM);

			return RedirectToAction("Index");
		}
	}
}
