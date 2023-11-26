using Entities.ViewModels.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IContactService
	{
		Task<List<ContactGetVM>> GetAll();
		Task DeleteAsync(int id);
	}
}
