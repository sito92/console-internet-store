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
            bodyTypes.ForEach(s=> context.BodyTypes.AddOrUpdate(p=>p.Name,s));
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
            breeds.ForEach(s => context.Breeds.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            List<Sex> sexes = new List<Sex>()
            {
                new Sex(){Name = "MALE"},
                new Sex(){Name = "FEMALE"}
            };
            sexes.ForEach(s => context.Sexs.AddOrUpdate(p => p.Name, s));
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
            brands.ForEach(s => context.Brands.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
            List<Color> colors = new List<Color>()
            {
                new Color() {Name = "CZERWONY"},
                new Color() {Name = "NIEBIESKI"},
                new Color() {Name = "SREBRNY"},
                new Color() {Name = "CZARNY"},
                new Color() {Name = "GRANATOWY"},

            };
            colors.ForEach(s => context.Colors.AddOrUpdate(p => p.Name, s));
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
            engineTypes.ForEach(s => context.EngineTypes.AddOrUpdate(p => p.EngineCapacity, s));
            context.SaveChanges();
            
        }
    }
}
