using Business.Services.Abstract;
using Business.Services.Concrate;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
	public class SkillViewComponent:ViewComponent
	{
		private readonly ISkillsService _skillsServcie;

		public SkillViewComponent(ISkillsService skillsServcie)
		{
			_skillsServcie = skillsServcie;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<Skills> skills = await _skillsServcie.GetList();
			return View(skills);
		}
	}
}
