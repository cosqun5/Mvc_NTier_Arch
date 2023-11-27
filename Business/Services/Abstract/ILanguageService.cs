using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface ILanguageService
	{
		Task<List<Language>> GetList();
		Task<Language> GetById(int id);
		Task Insert(Language language);
		Task Update(Language language);
		Task Delete(int id);
	}
}
