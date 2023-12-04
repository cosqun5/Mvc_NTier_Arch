using Business.Services.Abstract;
using Business.Services.Concrate;
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
		private readonly IContactService _contactService;
		private readonly IAboutService _aboutService;
		private readonly IPortfolioService _portfolioService;

        public HomeController(AppDbContext appDbContext, IContactService contactService, IAboutService aboutService, IPortfolioService portfolioService)
        {
            _appDbContext = appDbContext;
            _contactService = contactService;
            _aboutService = aboutService;
            _portfolioService = portfolioService;
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
			contact.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			await _contactService.Insert(contact);

			// Mesaj göndərildikdən sonra, səhifə yenilənmədən SweetAlert-i göndər
			return Json(new { success = true, message = "Mesajınız göndərildi!" });
		}

		// CV faylının yüklənməsi üçün action metodu
		public IActionResult DownloadCV()
		{
			// Verilənlər bazasından CV məlumatlarını əldə etmək üçün lazım olan əməliyyatları burada yerinə yetirin
			// Məsələn, _dbContext.CVler.FirstOrDefault() kimi bir əməliyyatla verilənlər bazasından CV obyektini əldə edin
			// Ardından, CV obyektindən CV faylının məlumatlarını alın

			var cvFromDatabase = _appDbContext.Cvs.FirstOrDefault();

			if (cvFromDatabase == null)
			{
				// Əgər CV məlumatları tapılmadısa, 404 Not Found statusu qaytarın
				return NotFound();
			}

			byte[] cvFileData = cvFromDatabase.CVData;
			string cvFileName = "YourCVFileName.pdf"; // CV faylının adı

			// Faylı response-a əlavə edir və göndərir
			return File(cvFileData, "application/pdf", cvFileName);
		}

        public async Task<IActionResult> Detail(int id)
        {
            Portfolio portfolio = await _appDbContext.Portfolios
				.Include(p=>p.PortfolioImages)
                .Include(p => p.Category) // Include metodu ile Category'yi yükleyin
                .FirstOrDefaultAsync(p => p.Id == id);

            if (portfolio == null)
            {
				return RedirectToAction("Error");
            }

            return View(portfolio);
        }
		public IActionResult Error()
		{
			return View();
		}

    }
}
