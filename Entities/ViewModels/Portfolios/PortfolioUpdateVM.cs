using Entities.Concrate;
using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.Portfolios
{
	public class PortfolioUpdateVM
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsDeleted { get; set; }
		public double Price { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int CategoryId { get; set; }
		public List<IFormFile> Photos { get; set; }
		public List<Category>? Categories { get; set; } = new List<Category>();

	}
}