using Business.Services.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Personal_Portfolio.ViewModel;

namespace Personal_Portfolio.ViewComponents
{
	public class LeftMenuViewComponent:ViewComponent
	{
		private readonly IAboutService _aboutService;
		private readonly IFeatureService _featureService;



		public LeftMenuViewComponent(IAboutService aboutService, IFeatureService featureService)
		{
			_aboutService = aboutService;
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			MenuVM menuVM = new MenuVM()
			{
			  Abouts  = await _aboutService.GetList(),
			  Features = await _featureService.GetList(),

			};
			return View(menuVM);
		}
	}
}
