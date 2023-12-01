using Business.Services.Abstract;
using DataAccess;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Portfolio.ViewModel;

namespace Personal_Portfolio.ViewComponents
{
	public class ContactViewComponent: ViewComponent
	{
		private readonly AppDbContext _appDbContext;
		private readonly IAboutService _aboutService;

		public ContactViewComponent(AppDbContext appDbContext, IAboutService aboutService)
		{
			_appDbContext = appDbContext;
			_aboutService = aboutService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			HomeVM homeVM = new HomeVM()
			{
				Categories = await _appDbContext.Categories.ToListAsync(),
				Abouts = await _aboutService.GetList()
			};
			return View(homeVM);
		}
	}
}
