using DataAccess;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Portfolio.ViewModel;

namespace Personal_Portfolio.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public HomeController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public async Task< IActionResult> Index()
		{
			HomeVM homeVM = new HomeVM()
			{
				Categories = await _appDbContext.Categories.ToListAsync()
			};
			return View(homeVM);
		}
	}
}
