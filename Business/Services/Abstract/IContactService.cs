using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IContactService
	{
		Task<List<Contact>> GetList();
		Task<Contact> GetById(int id);
		Task Insert(Contact contact);
		Task Delete(int id);
	}
}
