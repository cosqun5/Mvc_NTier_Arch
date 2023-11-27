using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IExperienceService
	{
		Task<List<Experience>> GetList();
		Task<Experience> GetById(int id);
		Task Insert(Experience experience);
		Task Update(Experience experience);
		Task Delete(int id);
	}
}
