using Business.Services.Abstract;
using Business.Services.Concrate;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Moderator,Admin")]

    public class LanguageController : Controller
	{
		private readonly ILanguageService _languageService;

		public LanguageController(ILanguageService languageService)
		{
			_languageService = languageService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _languageService.GetList();
			return View(result);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Language language)
		{
			await _languageService.Insert(language);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _languageService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Language language = await _languageService.GetById(id);
			if (language == null)
			{
				return View("Error");
			}

			return View(language);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Language update)
		{
			await _languageService.Update(update);

			return RedirectToAction("Index");
		}
	}
}
