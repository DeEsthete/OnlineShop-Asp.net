namespace ApNetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        User_Id = c.Guid(),
                        Purchase_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "Customer_Id", "dbo.Users");
            DropForeignKey("dbo.Books", "User_Id", "dbo.Users");
            DropIndex("dbo.Purchases", new[] { "Customer_Id" });
            DropIndex("dbo.Books", new[] { "Purchase_Id" });
            DropIndex("dbo.Books", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Purchases");
            DropTable("dbo.Books");
        }
    }
}
