using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Portfolio> Portfolios { get; set; }
	}
}
