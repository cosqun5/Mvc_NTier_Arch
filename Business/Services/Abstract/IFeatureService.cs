using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
	public interface IFeatureService
	{

		Task<List<Feature>> GetList();
		Task<Feature> GetById(int id);
		Task Insert(Feature feature);
		Task Update(Feature feature);
		Task Delete(int id);
	}
}
