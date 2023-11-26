﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Exceptions
{
	public class NotFoundException:Exception
	{
		public NotFoundException(string message) : base(message)
		{

		}
		public NotFoundException() : base(" Entity Not Found")
		{

		}
	}
}
