﻿using AutoMapper;
using Entities.Concrate;
using Entities.ViewModels.Abouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Profiles
{
	public class AboutProfile :Profile
	{
        public AboutProfile()
        {
			CreateMap<AboutCreatVM, About>();
			//.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Photo.FileName));

			CreateMap<AboutUpdateVM, About>();

        }
    }
}
