using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace DbContextDemo
{
    class Program
    { 
        static void ContextLifetime()
        {
            var ctx = new MyDBContext();
            for(var i = 0; i < 100; i++)
            {
                var c = new Customers
                {
                    Name = $"code6421{i}",
                    Address = "Taipei"
                };
                ctx.Customers.Add(c);
            }

            ctx.SaveChanges();

            //now dbcontext has 100 entities
            var c1 = new Customers
            {
                Name = $"code6421-{DateTime.Now.ToFileTime()}"
            };
            ctx.Customers.Add(c1);
            //below save changes will compare 100+1 to tracking for update
            ctx.SaveChanges();
        }

        static void ContextLifetime2()
        {
            var ctx = new MyDBContext();
            for (var i = 0; i < 3; i++)
            {
                var c = new Customers
                {
                    Name = $"code6421{i}",
                    Address = "Taipei"
                };
                ctx.Customers.Add(c);
            }

            ctx.SaveChanges();
            Console.WriteLine($"before clean tracking {ctx.ChangeTracker.Entries().Count()}");
            ctx.ChangeTracker.Clear(); //clean all saved entities

            //now dbcontext is clean
            Console.WriteLine($"after clean tracking {ctx.ChangeTracker.Entries().Count()}");
        }

        static void Main(string[] args)
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Benchmark(QueryEF, "EF");
            //    Benchmark(QueryEF_NoTracking, "EF(No Tracking)");
            //    Benchmark(QueryDapper, "Dapper");
            //}
            ContextLifetime2();


            Console.ReadLine();
        }
    }
}
