using Catalog_For_Cars_Project_2024.Data.Services.Brands;
using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _service;

        //Свързване на контролера вюто на бранда

        public BrandController(IBrandService service)
        {
            _service = service;
        }
        //public async Task<IActionResult> Index()
        //{
            //var data = await _service.GetAll();
            //return View(data);
        //}
    }
}
