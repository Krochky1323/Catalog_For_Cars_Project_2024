using Catalog_For_Cars_Project_2024.Models;
using Catalog_For_Cars_Project_2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Data.Services
{
    public interface ICarService
    {
       Task< IEnumerable<Car>> GetAllCars();

        public CarFormViewModel GetCarFormValues();
        public CarFormViewModel GetCarFormValues(int CarId);
        Car GetCarById(int id);
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}
