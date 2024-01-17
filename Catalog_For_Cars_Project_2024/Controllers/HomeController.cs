using Microsoft.AspNetCore.Mvc;

namespace Catalog_For_Cars_Project_2024.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Car");
            }

            return View();
        }
    }
}
