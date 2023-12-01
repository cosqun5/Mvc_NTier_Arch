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
	public class ContactService : IContactService
	{
		private readonly IContactRepository _repository;

		public ContactService(IContactRepository repository)
		{
			_repository = repository;
		}

		public async Task Delete(int id)
		{
			Contact contact = await _repository.GetById(id);
			if (contact == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(contact);
			await _repository.SaveAsync();
		}

		public async Task<Contact> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public  async Task<List<Contact>> GetList()
		{
			return await _repository.GetList();
		}
		public async Task Insert(Contact contact)
		{
			await _repository.Insert(contact);
			await _repository.SaveAsync();
		}
	}
}
