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
       //             BranchID= 10, Name= "������������", City = "�� ����", CoorX = 33, CoorY= 34, 
       //         },
       //         new Branch {  BranchID = 3,  Name = "�������",   City = "�� ����",
       //             Street = "�������", HouseNo = 15, CoorX = 32.063179, CoorY =  34.770962},
       //         new Branch { Name = "����� �����",   City = "�����",
       //             Street = "����� ����", HouseNo = 7, CoorX = 32.012288, CoorY =  34.77943 },
       //         new Branch { Name = "���� ����",   City = "�� ����",
       //             Street = "���� ����", HouseNo = 30 , CoorX = 32.072352, CoorY =  34.774076},
       //         new Branch { Name = "���� �����",   City = "������",
       //             Street = "����", HouseNo = 12 , CoorX = 31.880079, CoorY =  34.818296},
       //         new Branch { Name = "���� �����",   City = "�����",
       //             Street = "������ ����", HouseNo = 6 , CoorX = 31.804151, CoorY =  34.652713, PhoneNo= "1800-656-656"}
       //     };
       //     branches.ForEach(s => context.Branches.AddOrUpdate(p => p.Name, s));
       //     context.SaveChanges();


       //     var products = new List<Product>
       //     {
       //         new Product { Name = "����� �������",  Category = e_Category.SHIRTS,
       //                       Price = 100,  IsOnSale = false,
       //                       Image = "/Content/images/1.jpg", BranchID = 3, Size = e_Size.XS },
       //         new Product { Name = "����� ���",  Category = e_Category.DRESSES,
       //                       Price = 80,  IsOnSale = true, Description = "!���� ��� ���� ����",
       //                       Image = "/Content/images/11.jpg", BranchID = 3, Size = e_Size.M },
       //         new Product { Name = "���� ������",  Category = e_Category.DRESSES,
       //                       Price = 200,
       //                       Image = "/Content/images/12.jpg", BranchID = 3, Size = e_Size.S },
       //         new Product { Name = "���� ���",  Category = e_Category.PANTS,
       //                       Price = 200,  IsOnSale = true, Description = "���� �����",
       //                       Image = "/Content/images/7.jpg", BranchID = 3, Size = e_Size.L },
       //         new Product { Name = "���� ����",  Category = e_Category.PANTS,
       //                       Price = 150,  IsOnSale = false,
       //                       Image = "/Content/images/10.jpg", BranchID = 3, Size = e_Size.S },

       //     };
       //     products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
       //     context.SaveChanges();

       //     var customers = new List<Customer>
       //     {
       //         new Customer { FirstName = "admin", LastName = "admin", Password = "123456", CreditCradNo = "1234567890123456",
       //                         City = "����� �����", Email = "admin@gmail.com",  Age = 22},
       //         new Customer { FirstName = "���",   LastName = "�����", Password = "123456", CreditCradNo = "1234567890123456",
       //                        City = "��� ��", Email = "ordaniel888@gmail.com", Age = 22 },
       //         new Customer { FirstName = "xypbh",   LastName = "�'��", Password = "123456", CreditCradNo = "1234567890123456",
       //                        City = "��� �����", Email = "stephanieje20@gmail.com", Age = 22 },
       //     };
       //     customers.ForEach(s => context.Customers.AddOrUpdate(p => p.Email, s));
       //     context.SaveChanges();
       // }
    }
}
