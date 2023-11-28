using Entities.Concrate;
using Entities.ViewModels.Abouts;
using Entities.ViewModels.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IPortfolioService
	{
		Task<List<Portfolio>> GetList();

		Task<Portfolio> GetById(int id);
		Task Insert(PortfolioCreateVM creatVM);
		Task Update(PortfolioUpdateVM updateVM);
		Task Delete(int id);

	}
}
