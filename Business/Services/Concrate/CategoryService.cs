using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constans;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using Entities.ViewModels.Categorys;


namespace Business.Services.Concrate
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;


		public CategoryService(ICategoryRepository repository, IMapper mapper)
		{
			_repository = repository;
		}

		public async Task Delete(int id)
		{

			Category category = await _repository.GetById(id);
			if (category == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			_repository.Delete(category);
			await _repository.SaveAsync();
		}

		public async Task<Category> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<List<Category>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task Insert(Category category)
		{
			
			if (await _repository.IsExistsAsync(p => p.Name == category.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}
			await _repository.Insert(category);
			await _repository.SaveAsync();

		}

		public async Task Update(Category category)
		{
			Category ctg= await _repository.GetById(category.Id);
			ctg.Name = category.Name;
			_repository.Update(ctg);
			await _repository.SaveAsync();
		}
	}
}
