using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace UseDbContextFactory
{
    public class MyService1 : IMyService1
    {
        private IDbContextFactory<MyDBContext> contextFactory;

        public MyService1(IDbContextFactory<MyDBContext> factory)
        {
            contextFactory = factory;
        }

        public void WorkIt()
        {
            using var ctx = contextFactory.CreateDbContext();
            foreach (var item in ctx.Customers.Take(10))
            {
                Console.WriteLine($"Name: {item.Name}");
            }
        }
    }
}
