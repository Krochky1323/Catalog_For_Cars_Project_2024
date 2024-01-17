using Cars_Catalog_Project.Models;
using Cars_Catalog_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_Catalog_Project.Data.Services
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
