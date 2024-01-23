using Catalog_For_Cars_Project_2024.Data.Services.Brands;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Catalog_For_Cars_Project_2024.Data.Services;
using Catalog_For_Cars_Project_2024.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_For_Cars_Project_2024.Controllers
{
    public class BrandController : Controller
    {

        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        //Свързване на контролера вюто на brands
        public async Task<IActionResult> Index()
        {
            var allBrands = await _brandService.GetAllBrands();
            return this.View(allBrands);
        }

        [Authorize(Roles = "Admin")]

        //Създаване на нова кола
       public async Task<IActionResult> Create()
        {
           var formValues = _brandService.GetBrandFormValues();
           return View(formValues);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Brand brand)
        {
            _brandService.CreateBrand(brand);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete-brand/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _brandService.DeleteBrand(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
