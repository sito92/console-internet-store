using System.Collections.Generic;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarAndHorseStore.Domain.Models.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarAndHorseStore.Domain.Models.ShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<BodyType> bodyTypes = new List<BodyType>()
            {
                new BodyType() {Name = "HATCHBACK"},
                new BodyType() {Name = "SEDAN"},
                new BodyType() {Name = "COUPE"},
                new BodyType() {Name = "KOMBI"},
                new BodyType() {Name = "CABRIOLET"},
            };
            bodyTypes.ForEach(s=> context.BodyTypes.AddOrUpdate(p=>p.Id,s));
            context.SaveChanges();
            List<Breed> breeds = new List<Breed>()
            {
                new Breed() {Name = "Cleveland Bay"},
                new Breed() {Name = "Angloarab"},
                new Breed() {Name = "Furioso"},
                new Breed() {Name = "Haflinger"},
                new Breed() {Name = "Irish Draught"},
                new Breed() {Name = "koñ woroneski"},
                new Breed() {Name = "k³usak rosyjski"},
                new Breed() {Name = "koñ nowokirgiski"},
                new Breed() {Name = "Quarter Horse"},
                new Breed() {Name = "Zweibrucker"},
            };
            breeds.ForEach(s => context.Breeds.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            List<Sex> sexes = new List<Sex>()
            {
                new Sex(){Name = "MALE"},
                new Sex(){Name = "FEMALE"}
            };
            sexes.ForEach(s => context.Sexs.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            List<Brand> brands = new List<Brand>()
            {
                new Brand() {Name = "MERCEDES"},
                new Brand() {Name = "VOLKSWAGEN"},
                new Brand() {Name = "FIAT"},
                new Brand() {Name = "BMW"},
                new Brand() {Name = "AUDI"},
                new Brand() {Name = "TOYOTA"},
                new Brand() {Name = "CITROEN"},
            };
            brands.ForEach(s => context.Brands.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            List<Color> colors = new List<Color>()
            {
                new Color() {Name = "CZERWONY"},
                new Color() {Name = "NIEBIESKI"},
                new Color() {Name = "SREBRNY"},
                new Color() {Name = "CZARNY"},
                new Color() {Name = "GRANATOWY"},

            };
            colors.ForEach(s => context.Colors.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            List<EngineType> engineTypes = new List<EngineType>()
            {
                new EngineType() {CylinderAmount = 3, EngineCapacity = 1.0f},
                new EngineType() {CylinderAmount = 3, EngineCapacity = 1.2f},
                new EngineType() {CylinderAmount = 3, EngineCapacity = 1.4f},
                new EngineType() {CylinderAmount = 3, EngineCapacity = 1.6f},
                new EngineType() {CylinderAmount = 4, EngineCapacity = 1.0f},
                new EngineType() {CylinderAmount = 4, EngineCapacity = 1.2f},
                new EngineType() {CylinderAmount = 4, EngineCapacity = 1.4f},
                new EngineType() {CylinderAmount = 4, EngineCapacity = 1.6f},
                new EngineType() {CylinderAmount = 4, EngineCapacity = 1.8f},
                new EngineType() {CylinderAmount = 6, EngineCapacity = 3.2f},
                new EngineType() {CylinderAmount = 6, EngineCapacity = 3.0f},
                new EngineType() {CylinderAmount = 6, EngineCapacity = 4.0f},
                new EngineType() {CylinderAmount = 6, EngineCapacity = 2.5f},
                new EngineType() {CylinderAmount = 6, EngineCapacity = 2.8f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 4.0f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 4.2f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 4.8f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 5.0f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 5.2f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 6.8f},
                new EngineType() {CylinderAmount = 8, EngineCapacity = 7.0f},

            };
            engineTypes.ForEach(s => context.EngineTypes.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            List<Product> products = new List<Product>()
            {
                #region CarsSeed
                new Car()
                {
                    Description = "Daje rade fura",
                    Price = 9000,
                    Name = "Golf III",
                    BodyTypeId = 1,
                    ColorId = 1,
                    EngineTypeId = 1,
                    BrandId = 2
                },

                new Car()
                {
                    Description = "Dobra fura",
                    Price = 2000,
                    Name = "Golf II",
                    BodyTypeId = 2,
                    ColorId = 1,
                    EngineTypeId = 2,
                    BrandId = 2
                },
                new Car()
                {
                    Description = "Wiadomo co to za auto. Klasa.",
                    Price = 111000,
                    Name = "S class",
                    BodyTypeId = 1,
                    ColorId = 1,
                    EngineTypeId = 9,
                    BrandId = 1
                },
                new Car()
                {
                    Description = "Auto kosmicznej klasy",
                    Price = 234000,
                    Name = "Z class",
                    BodyTypeId = 2,
                    ColorId = 1,
                    EngineTypeId = 8,
                    BrandId = 1
                },
                new Car()
                {
                    Description = "Auto dla biedaków",
                    Price = 9000,
                    Name = "Seicento",
                    BodyTypeId = 1,
                    ColorId = 2,
                    EngineTypeId = 1,
                    BrandId = 3
                },
                new Car()
                {
                    Description = "Dobra fura dla biedaków",
                    Price = 2000,
                    Name = "Seicento 76",
                    BodyTypeId = 2,
                    ColorId = 2,
                    EngineTypeId = 2,
                    BrandId = 3
                },
                new Car()
                {
                    Description = "Gwarancja dobrych ³owów na ka¿dej imprezie",
                    Price = 51000,
                    Name = "e46",
                    BodyTypeId = 4,
                    ColorId = 3,
                    EngineTypeId = 16,
                    BrandId = 4
                },
                new Car()
                {
                    Description = "Prawdziwa gwarancja dobrych ³owów na ka¿dej imprezie",
                    Price = 2341000,
                    Name = "e666",
                    BodyTypeId = 3,
                    ColorId = 5,
                    EngineTypeId = 11,
                    BrandId = 4
                },
                new Car()
                {
                    Description = "Najprawdziwsza gwarancja dobrych ³owów na ka¿dej imprezie",
                    Price = 2114000,
                    Name = "e121212",
                    BodyTypeId = 3,
                    ColorId = 5,
                    EngineTypeId = 12,
                    BrandId = 4
                },
                new Car()
                {
                    Description = "Sam mam(Admin), polecam.",
                    Price = 60000,
                    Name = "A4",
                    BodyTypeId = 1,
                    ColorId = 1,
                    EngineTypeId = 19,
                    BrandId = 5
                },
                new Car()
                {
                    Description = "Dobra fura",
                    Price = 15000,
                    Name = "A4",
                    BodyTypeId = 2,
                    ColorId = 1,
                    EngineTypeId = 14,
                    BrandId = 5
                },
                new Car()
                {
                    Description = "Sam mam(Mod), polecam.",
                    Price = 60000,
                    Name = "Yaris",
                    BodyTypeId = 1,
                    ColorId = 1,
                    EngineTypeId = 19,
                    BrandId = 6
                },
                new Car()
                {
                    Description = "Samochód Karola",
                    Price = 54000,
                    Name = "Karolla",
                    BodyTypeId = 2,
                    ColorId = 1,
                    EngineTypeId = 14,
                    BrandId = 6
                },
                new Car()
                {
                    Description = "Niezawodny.",
                    Price = 111000,
                    Name = "C5",
                    BodyTypeId = 5,
                    ColorId = 2,
                    EngineTypeId = 9,
                    BrandId = 7
                },
                new Car()
                {
                    Description = "Git auto",
                    Price = 234000,
                    Name = "C4",
                    BodyTypeId = 5,
                    ColorId = 2,
                    EngineTypeId = 8,
                    BrandId = 7
                },

                #endregion
                #region HorsesSeed


                new Horse()
                {
                    Description = "Bardzo dobry koñ, bardzo",
                    Price = 2000,
                    Name = "Jacek",
                    BreedId = 1,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Jak gepard panie",
                    Price = 3000,
                    Name = "Placek",
                    BreedId = 2,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Mocne nogi ma",
                    Price = 10000,
                    Name = "Plankton",
                    BreedId = 3,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Bardzo dobry koñ, bardzo",
                    Price = 2000,
                    Name = "Sebek",
                    BreedId = 4,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Jak gepard panie",
                    Price = 33000,
                    Name = "Wurst",
                    BreedId = 5,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Mocne nogi ma",
                    Price = 9000,
                    Name = "Wezuwiusz",
                    BreedId = 6,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Mocny jak wó³",
                    Price = 1050,
                    Name = "Kopacek",
                    BreedId = 1,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Jak dobry doœæ tak",
                    Price = 3100,
                    Name = "Klacek",
                    BreedId = 2,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Mocne nogi ma",
                    Price = 10400,
                    Name = "Roman",
                    BreedId = 7,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Nie zawiedzie was",
                    Price = 2000,
                    Name = "Ogar",
                    BreedId = 4,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Jak gepard panie albo dwa",
                    Price = 23000,
                    Name = "Komar",
                    BreedId = 5,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Z bólem serca, ale musimy go sprzedaæ",
                    Price = 7000,
                    Name = "Eryk",
                    BreedId = 6,
                    SexId = 1,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Mocne nogi ma",
                    Price = 10000,
                    Name = "Romana",
                    BreedId = 7,
                    SexId = 2,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Nie zawiedzie was",
                    Price = 8000,
                    Name = "Ogara",
                    BreedId = 4,
                    SexId = 2,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Jak gepard panie albo dwa",
                    Price = 21000,
                    Name = "Komara",
                    BreedId = 5,
                    SexId = 2,
                    ColorId = 1
                },
                new Horse()
                {
                    Description = "Z bólem serca, ale musimy j¹ sprzedaæ",
                    Price = 4000,
                    Name = "Eryk",
                    BreedId = 6,
                    SexId = 2,
                    ColorId = 1
                },

                #endregion
            };
            products.ForEach(x=> context.Products.AddOrUpdate(s=>s.Id,x));
            context.SaveChanges();

        }
    }
}
