namespace Market.DAL.Migrations
{
    using Market.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Market.DAL.MarketDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Market.DAL.MarketDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var category1 = new Category {Name = "Food", };
            //var category2 = new Category {Name = "Others", };
            //var product1 = new Product { Name = "Bread", CategoryId = 1, Count = 30, Price = 100 };
            //var product2 = new Product { Name = "Milk", CategoryId = 1, Count = 20, Price = 500 };
            //var product3 = new Product { Name = "Meat", CategoryId = 1, Count = 10, Price = 1000 };
            //var product4 = new Product { Name = "Butter", CategoryId = 1, Count = 30, Price = 600 };
            //var product5 = new Product { Name = "Chair", CategoryId = 2, Count = 30, Price = 600 };
            //var product6 = new Product { Name = "Table", CategoryId = 2, Count = 30, Price = 600 };
            //var product7 = new Product { Name = "Sofa", CategoryId = 2, Count = 30, Price = 600 };
            //category1.Products.Add(product1);
            //category1.Products.Add(product2);
            //category1.Products.Add(product3);
            //category1.Products.Add(product4);
            //category2.Products.Add(product5);
            //category2.Products.Add(product6);
            //category2.Products.Add(product7);

            //var transaction1 = new Transaction { CreationTime = DateTime.UtcNow, };
            //var transaction2 = new Transaction { CreationTime = DateTime.UtcNow, };

            //var transactionitem1 = new TransactionItem { ProductId =1 , ProductCount = 2, Price = 200, TransactionId = 1 };
            //var transactionitem2 = new TransactionItem { ProductId = 2, ProductCount = 1, Price = 500, TransactionId = 1 };

            //transaction1.TransactionItems.Add(transactionitem1);
            //transaction1.TransactionItems.Add(transactionitem2);

            //context.Categories.Add(category1);
            //context.Categories.Add(category2);
            //context.Products.Add(product1);
            //context.Products.Add(product2);
            //context.Products.Add(product3);
            //context.Products.Add(product4);
            //context.Products.Add(product5);
            //context.Products.Add(product6);
            //context.Products.Add(product7);
            //context.Transactions.Add(transaction1);
            //context.Transactions.Add(transaction2);
            //context.TransactionItems.Add(transactionitem1);
            //context.TransactionItems.Add(transactionitem2);

            //var user = new User { Id = 1, Name = "valod", Password = "vvvv" };
            //var token = new Token { Tokens = "bbb", User = user, UserId = user.Id, CreationTime = DateTime.UtcNow, ExpirationTime = DateTime.UtcNow.AddHours(5) };
            //context.Users.Add(user);
            //context.Tokens.Add(token);

        }
    }
}
