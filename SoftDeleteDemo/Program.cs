using System;
using System.Linq;

namespace SoftDeleteDemo
{
    class Program
    {
        static void AddData()
        {
            var ctx = new MyDBContext();
            var c = new Products
            {
                Name = "C#",
                Price = 1200
            };

            var c1 = new Products
            {
                Name = "VBNET",
                Price = 1600
            };

            ctx.Products.Add(c);
            ctx.Products.Add(c1);
            ctx.SaveChanges();
        }

        static void QueryData()
        {
            var ctx = new MyDBContext();
            foreach (var item in ctx.Products)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        static void DeleteData()
        {
            var ctx = new MyDBContext();
            var r = ctx.Products.FirstOrDefault(a => a.Name == "C#");
            ctx.Products.Remove(r);
            ctx.SaveChanges();
        }

        static void Main(string[] args)
        {
            QueryData();
        }
    }
}
