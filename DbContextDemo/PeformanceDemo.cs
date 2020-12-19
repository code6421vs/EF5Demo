using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextDemo
{
    public static class PeformanceDemo
    {
        static void GenerateCustomersV3()
        {
            var ctx = new MyDBContext();
            const string characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var data = new List<Customers>();
            for (int i = 0; i < 10000; i++)
            {
                data.Add(new Customers()
                {
                    Name = new string(Enumerable.Repeat(characters, 10).Select(a => a[random.Next(a.Length)]).ToArray()),
                    Address = new string(Enumerable.Repeat(characters, 10).Select(a => a[random.Next(a.Length)]).ToArray())
                });
            }
            ctx.Customers.AddRange(data);
            ctx.SaveChanges();
        }

        static void QueryEF()
        {
            var ctx = new MyDBContext();
            var data = ctx.Customers.Where(a => a.Name.Contains("c")).ToList();
        }

        static void QueryEF_NoTracking()
        {
            var ctx = new MyDBContext();
            var data = ctx.Customers.AsNoTracking().Where(a => a.Name.Contains("c")).ToList();
        }

        static void QueryDapper()
        {
            using var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MYEFC_DB2;Integrated Security=True;Connect Timeout=30");
            var data = conn.Query<Customers>("SELECT * FROM Customers Where NAME Like '%c'").ToList(); ;
        }

        static void Benchmark(Action f, string label)
        {
            var sw = new Stopwatch();
            sw.Start();
            f();
            sw.Stop();
            Console.WriteLine($"{label} elapsed {sw.ElapsedMilliseconds} ms");
        }
    }
}
