using Business.Services.Abstract;
using DataAccess;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Personal_Portfolio.ViewComponents
{
	public class FeatureViewComponent :ViewComponent
	{
		private readonly IFeatureService _featureService;

		public FeatureViewComponent(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<Feature> features = await _featureService.GetList();
			return View(features);
		}
	}
}
