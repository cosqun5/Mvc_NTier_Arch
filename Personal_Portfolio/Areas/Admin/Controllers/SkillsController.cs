using Business.Services.Abstract;
using Business.Services.Concrate;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SkillsController : Controller
	{
		private readonly ISkillsService _skillsServcie;

		public SkillsController(ISkillsService skillsServcie)
		{
			_skillsServcie = skillsServcie;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _skillsServcie.GetList();
			return View(result);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Skills skills)
		{
			await _skillsServcie.Insert(skills);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _skillsServcie.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Skills skills = await _skillsServcie.GetById(id);
			if (skills == null)
			{
				return View("Error");
			}

			return View(skills);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Skills update)
		{
			await _skillsServcie.Update(update);

			return RedirectToAction("Index");
		}
	}
}
