using DataAccess;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CvController : Controller
	{
		private readonly AppDbContext _context;

		public CvController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var result = _context.Cvs.ToList();
			
			return View(result);
		}
		public IActionResult Create() { return View(); }



		[HttpPost]
		public async Task<IActionResult> Create(Cv model, IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				try
				{
					using (var memoryStream = new MemoryStream())
					{
						await file.CopyToAsync(memoryStream);
						byte[] fileData = memoryStream.ToArray();

						model.CVData = fileData;

						_context.Cvs.Add(model);
						_context.SaveChanges();

						ViewBag.Message = "CV uğurla yükləndi.";
					}
				}
				catch (Exception ex)
				{
					ViewBag.Message = "CV yüklənmə zamanı xəta baş verdi: " + ex.Message;
				}
			}
			else
			{
				ViewBag.Message = "CV faylı seçilməyib.";
			}

			return RedirectToAction("Index");
		}


		public IActionResult Delete(int id)
		{
			Cv? cv = _context.Cvs.Find(id);
			if (cv == null)
			{
				return NotFound();
			}
			_context.Cvs.Remove(cv);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

	}
}
