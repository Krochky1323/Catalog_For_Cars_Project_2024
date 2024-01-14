using Catalog_For_Cars_Project_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.ViewModels
{
    public class CarFormViewModel
    {

        //Това ще вижда клиента ни
        public Car Car { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
