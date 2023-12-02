using Business.Services.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Moderator,Admin")]

    public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;

		public ServiceController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _serviceService.GetList();
			return View(result);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Service service)
		{
			await _serviceService.Insert(service);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _serviceService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Service service = await _serviceService.GetById(id);
			if (service == null)
			{
				return View("Error");
			}

			return View(service);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Service update)
		{
			await _serviceService.Update(update);

			return RedirectToAction("Index");
		}
	}
}
