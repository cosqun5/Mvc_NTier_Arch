using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constans;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using Entities.ViewModels.Abouts;

using Business.Utilities.Extensions;

using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Services.Concrate
{
	public class AboutService : IAboutService
	{
		private readonly IAboutRepository _repository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _enviroment;
		
		private readonly AppDbContext _dbContext;

		public AboutService(IAboutRepository repository, IMapper mapper, IWebHostEnvironment webHostEnvironment, AppDbContext dbContext)
		{
			_repository = repository;
			_mapper = mapper;
			_enviroment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
			_dbContext = dbContext;
		}

		public async Task Delete(int id)
		{
			About about = await _repository.GetById(id);
			if (about == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			string roolpath = Path.Combine(_enviroment.WebRootPath, "assets", "img", about.ImageUrl);
			if (System.IO.File.Exists(roolpath))
			{
				System.IO.File.Delete(roolpath);
			}
			_repository.Delete(about);
			await _repository.SaveAsync();
		}

		

		public async Task<List<About>> GetList()
		{
			return await _repository.GetList();
		}

		public async Task<About> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task Insert(AboutCreatVM creatVM)
		{
			if (await _repository.IsExistsAsync(p => p.Title == creatVM.Title))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}
			string rootpath = Path.Combine(_enviroment.WebRootPath, "assets", "img");
			string FileName = await creatVM.Photo.SaveAsync(rootpath);
			About about = new About()
			{
				Title = creatVM.Title,
				Age = creatVM.Age,
				Description = creatVM.Description,
				Email = creatVM.Email,
				Phone = creatVM.Phone,
				City = creatVM.City,
				Degree = creatVM.Degree,
				ImageUrl = FileName

			};

			//automapper ve automapper dependecinjection yuklemek lazimdi.
			await _repository.Insert(_mapper.Map<About>(creatVM));
			await _repository.SaveAsync();
		}

		public Task Update(AboutUpdateVM entity)
		{
			throw new NotImplementedException();
		}

		//	public async Task AddAsync(AboutCreatVM creatVM)
		//	{
		//		if (await _repository.IsExistsAsync(p => p.Title == creatVM.Title))
		//		{
		//			throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
		//		}
		//		string rootpath = Path.Combine(_enviroment.WebRootPath, "assets", "img");
		//		string FileName = await creatVM.Photo.SaveAsync(rootpath);
		//		About about = new About()
		//		{
		//			Title = creatVM.Title,
		//			Age = creatVM.Age,
		//			Description = creatVM.Description,
		//			Email = creatVM.Email,
		//			Phone = creatVM.Phone,
		//			City = creatVM.City,
		//			Degree = creatVM.Degree,
		//			ImageUrl = FileName

		//		};

		//		//automapper ve automapper dependecinjection yuklemek lazimdi.
		//		await _repository.AddAsync(_mapper.Map<About>(creatVM));
		//	    await _repository.SaveAsync();
		//	}

		//	public async Task DeleteAsync(int id)
		//	{
		//		About about = await _repository.GetAsync(p => p.Id == id);
		//		if (about == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
		//		string roolpath = Path.Combine(_enviroment.WebRootPath, "assets", "img", about.ImageUrl);
		//		if (System.IO.File.Exists(roolpath))
		//		{
		//			System.IO.File.Delete(roolpath);
		//		}
		//		_repository.Delete(about);
		//		 await _repository.SaveAsync();
		//	}

		//	public Task<List<AboutGetVM>> GetAll()
		//	{
		//		throw new NotImplementedException();
		//	}

		//	public async Task UpdateAsync(AboutUpdateVM updateVM)
		//	{
		//		{
		//			// Əgər updateVM null-dırsa
		//			if (updateVM == null)
		//			{
		//				throw new ArgumentNullException(nameof(updateVM), "UpdateVM null ola bilməz. Əlavə məlumat təyin etməlisiniz.");
		//			}

		//			// Əgər updateVM.Id null-dırsa
		//			if (updateVM.Id == null)
		//			{
		//				throw new ArgumentNullException(nameof(updateVM.Id), "UpdateVM.Id null ola bilməz. Əlavə məlumat təyin etməlisiniz.");
		//			}

		//			// Əgər updateVM.Id ilə əlaqəli About obyektini tap
		//			About about = await _repository.GetAsync(p => p.Id == updateVM.Id);

		//			// Əgər about obyekti null-dırsa
		//			if (about == null)
		//			{
		//				throw new NullReferenceException($"About obyekti Id ilə tapılmadı. Məlumat bazasında uyğun məlumat yoxdur.");
		//			}

		//			// Silinmiş faylı tapmaq və silmək
		//			string rootPath = Path.Combine(_enviroment.WebRootPath, "assets", "img");
		//			string deletePath = Path.Combine(rootPath, about.ImageUrl);

		//			if (System.IO.File.Exists(deletePath))
		//			{
		//				System.IO.File.Delete(deletePath);
		//			}

		//			// Yeni faylı yaddaşa yazmaq
		//			string fileName = await updateVM.Photo.SaveAsync(rootPath);
		//			about.ImageUrl = fileName;

		//			// Qalan məlumatları yeniləmək
		//			about.Title = updateVM.Title;
		//			about.Description = updateVM.Description;
		//			about.Degree = updateVM.Degree;
		//			about.Age = updateVM.Age;
		//			about.Email = updateVM.Email;
		//			about.City = updateVM.City;
		//			about.Phone = updateVM.Phone;
		//			await _repository.SaveAsync();
		//			// Yenilənmiş məlumatları məlumat bazasına yazmaq
		//			// Əlavə əm
		//		}
		//	}


		
	}
}


