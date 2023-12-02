using Entities.Concrate;
using Entities.Concrate.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
	{
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
		{

		}
		
		public DbSet<About> Abouts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Education> Educations { get; set; }
		public DbSet<Experience> Experiences { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<Portfolio> Portfolios { get; set; }
		public DbSet<PortfolioImage> PortfolioImages { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Skills> Skilles { get; set; }
		public DbSet<Cv> Cvs { get; set; }

	}
}
