using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RelationsIncludeFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            foreach(var item in ctx.Orders)
            {
                //ctx.Entry(item).Collection(a => a.OrderDetails).Load();
                Console.WriteLine(item.OrderDetails.FirstOrDefault()?.Product);
            }
            //var r = ctx.Orders.Include(a => a.OrderDetails.Where(b => b.Product.Contains("Go"))).ToList();
            Console.ReadLine();
        }
    }
}
