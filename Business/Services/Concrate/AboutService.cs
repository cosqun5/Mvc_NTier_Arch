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
using Microsoft.EntityFrameworkCore;
using Humanizer;

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
			await _repository.Insert(_mapper.Map<About>(about));
			await _repository.SaveAsync();
		}

		public async Task Update(AboutUpdateVM entity)
		{
		
			string rootpath = Path.Combine(_enviroment.WebRootPath, "assets", "img");
			About about = await _repository.GetById(entity.Id);
			string deletepath = Path.Combine(rootpath, about.ImageUrl);

			if (System.IO.File.Exists(deletepath))
			{
				System.IO.File.Delete(deletepath);
			}
			string FileName = await entity.Photo.SaveAsync(rootpath);
			about.ImageUrl = FileName;
			about.Title=entity.Title;
			about.Age = entity.Age;
			about.Description = entity.Description;
			about.Email = entity.Email;
			about.Phone = entity.Phone;
			about.City = entity.City;
			about.Degree = entity.Degree;
			_repository.Update(_mapper.Map<About>(about));
			await _repository.SaveAsync();

		}

		


		
	}
}


