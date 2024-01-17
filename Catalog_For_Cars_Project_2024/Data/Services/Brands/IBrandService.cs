using Catalog_For_Cars_Project_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Data.Services.Brands
{
    public interface IBrandService
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandById(int id);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int id);
    }
}
