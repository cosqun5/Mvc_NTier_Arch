using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
	public class LanguageViewComponent : ViewComponent
	{
		private readonly ILanguageService _languageService;

		public LanguageViewComponent(ILanguageService languageService)
		{
			_languageService = languageService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _languageService.GetList();
			return View(result);
		}
	}
}
