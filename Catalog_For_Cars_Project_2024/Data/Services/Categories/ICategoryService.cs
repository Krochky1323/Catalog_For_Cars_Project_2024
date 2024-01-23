using Catalog_For_Cars_Project_2024.Models;
using Catalog_For_Cars_Project_2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Data.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
       public CategoryFormViewModel GetCategoryFormValues();
        void CreateCategory(Category category);
        void DeleteCategory(int id);
    }
}
