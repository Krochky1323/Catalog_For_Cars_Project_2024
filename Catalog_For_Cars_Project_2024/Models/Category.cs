using Catalog_For_Cars_Project_2024.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Models
{ 
    public class Category
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Car>Cars { get; set; }
    }
}
