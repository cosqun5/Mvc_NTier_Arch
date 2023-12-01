using Business.Services.Abstract;
using DataAccess;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Portfolio.ViewModel;

namespace Personal_Portfolio.ViewComponents
{
	public class AboutViewComponent : ViewComponent
	{
		private readonly IAboutService _aboutService;

		public AboutViewComponent(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<About> abouts = await _aboutService.GetList();
			return View(abouts);
		}
	}
}
