using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
	public class EducationViewComponent : ViewComponent
	
	{
		private readonly IEducationService _educationService;

		public EducationViewComponent(IEducationService educationService)
		{
			_educationService = educationService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _educationService.GetList();
			return View(result);
		}
	}
}
