﻿using Business.Services.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _categoryService.GetList();
			return View(result);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Category Category)
		{
			await _categoryService.Insert(Category);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			await _categoryService.Delete(id);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (!ModelState.IsValid) return View();
			Category Category = await _categoryService.GetById(id);
			if (Category == null)
			{
				return View("Error");
			}
			Category update = new Category
			{
				Id = id,
				Name = Category.Name,

			};
			return View(update);
		}
		[HttpPost]
		public async Task<IActionResult> Update(Category update)
		{
			await _categoryService.Update(update);

			return RedirectToAction("Index");
		}
	}
}