using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
	public class ServiceViewComponent:ViewComponent
	{
		private readonly IServiceService _serviceService;

		public ServiceViewComponent(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _serviceService.GetList();
			return View(result);
		}
	}
}
