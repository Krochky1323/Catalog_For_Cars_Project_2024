using Catalog_For_Cars_Project_2024.Data.Services.Brands;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Controllers
{
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        //Свързване на контролера вюто на brands
        public async Task<IActionResult> Index()
        {
            var allBrands = await _context.Brands.ToListAsync();
            return View(allBrands);
        }
    }
}
