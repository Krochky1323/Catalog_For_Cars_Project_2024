using Catalog_For_Cars_Project_2024.Data.Services;
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
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        //Свързване на контролера вюто на колите

        public async Task<IActionResult> Index()
        {
            var allCars = await _carService.GetAllCars();
            return this.View(allCars);
        }

        [HttpGet("update/{id}")]
        [Authorize(Roles = "Admin")]

        //Ъпдайтваме продуктите
        public async Task<IActionResult> Update(int id)
        {
            var formValues = _carService.GetCarFormValues(id);
            return View(formValues);
        }

        [HttpPost("update/{id}")]
        [Authorize(Roles = "Admin")]
        //
        public async Task<IActionResult> Update(Car car)
        {

            _carService.UpdateCar(car);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        //Създаване на нова кола
        public async Task<IActionResult> Create()
        {
            var formValues = _carService.GetCarFormValues();
            return View(formValues);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Car car)
        {
            _carService.CreateCar(car);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        [Authorize(Roles = "Admin")]

        //изтриване на кола
        public async Task<IActionResult> Delete(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
