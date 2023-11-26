using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
	public class Portfolio
	{
		public Portfolio()
		{
			PortfolioImages = new List<PortfolioImage>();
		}
		public int Id { get; set; }


		[Required]
		public string? Name { get; set; }

		[Required]
		public string? Description { get; set; }
		public DateTime? CreatedDate { get; set; }


		[Required]
		public bool IsDeleted { get; set; }

		[Required]
		public double? Price { get; set; }
		[Required]
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
		public virtual List<PortfolioImage> PortfolioImages { get; set; }
	}
}
