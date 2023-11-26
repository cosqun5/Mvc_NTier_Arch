using Core.DataAccess.Repositories.Concrate.EFCore;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrate
{
	public class AboutRepository : EfBaseRepository<About, AppDbContext>, IAboutRepository
	{
		public AboutRepository(AppDbContext context) : base(context)
		{
		}
	}
}
