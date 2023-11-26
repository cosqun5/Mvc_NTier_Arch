using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Abouts
{
	public class AboutCreatVM
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile Photo { get; set; }

		public string Email { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
		public string Degree { get; set; }
		public int Age { get; set; }
	}
}
