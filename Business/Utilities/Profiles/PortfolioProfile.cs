using AutoMapper;
using Entities.Concrate;
using Entities.ViewModels.Abouts;
using Entities.ViewModels.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Profiles
{
	public class PortfolioProfile:Profile
	{
        public PortfolioProfile()
        {
			CreateMap<PortfolioCreateVM, Portfolio>();
			CreateMap<AboutUpdateVM, About>();
		}
    }
}
