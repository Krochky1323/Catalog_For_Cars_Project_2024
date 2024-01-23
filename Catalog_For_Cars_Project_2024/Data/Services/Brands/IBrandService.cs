using Catalog_For_Cars_Project_2024.Models;
using Catalog_For_Cars_Project_2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Data.Services.Brands
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrands();
       public BrandFormViewModel GetBrandFormValues();
        void CreateBrand(Brand brand);
        void DeleteBrand(int id);
    }
}
