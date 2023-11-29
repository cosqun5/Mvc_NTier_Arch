using Business.Services.Abstract;
using Business.Services.Concrate;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _featureService.GetList();
			return View(result);
		}

		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Feature feature)
		{
			await _featureService.Insert(feature);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _featureService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Feature feature = await _featureService.GetById(id);
			if (feature == null)
			{
				return View("Error");
			}

			return View(feature);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Feature update)
		{
			await _featureService.Update(update);

			return RedirectToAction("Index");
		}
	}
}
