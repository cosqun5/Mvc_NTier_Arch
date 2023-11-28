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
	public class ServicesService : IServiceService
	{
		private readonly IServiceRepository _repository;

		public ServicesService(IServiceRepository repository)
		{
			_repository = repository;
		}

		public async Task Delete(int id)
		{
			Service service = await _repository.GetById(id);
			if (service == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(service);
			await _repository.SaveAsync();
		}

		public async  Task<Service> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Service>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Service service)
		{
			if (await _repository.IsExistsAsync(p => p.Name == service.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}

			await _repository.Insert(service);
			await _repository.SaveAsync();
		}

		public async Task Update(Service service)
		{
			// Serice var mı kontrolü
			if (await _repository.IsExistsAsync(e => e.Id == service.Id))
			{
				// Service zaten var, güncelleme işlemini yapabilirsiniz
				_repository.Update(service);
				await _repository.SaveAsync();
			}
			else
			{
				// Service bulunamadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}
		}
	}
}
