using Business.Services.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Moderator,Admin")]

    public class ExperienceController : Controller
	{
		private readonly IExperienceService _experienceService;

		public ExperienceController(IExperienceService experienceService)
		{
			_experienceService = experienceService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _experienceService.GetList();
			return View(result);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Experience experience)
		{
			await _experienceService.Insert(experience);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _experienceService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Experience experience = await _experienceService.GetById(id);
			if (experience == null)
			{
				return View("Error");
			}
			//Experience update = new Experience
			//{
			//	Id = id,
			//	Name = experience.Name,
			//	Description = experience.Description,
			//	Start = experience.Start,
			//	End = experience.End,

			//};
			return View(experience);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Experience update)
		{
			await _experienceService.Update(update);

			return RedirectToAction("Index");
		}
	}
}
