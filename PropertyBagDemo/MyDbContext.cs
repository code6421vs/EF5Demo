using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyBagDemo
{
    public class MyDbContext : DbContext
    {
        public DbSet<Dictionary<string, object>> Customers => Set<Dictionary<string, object>>("Customers");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MYEFC_DB2;Integrated Security=True;Connect Timeout=30");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Customers", b =>
            {
                b.IndexerProperty<int>("Id");
                b.IndexerProperty<string>("NAME").IsRequired();
                b.IndexerProperty<string>("ADDRESS");
                b.IndexerProperty<int>("CREDIT_LEVEL");
            });
        }
    }
}
