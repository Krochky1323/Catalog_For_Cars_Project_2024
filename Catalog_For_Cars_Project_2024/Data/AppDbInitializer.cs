using Catalog_For_Cars_Project_2024.Models;

using Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_For_Cars_Project_2024t.Data
{
    public class AppDbInitializer
    {

        //Сийдване на базата
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Brand
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand()
                        {
                            Name = "BMW",
                            PictureOfBrand ="https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/BMW.svg/2048px-BMW.svg.png"

                        },
                         new Brand()
                        {
                            Name = "VW",
                            PictureOfBrand ="https://www.carlogos.org/logo/Volkswagen-emblem-2014-1920x1080.png"

                        }, new Brand()
                        {
                            Name = "Audi",
                            PictureOfBrand ="https://us.123rf.com/450wm/teamarbeit/teamarbeit2207/teamarbeit220700028/189686374-wetzlar-germany-2022-04-23-close-up-of-audi-logo-on-a-car-audi-ag-is-a-german-automobile.jpg?ver=6"

                        }, new Brand()
                        {
                            Name = "Mercedes",
                            PictureOfBrand ="https://www.carlogos.org/logo/Mercedes-Benz-logo-2011-1920x1080.png"

                        },
                    });
                    context.SaveChanges();
                }
                //Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Jeep" ,
                        },
                        new Category()
                        {
                            Name = "Compartment",
                        },
                        new Category()
                        {
                             Name = "Sedan",
                        },
                        new Category()
                        {
                            Name = "Convertible",
                        },
                    });
                    context.SaveChanges();
                }
                //Cars
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                    {
                        new Car()
                        {
                            PictureOfCar = "https://www.bmw.bg/content/dam/bmw/common/all-models/m-series/bmw-x5-m60i/2023/highlights/bmw-x-series-x5-m60i-sp-desktop.jpg" ,
                            Model = "BMW X5" ,
                            Price = 700000,
                            Year = 2021,
                            Power = 506,
                            Color = "Blue",
                            BrandId = 1,
                            CategoryId = 1
                        },
                        new Car()
                        {
                            PictureOfCar ="https://7cars.bg/wp-content/uploads/2023/03/viber_image_2023-03-24_14-51-03-620-876x535.jpg" ,
                            Model = "VolksWagen-7",
                            Price = 33000,
                            Year = 2017,
                            Power = 328,
                            Color = "Black",
                            BrandId = 2,
                            CategoryId = 3
                        },
                        new Car()
                        {
                            PictureOfCar ="https://www.auto-data.net/images/f86/Audi-A8-Long-D5-facelift-2021.jpg" ,
                            Model = "Audi-A8",
                            Price = 59000,
                            Year = 2020,
                            Power = 420,
                            Color = "Dark-Gray",
                            BrandId = 3,
                            CategoryId = 2
                        },
                        new Car()
                        {
                            PictureOfCar ="https://cars.silverstar.bg/wp-content/uploads/2023/03/20230307_151205_TT-1.jpg",
                            Model = "Mercedes-Benz",
                            Price = 1200000,
                            Year = 2021,
                            Power = 750,
                            Color = "White" ,
                            BrandId = 4,
                            CategoryId = 4

                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = "Admin",
                    });

                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = "User",
                    });
                }

                if (!context.Users.Any())
                {
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                    IdentityUser admin = new IdentityUser
                    {
                        UserName = "admin@abv.bg",
                    };
                    await userManager.CreateAsync(admin, "admin123");

                    await userManager.AddToRoleAsync(admin, "Admin");

                    IdentityUser user = new IdentityUser
                    {
                        UserName = "user@abv.bg",
                    };
                    await userManager.CreateAsync(user, "user123");

                    await userManager.AddToRoleAsync(user, "User");
                }
            }

        }
    }
}

