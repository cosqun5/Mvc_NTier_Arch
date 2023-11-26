using Core.DataAccess.Repositories.Concrate.EFCore;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrate
{
	public class PortfolioRepository : EfBaseRepository<Portfolio, AppDbContext>, IPortfolioRepository
	{
		public PortfolioRepository(AppDbContext context) : base(context)
		{
		}
	}
}
