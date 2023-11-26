using Entities.Concrate;
using Entities.ViewModels.Abouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IAboutService
	{
		Task<List<About>> GetList();
		Task<About> GetById(int id);
		Task Insert(AboutCreatVM creatVM);
		Task Update(AboutUpdateVM updateVM);
		Task Delete(int id);
	}
}
