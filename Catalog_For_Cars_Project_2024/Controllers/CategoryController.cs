using Catalog_For_Cars_Project_2024.Data.Services.Categories;
using Catalog_For_Cars_Project_2024.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Свързване на контролера вюто на brands
        public async Task<IActionResult> Index()
        {
            var allCategories = await _categoryService.GetAllCategories();
            return this.View(allCategories);
        }

        [Authorize(Roles = "Admin")]

        //Създаване на нова кола
        public async Task<IActionResult> Create()
        {
            var formValues = _categoryService.GetCategoryFormValues();
            return View(formValues);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Category category)
        {
            _categoryService.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete-category/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
