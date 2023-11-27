using AutoMapper;
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
	public class EducationService : IEducationService
	{
		private readonly IEducationRepository _repository;


		public EducationService(IEducationRepository repository)
		{
			_repository = repository;
		}
		public async Task Delete(int id)
		{
			// Education türünden repository
			Education education = await _repository.GetById(id);
			if (education == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(education);
			await _repository.SaveAsync();
		}

		public async Task<Education> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Education>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Education education)
		{
			if (await _repository.IsExistsAsync(p => p.Name == education.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}

			await _repository.Insert(education);
			await _repository.SaveAsync();
		}

		public async Task Update(Education education)
		{
			// Eğitim var mı kontrolü
			if (await _repository.IsExistsAsync(e => e.Id == education.Id))
			{
				// Eğitim zaten var, güncelleme işlemini yapabilirsiniz
				 _repository.Update(education);
				await _repository.SaveAsync();
			}
			else
			{
				// Eğitim bulunamadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}
		}
	}
}
