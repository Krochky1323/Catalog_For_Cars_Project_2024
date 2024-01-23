using Catalog_For_Cars_Project_2024.Models;
using Catalog_For_Cars_Project_2024.ViewModels;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Data.Services.Brands
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _dbContext;

        public BrandService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return _dbContext.Brands.Include(b => b.Cars);
        }

        public BrandFormViewModel GetBrandFormValues()
        {
            return new BrandFormViewModel();
        }
        public void CreateBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var brand = _dbContext.Brands.Find(id);
            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                _dbContext.SaveChanges();
            }
        }
    }

}
