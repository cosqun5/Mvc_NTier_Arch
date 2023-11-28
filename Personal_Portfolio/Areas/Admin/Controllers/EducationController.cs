using Business.Services.Abstract;
using Business.Services.Concrate;
using Entities.Concrate;
using Entities.ViewModels.Abouts;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EducationController : Controller
	{
		private readonly IEducationService _educationService;

		public EducationController(IEducationService educationService)
		{
			_educationService = educationService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _educationService.GetList();
			return View(result);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Education education)
		{
			await _educationService.Insert(education);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _educationService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Education education = await _educationService.GetById(id);
			if (education == null)
			{
				return View("Error");
			}
			return View(education);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Education update)
		{
			await _educationService.Update(update);

			return RedirectToAction("Index");
		}
	}
}
