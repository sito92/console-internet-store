namespace CarAndHorseStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EngineTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CylinderAmount = c.Int(nullable: false),
                        EngineCapacity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserBases", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.UserBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        EMail = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ColorId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        BrandId = c.Int(),
                        BodyTypeId = c.Int(),
                        EngineTypeId = c.Int(),
                        BreedId = c.Int(),
                        SexId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.EngineTypes", t => t.EngineTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Breeds", t => t.BreedId, cascadeDelete: true)
                .ForeignKey("dbo.Sexes", t => t.SexId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.BrandId)
                .Index(t => t.BodyTypeId)
                .Index(t => t.EngineTypeId)
                .Index(t => t.BreedId)
                .Index(t => t.SexId);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductLists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Products", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Products", "EngineTypeId", "dbo.EngineTypes");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "BodyTypeId", "dbo.BodyTypes");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.ProductLists", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.UserBases");
            DropIndex("dbo.Products", new[] { "SexId" });
            DropIndex("dbo.Products", new[] { "BreedId" });
            DropIndex("dbo.Products", new[] { "EngineTypeId" });
            DropIndex("dbo.Products", new[] { "BodyTypeId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.ProductLists", new[] { "OrderId" });
            DropIndex("dbo.ProductLists", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropTable("dbo.Sexes");
            DropTable("dbo.Products");
            DropTable("dbo.ProductLists");
            DropTable("dbo.UserBases");
            DropTable("dbo.Orders");
            DropTable("dbo.EngineTypes");
            DropTable("dbo.Colors");
            DropTable("dbo.Breeds");
            DropTable("dbo.Brands");
            DropTable("dbo.BodyTypes");
        }
    }
}
