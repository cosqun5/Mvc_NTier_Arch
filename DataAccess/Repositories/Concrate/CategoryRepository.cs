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
	public class CategoryRepository : EfBaseRepository<Category, AppDbContext>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context)
		{
		}
	}
}
