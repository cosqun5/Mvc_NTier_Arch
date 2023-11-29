using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
	public class PortfolioViewComponent:ViewComponent
	{
		private readonly IPortfolioRepository _repository;

		public PortfolioViewComponent(IPortfolioRepository repository)
		{
			_repository = repository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			// Portfolio cədvəlini əlavə edirik və əlaqəli Category və Image cədvəllərini Include edirik
			var portfolios = await _repository.GetList(
				includes: new[] { "Category", "PortfolioImages" } // Bu massivdə include etmək istədiyiniz bütün əlaqəli cədvəllərin adları olmalıdır
			);

			return View(portfolios);
		}
	}
}
