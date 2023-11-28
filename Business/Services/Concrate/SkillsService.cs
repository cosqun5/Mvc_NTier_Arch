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
	public class SkillsService : ISkillsService
	{
		private readonly ISkillsRepository _repository;

		public SkillsService(ISkillsRepository repository)
		{
			_repository = repository;
		}

		public async Task Delete(int id)
		{
			Skills skills = await _repository.GetById(id);
			if (skills == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(skills);
			await _repository.SaveAsync();
		}

		public async Task<Skills> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Skills>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Skills skills)
		{
			if (await _repository.IsExistsAsync(p => p.Name == skills.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}

			await _repository.Insert(skills);
			await _repository.SaveAsync();
		}

		public async Task Update(Skills skills)
		{
			// Bacariq var mı kontrolü
			if (await _repository.IsExistsAsync(e => e.Id == skills.Id))
			{
				// Bacariq zaten var, güncelleme işlemini yapabilirsiniz
				_repository.Update(skills);
				await _repository.SaveAsync();
			}
			else
			{
				// Bacariq bulunamadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}
		}
	}
}
