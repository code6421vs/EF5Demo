using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace UseChangeProxies
{
    class Program
    {
        static void AddData()
        {
            var ctx = new MyDBContext();
            for(var i = 0; i < 100; i++)
            {
                var o = new Customers
                {
                    Name = $"code6421{i}",
                    Address = "Taipei"
                };
                ctx.Customers.Add(o);
            }
            ctx.SaveChanges();
        }

        static void ChangeData()
        {
            var ctx = new MyDBContext();
            foreach(var item in ctx.Customers)
            {
                item.Name = $"{item.Name}-{DateTime.Now.ToFileTime()}";                
            }
            ctx.SaveChanges();
        }

        static void Main(string[] args)
        {
            ChangeData();
            Console.ReadLine();
        }
    }
}
