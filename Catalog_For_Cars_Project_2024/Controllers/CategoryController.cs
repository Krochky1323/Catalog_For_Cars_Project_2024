using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        //Свързване на контролера вюто на категориите
        public async Task<IActionResult> Index()
        {
            var allCategories =await _context.Categories.ToListAsync();
            return View(allCategories);
        }
    }
}
