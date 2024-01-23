using Catalog_For_Cars_Project_2024.Models;
using Catalog_For_Cars_Project_2024.ViewModels;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Data.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return _dbContext.Categories.Include(b => b.Cars);
        }

        public CategoryFormViewModel GetCategoryFormValues()
        {
            return new CategoryFormViewModel();
        }
        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }
    }

}
