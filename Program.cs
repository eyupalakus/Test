using System;
using System.Data.Entity;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Create();
            }
            catch (Exception)
            {
                Console.WriteLine("You continue through the created database");                
            }
            
            Console.WriteLine("Welcome,Enter number to choose\n1=Add\n2=Update\n3=Delete\n4=Show");
            var General_Choice = Convert.ToInt32(Console.ReadLine());
            switch (General_Choice)
            {
                case 1:
                    {
                        Add();
                        break;
                    }
                case 2:
                    {
                        Update();
                        break;
                    }
                case 3:
                    {
                        Delete();
                        break;
                    }
                case 4:
                    {
                        Show();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect entry");
                        break;
                    }
            }

        }
        private static void Update()
        {
            Show();
            Console.WriteLine("Enter the ID of the product you want to update");
            int Update_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number to update\n1=Product Name\n2=Stock Amount\n3=UnitPrice");
            int choice = Convert.ToInt32(Console.ReadLine());
            using (var context = new ETradeContext())
            {
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter new product name");
                            var New_ProductName = Console.ReadLine();
                            Product product = context.products.Find(Update_Id);
                            product.ProductName=New_ProductName;
                            context.SaveChanges();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter new stock amount");
                            var New_StockAmount = Convert.ToInt32(Console.ReadLine());
                            Product product = context.products.Find(Update_Id);
                            product.StockAmount = New_StockAmount;
                            context.SaveChanges();
                            break;
                            
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter new unit price");
                            var New_UnitPrice = Convert.ToInt32(Console.ReadLine());
                            Product product = context.products.Find(Update_Id);
                            product.UnitPrice = New_UnitPrice;
                            context.SaveChanges();
                            break;
                           
                        }
                    default:
                        Console.WriteLine("Incorrect entry");
                        break;
                }

            }
            Show();
        }

        private static void Delete()
        {
            Show();
            Console.WriteLine("Enter the ID of the product you want to delete");
            int Delete_Id = Convert.ToInt32(Console.ReadLine());

            using (var context = new ETradeContext())
            {
                var entity = context.Entry(new Product
                {
                    Id = Delete_Id
                });
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }

            Show();
            Console.WriteLine("Product is deleted");
        }

        private static void Create()
        {
            using (var context = new ETradeContext())
            {
                context.Database.Create();

            }
        }

        private static void Show()
        {
            using (var context = new ETradeContext())
            {
                foreach (var item in context.products)
                {
                    Console.WriteLine("Product Id = {0}, Product Name = {1} , Product Stock Amount = {2} , Product Unit Price = {3}", item.Id, item.ProductName, item.StockAmount, item.UnitPrice);
                }
            }
        }

        private static void Add()
        {
            Console.WriteLine("Enter Product Name");
            var Add_ProductName = Console.ReadLine();
            Console.WriteLine("Enter Stock Amount");
            var Add_StockAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Unit Price");
            var Add_UnitPrice = Convert.ToInt32(Console.ReadLine());
            using (var context = new ETradeContext())
            {
                var entity = context.Entry(new Product
                {
                    ProductName = Add_ProductName,
                    StockAmount = Add_StockAmount,
                    UnitPrice = Add_UnitPrice
                });
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
