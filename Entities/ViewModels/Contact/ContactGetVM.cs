using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Contact
{
	public class ContactGetVM
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Email { get; set; }
		public string Phone { get; set; }
		public string Message { get; set; }
	}
}
