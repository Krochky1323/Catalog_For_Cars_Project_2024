using Catalog_For_Cars_Project_2024.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture of car")]
        public string PictureOfCar { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

        [Display(Name = "Power")]
        public int Power { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }


        //Relationship ONE-TO-MANY

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
