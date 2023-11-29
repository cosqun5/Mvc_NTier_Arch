using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
	public class ExperienceViewComponent:ViewComponent
	{
		private readonly IExperienceService _experienceService;

		public ExperienceViewComponent(IExperienceService experienceService)
		{
			_experienceService = experienceService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _experienceService.GetList();
			return View(result);
		}
	}
}
