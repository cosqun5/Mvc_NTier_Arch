using Business.Services.Abstract;
using Business.Services.Concrate;
using Entities.Concrate;
using Entities.ViewModels.Abouts;
using Entities.ViewModels.Portfolios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PortfolioController : Controller
	{
		private readonly IPortfolioService _portfolioService;
		private readonly ICategoryService _categoryService;

		public PortfolioController(IPortfolioService portfolioService, ICategoryService categoryService)
		{
			_portfolioService = portfolioService;
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index()
		{
			var result = await _portfolioService.GetList();
			return View(result);
		}
		public async Task<IActionResult> Create()
		{
			PortfolioCreateVM createVM = new PortfolioCreateVM()
			{
				Categories = await _categoryService.GetList()
			};
			return View(createVM);
		}
		[HttpPost]
		public async Task<IActionResult> Create(PortfolioCreateVM creatVM)
		{
			await _portfolioService.Insert(creatVM);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update(int id)
		{
			Portfolio portfolio = await _portfolioService.GetById(id);

			if (portfolio == null)
			{
				return NotFound();
			}
			// Digər xüsusiyyətləri PortfolioUpdateVM-ə çevirin
			PortfolioUpdateVM updateVM = new PortfolioUpdateVM
			{
				Id = portfolio.Id,
				Name = portfolio.Name,
				Description = portfolio.Description,
				IsDeleted = portfolio.IsDeleted,
				Price = (double)portfolio.Price,
				CategoryId = (int)portfolio.CategoryId,
				Categories = await _categoryService.GetList()

			};
			return View(updateVM);
		}
		[HttpPost]
		public async Task<IActionResult> Update(PortfolioUpdateVM updateVM)
		{
			if (ModelState.IsValid)
			{
				await _portfolioService.Update(updateVM);
				return RedirectToAction("Index");
			}
			// Əgər model doğrulama xətası varsa, səhifəni yenidən göstər
			return RedirectToAction("Update");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _portfolioService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
