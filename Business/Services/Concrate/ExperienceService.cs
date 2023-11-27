using Business.Services.Abstract;
using Business.Utilities.Constans;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrate
{
	public class ExperienceService : IExperienceService
	{
		private readonly IExperienceRepository _repository;

		public ExperienceService(IExperienceRepository experiencerepository)
		{
			_repository = experiencerepository;
		}

		public async Task Delete(int id)
		{
			Experience experience = await _repository.GetById(id);
			if (experience == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(experience);
			await _repository.SaveAsync();
		}

		public async Task<Experience> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Experience>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Experience experience)
		{
			if (await _repository.IsExistsAsync(p => p.Name == experience.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}

			await _repository.Insert(experience);
			await _repository.SaveAsync();
		}

		public async Task Update(Experience experience)
		{
			// Tecrube var mı kontrolü
			if (await _repository.IsExistsAsync(e => e.Id == experience.Id))
			{
				// Tecrube zaten var, güncelleme işlemini yapabilirsiniz
				_repository.Update(experience);
				await _repository.SaveAsync();
			}
			else
			{
				// Tecrube bulunamadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}
		}
	}
}
