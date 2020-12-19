using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UseSplitQuery
{
    class Program
    {
        static void AddData()
        {
            var ctx = new MyDBContext();
            var o = new Orders
            {
                CustomerName = "code6421",
                Details = new List<Order_Details>
                {
                    new Order_Details { Product = "C#", Price = 1200, Qty = 1},
                    new Order_Details { Product = "VBNET", Price = 1700, Qty = 1},
                }
            };
            ctx.Orders.Add(o);
            ctx.SaveChanges();
        }

        static void QueryDataSingle()
        {
            var ctx = new MyDBContext();
            var r = ctx.Orders.Include(b => b.Details).ToList();
        }

        static void QueryDataSplit()
        {
            var ctx = new MyDBContext();
            var r = ctx.Orders.AsSplitQuery().Include(b => b.Details).ToList();
        }
        static void Main(string[] args)
        {
            QueryDataSplit();
            Console.ReadLine();
        }
    }
}
