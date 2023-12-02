using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrate;
using System.Configuration;
using Entities.Concrate.Auth;
using Entities.Concrate;

namespace DataAccess
{
	public static class ConfigurationServices
	{
		public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			
			services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(configuration.GetConnectionString("Default"));
			});

			services.AddIdentity<AppUser, AppRole>()
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.AllowedForNewUsers = true;
            });




            services.AddScoped<IAboutRepository, AboutRepository>();
			services.AddScoped<IContactRepository, ContactRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IExperienceRepository, ExperienceRepository>();
			services.AddScoped<IPortfolioRepository, PortfolioRepository>();
			services.AddScoped<IEducationRepository, EducationRepository>();
			services.AddScoped<IFeatureRepository, FeatureRepository>();
			services.AddScoped<ILanguageRepository, LanguageRepository>();
			services.AddScoped<IPortfolioImageRepository, PortfolioImageRepository>();
			services.AddScoped<IServiceRepository, ServiceRepository>();
			services.AddScoped<ISkillsRepository, SkillsRepository>();
			return services;
		}
	}
}
