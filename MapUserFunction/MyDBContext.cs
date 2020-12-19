using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Text;

namespace MapUserFunction
{
    public class Customers
    {
        public int Id { get; set; }
        public string NAME { get; set; }
        public int CREDIT_LEVEL { get; set; }
    }

    public class MyDB2Context : DbContext
    {

        public virtual DbSet<Customers> Customers { get; set; }
        // map to
        /*        CREATE FUNCTION[dbo].[MySum]
                  (
                    @param1 int,
                    @param2 int
                  )
                 RETURNS INT AS
                BEGIN
                   RETURN @param1 + @param2
                END
                */
        [DbFunction("MySum")]
        public int MySum(int x, int y) => x + y;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=MyEFC_DB2;Integrated Security=True;Connect Timeout=30");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public MyDB2Context() { }

        public MyDB2Context(DbContextOptions<MyDB2Context> options) : base(options)
        {

        }
    }
}
