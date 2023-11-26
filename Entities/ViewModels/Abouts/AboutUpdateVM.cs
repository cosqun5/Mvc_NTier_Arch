using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.Abouts
{
	public class AboutUpdateVM
	{
        public int Id { get; set; }
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
