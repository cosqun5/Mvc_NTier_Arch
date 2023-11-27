using Entities.Concrate;
using Entities.ViewModels.Abouts;


namespace Business.Services.Abstract
{
	public interface ICategoryService
	{
		Task<List<Category>> GetList();
		Task<Category> GetById(int id);
		Task Insert(Category category);
		Task Update(Category category);
		Task Delete(int id);
	}
}
