using Catalog_For_Cars_Project_2024.Models;
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

        public IEnumerable<Brand> GetAllBrands()
        {
            return _dbContext.Brands.Include(b => b.Cars);
        }

        public Brand GetBrandById(int id)
        {
            return _dbContext.Brands.Include(b => b.Cars).FirstOrDefault(b => b.Id == id);
        }

        public void CreateBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            var existingBrand = _dbContext.Brands.Find(brand.Id);
            if (existingBrand != null)
            {
                existingBrand.PictureOfBrand = brand.PictureOfBrand;
                existingBrand.Name = brand.Name;
                _dbContext.SaveChanges();
            }
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
