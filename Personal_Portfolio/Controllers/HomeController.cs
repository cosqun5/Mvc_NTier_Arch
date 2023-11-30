using Business.Services.Abstract;
using DataAccess;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Enums;
using Personal_Portfolio.ViewModel;

namespace Personal_Portfolio.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _appDbContext;
		private readonly IContactService _contactService;
		private readonly IAboutService _aboutService;

		public HomeController(AppDbContext appDbContext, IContactService contactService, IAboutService aboutService)
		{
			_appDbContext = appDbContext;
			_contactService = contactService;
			_aboutService = aboutService;
		}
		public async Task< IActionResult> Index()
		{
			HomeVM homeVM = new HomeVM()
			{
				Categories = await _appDbContext.Categories.ToListAsync(),
				Abouts = await _aboutService.GetList()
			};
			return View(homeVM);
		}

		public async Task<IActionResult> Contact(Contact contact)
		{
			contact.Date= Convert.ToDateTime(DateTime.Now.ToShortDateString());
			await _contactService.Insert(contact);

			// Mesaj göndərildikdən sonra, səhifə yenilənmədən SweetAlert-i göndər
			return Json(new { success = true, message = "Mesajınız göndərildi!" });
		}
	}
}
