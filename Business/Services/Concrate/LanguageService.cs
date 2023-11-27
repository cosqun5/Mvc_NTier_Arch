using AutoMapper.Features;
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
	public class LanguageService : ILanguageService
	{
		private readonly ILanguageRepository _repository;

		public LanguageService(ILanguageRepository repository)
		{
			_repository = repository;
		}

		public async Task Delete(int id)
		{
			Language language = await _repository.GetById(id);
			if (language == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(language);
			await _repository.SaveAsync();
		}

		public async Task<Language> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Language>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Language language)
		{
			if (await _repository.IsExistsAsync(p => p.Name == language.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}

			await _repository.Insert(language);
			await _repository.SaveAsync();
		}

		public  async Task Update(Language language)
		{
			// Dil var mı kontrolü
			if (await _repository.IsExistsAsync(e => e.Id == language.Id))
			{
				// Dil zaten var, güncelleme işlemini yapabilirsiniz
				_repository.Update(language);
				await _repository.SaveAsync();
			}
			else
			{
				// Dil bulunamadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}
		}
	}
}
