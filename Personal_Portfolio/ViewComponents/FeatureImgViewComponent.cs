using Business.Services.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.ViewComponents
{
    public class FeatureImgViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public FeatureImgViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<About> abouts = await _aboutService.GetList();
            return View(abouts);
        }
    }
}
