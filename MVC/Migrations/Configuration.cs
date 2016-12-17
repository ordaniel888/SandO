namespace MVC.Migrations
{
    using MVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       //protected override void Seed(MVC.DAL.ShopContext context)
       // {
       //     var branches = new List<Branch>
       //     {
       //         new Branch
       //         {
       //             BranchID= 10, Name= "פריסטפניסיון", City = "תל אביב", CoorX = 33, CoorY= 34, 
       //         },
       //         new Branch {  BranchID = 3,  Name = "רוטשילד",   City = "תל אביב",
       //             Street = "רוטשילד", HouseNo = 15, CoorX = 32.063179, CoorY =  34.770962},
       //         new Branch { Name = "קניון חולון",   City = "חולון",
       //             Street = "גולדה מאיר", HouseNo = 7, CoorX = 32.012288, CoorY =  34.77943 },
       //         new Branch { Name = "קינג גורג",   City = "תל אביב",
       //             Street = "קינג גורג", HouseNo = 30 , CoorX = 32.072352, CoorY =  34.774076},
       //         new Branch { Name = "חנות בוטיק",   City = "רחובות",
       //             Street = "הרצל", HouseNo = 12 , CoorX = 31.880079, CoorY =  34.818296},
       //         new Branch { Name = "חנות המפעל",   City = "אשדוד",
       //             Street = "הנריטה סולד", HouseNo = 6 , CoorX = 31.804151, CoorY =  34.652713, PhoneNo= "1800-656-656"}
       //     };
       //     branches.ForEach(s => context.Branches.AddOrUpdate(p => p.Name, s));
       //     context.SaveChanges();


       //     var products = new List<Product>
       //     {
       //         new Product { Name = "חולצה שמיימית",  Category = e_Category.SHIRTS,
       //                       Price = 100,  IsOnSale = false,
       //                       Image = "/Content/images/1.jpg", BranchID = 3, Size = e_Size.XS },
       //         new Product { Name = "חולצה יפה",  Category = e_Category.DRESSES,
       //                       Price = 80,  IsOnSale = true, Description = "!שמלה יפה מאוד מאוד",
       //                       Image = "/Content/images/11.jpg", BranchID = 3, Size = e_Size.M },
       //         new Product { Name = "שמלה קייצית",  Category = e_Category.DRESSES,
       //                       Price = 200,
       //                       Image = "/Content/images/12.jpg", BranchID = 3, Size = e_Size.S },
       //         new Product { Name = "מכנס קצר",  Category = e_Category.PANTS,
       //                       Price = 200,  IsOnSale = true, Description = "מכנס חמודי",
       //                       Image = "/Content/images/7.jpg", BranchID = 3, Size = e_Size.L },
       //         new Product { Name = "מכנס ארוך",  Category = e_Category.PANTS,
       //                       Price = 150,  IsOnSale = false,
       //                       Image = "/Content/images/10.jpg", BranchID = 3, Size = e_Size.S },

       //     };
       //     products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
       //     context.SaveChanges();

       //     var customers = new List<Customer>
       //     {
       //         new Customer { FirstName = "admin", LastName = "admin", Password = "123456", CreditCradNo = "1234567890123456",
       //                         City = "ראשון לציון", Email = "admin@gmail.com",  Age = 22},
       //         new Customer { FirstName = "אור",   LastName = "דניאל", Password = "123456", CreditCradNo = "1234567890123456",
       //                        City = "רמת גן", Email = "ordaniel888@gmail.com", Age = 22 },
       //         new Customer { FirstName = "xypbh",   LastName = "ג'ין", Password = "123456", CreditCradNo = "1234567890123456",
       //                        City = "אור יהודה", Email = "stephanieje20@gmail.com", Age = 22 },
       //     };
       //     customers.ForEach(s => context.Customers.AddOrUpdate(p => p.Email, s));
       //     context.SaveChanges();
       // }
    }
}
