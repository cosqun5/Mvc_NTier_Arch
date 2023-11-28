using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IServiceService
	{
		Task<List<Service>> GetList();
		Task<Service> GetById(int id);
		Task Insert(Service service);
		Task Update(Service service);
		Task Delete(int id);
	}
}
