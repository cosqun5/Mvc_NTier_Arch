using Entities.Concrate;
using Entities.ViewModels.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IEducationService
	{
		Task<List<Education>> GetList();
		Task<Education> GetById(int id);
		Task Insert(Education education);
		Task Update(Education education);
		Task Delete(int id);
	}
}
