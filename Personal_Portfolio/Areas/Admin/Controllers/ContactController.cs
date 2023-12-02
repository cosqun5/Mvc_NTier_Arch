using Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Moderator,Admin")]

    public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task< IActionResult> Index()
		{
			var result = await _contactService.GetList();
			return View(result);
		}
		public async Task<IActionResult> Delete(int id)
		{
			await  _contactService.Delete(id);
			return RedirectToAction("Index");
		}

	}
}
