using Business.Services.Abstract;
using Business.Utilities.Constans;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrate
{
	public class FeatureService : IFeatureService
	{
		private readonly IFeatureRepository _repository;

		public FeatureService(IFeatureRepository repository)
		{
			_repository = repository;
		}

		public async Task Delete(int id)
		{
			Feature feature =  await _repository.GetById(id);
			if (feature == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			 _repository.Delete(feature);
			await _repository.SaveAsync();
		}

		public async Task<Feature> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Feature>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Feature feature)
		{
			if (await _repository.IsExistsAsync(p => p.Title == feature.Title))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}

			await _repository.Insert(feature);
			await _repository.SaveAsync();
		}

		public  async Task Update(Feature feature)
		{
			// Feature var mı kontrolü
			if (await _repository.IsExistsAsync(e => e.Id == feature.Id))
			{
				// Tecrube zaten var, güncelleme işlemini yapabilirsiniz
				_repository.Update(feature);
				await _repository.SaveAsync();
			}
			else
			{
				// Feature bulunamadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}
		}
	}
}
