using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constans;
using Business.Utilities.Extensions;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Concrate;
using Entities.ViewModels.Portfolios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrate
{
	public class PortfolioService : IPortfolioService
	{
		private readonly IPortfolioRepository _repository;
		private readonly IPortfolioImageRepository _imageRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _enviroment;

		public PortfolioService(IPortfolioRepository repository, IMapper mapper, IWebHostEnvironment enviroment, IPortfolioImageRepository imageRepository)
		{
			_repository = repository;
			_mapper = mapper;
			_enviroment = enviroment;
			_imageRepository = imageRepository;
		}
		public async Task<List<Portfolio>> GetList()
		{
			// Portfolio cədvəlini əlavə edirik və əlaqəli Category və Image cədvəllərini Include edirik
			var portfolios = await _repository.GetList(
				includes: new[] { "Category", "PortfolioImages" } // Bu massivdə include etmək istədiyiniz bütün əlaqəli cədvəllərin adları olmalıdır
			);

			return portfolios;
		}
		public async Task Insert(PortfolioCreateVM creatVM)
		{
			if (await _repository.IsExistsAsync(p => p.Name == creatVM.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessage.EntityAlreadyExists);
			}
			string rootpath = Path.Combine(_enviroment.WebRootPath, "assets", "img");
			List<PortfolioImage> images = await CreateFileAndGetServiceImages(creatVM.Photos, rootpath);
			Portfolio portfolio = new Portfolio()
			{
				Name = creatVM.Name,
				CategoryId = creatVM.CategoryId,
				Description = creatVM.Description,
				Price = creatVM.Price,
				PortfolioImages = images,
				CreatedDate = creatVM.CreatedDate,

			};
			await _repository.Insert(_mapper.Map<Portfolio>(portfolio));
			await _repository.SaveAsync();
		}
		public async Task<List<PortfolioImage>> CreateFileAndGetServiceImages(List<IFormFile> photos, string rootPath)
		{
			List<PortfolioImage> images = new List<PortfolioImage>();
			foreach (var photo in photos)
			{
				string fileName = await photo.SaveAsync(rootPath);
				PortfolioImage serviceImage = new PortfolioImage() { Path = fileName };
				if (!images.Any(i => i.IsActive))
				{
					serviceImage.IsActive = true;
				}
				images.Add(serviceImage);
			}

			return images;
		}


		public async Task Delete(int id)
		{
			Portfolio portfolio = await _repository.GetById(id);
			if (portfolio == null) throw new NotFoundException(ExceptionMessage.EntityNotFound);
			string rootPath = Path.Combine(_enviroment.WebRootPath, "assets", "img");

			// Portfolio cədvəsinin şəkillər listinin kopyasını yaratmaq
			var existingImagesCopy = await _imageRepository.GetList();

			// Köhnə şəkilləri silmək üçün
			foreach (var oldImage in existingImagesCopy)
			{
				string deletePath = Path.Combine(rootPath, oldImage.Path);
				if (System.IO.File.Exists(deletePath))
				{
					System.IO.File.Delete(deletePath);
				}
			}
			_repository.Delete(portfolio);
			await _repository.SaveAsync();

		}

		public async Task<Portfolio> GetById(int id)
		{
			return await _repository.GetById(id);
		}




		public async Task Update(PortfolioUpdateVM updateVM)
		{
			// ViewModel məlumatlarını Portfolio obyektinə çevir
			Portfolio existingPortfolio = await _repository.GetById(updateVM.Id);

			if (existingPortfolio == null)
			{
				// Portfolio tapılmadı
				throw new NotFoundException(ExceptionMessage.EntityNotFound);
			}

			// Yeni məlumatları təyin et
			existingPortfolio.Name = updateVM.Name;
			existingPortfolio.CategoryId = updateVM.CategoryId;
			existingPortfolio.Description = updateVM.Description;
			existingPortfolio.Price = updateVM.Price;
			existingPortfolio.CreatedDate = updateVM.CreatedDate;

			// Yeni şəkillər əlavə edilibsə, köhnə şəkilləri sil və yeni şəkilləri əlavə et
			if (updateVM.Photos != null && updateVM.Photos.Any())
			{
				string rootPath = Path.Combine(_enviroment.WebRootPath, "assets", "img");

				// Portfolio cədvəsinin şəkillər listinin kopyasını yaratmaq
				var existingImagesCopy = await _imageRepository.GetList();

				// Köhnə şəkilləri silmək üçün
				foreach (var oldImage in existingImagesCopy)
				{
					string deletePath = Path.Combine(rootPath, oldImage.Path);
					if (System.IO.File.Exists(deletePath))
					{
						System.IO.File.Delete(deletePath);
					}
				}

				// Yeni şəkilləri əlavə etmək üçün
				List<PortfolioImage> newImages = await CreateFileAndGetServiceImages(updateVM.Photos, rootPath);
				existingPortfolio.PortfolioImages = newImages;
			}
			// Portfolio cədvəlini yenilə
			_repository.Update(_mapper.Map<Portfolio>(existingPortfolio));
			//_repository.Update(existingPortfolio);
			await _repository.SaveAsync();
		}

	}
}
