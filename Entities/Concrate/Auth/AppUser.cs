using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate.Auth
{
	public class AppUser : IdentityUser
	{
		public string Fullname { get; set; }
		public bool IsActivated { get; set; }
	}
}
