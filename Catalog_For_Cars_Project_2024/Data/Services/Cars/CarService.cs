using Cars_Catalog_Project.Models;
using Cars_Catalog_Project.ViewModels;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Catalog_Project.Data.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _dbContext;

        public CarService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Заявки за работа с колите.
        public async Task< IEnumerable<Car>> GetAllCars()
        {
            return _dbContext.Cars.Include(c => c.Brand).Include(c => c.Category);
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Cars.Include(c => c.Brand).Include(c => c.Category).FirstOrDefault(c => c.Id == id);
        }

        public CarFormViewModel GetCarFormValues()
        {
            return new CarFormViewModel { Brands = _dbContext.Brands.ToList(), Categories = _dbContext.Categories.ToList()};
        }

        public CarFormViewModel GetCarFormValues(int CarId)
        {
            return new CarFormViewModel { Brands = _dbContext.Brands.ToList(), Categories = _dbContext.Categories.ToList(), Car = _dbContext.Cars.FirstOrDefault(c => c.Id == CarId) };
        }

        public void CreateCar(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            var existingCar = _dbContext.Cars.Find(car.Id);
            if (existingCar != null)
            {
                existingCar.PictureOfCar = car.PictureOfCar;
                existingCar.Model = car.Model;
                existingCar.Price = car.Price;
                existingCar.Year = car.Year;
                existingCar.Power = car.Power;
                existingCar.Color = car.Color;
                existingCar.BrandId = car.BrandId;
                existingCar.CategoryId = car.CategoryId;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCar(int id)
        {
            var car = _dbContext.Cars.Find(id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
                _dbContext.SaveChanges();
            }
        }
    }
}
