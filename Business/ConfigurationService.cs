using Business.Services.Abstract;
using Business.Services.Concrate;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrate;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public static class ConfigurationService
	{
		public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped<IAboutService, AboutService>();
			services.AddScoped<IEducationService, EducationService>();
			services.AddScoped<IExperienceService, ExperienceService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IFeatureService, FeatureService>();
			services.AddScoped<ILanguageService, LanguageService>();

			return services;
		}
	}
}
