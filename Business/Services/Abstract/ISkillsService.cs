using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface ISkillsService
	{
		Task<List<Skills>> GetList();
		Task<Skills> GetById(int id);
		Task Insert(Skills skills);
		Task Update(Skills skills);
		Task Delete(int id);
	}
}
