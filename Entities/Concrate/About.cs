﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
	public class About
	{

        public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
		public string Degree { get; set; }
		public int Age { get; set; }
		public ContactType ContactType { get; set; }



	}
}
