using System;
using System.Linq;

namespace UseSavepoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            using(var trans = ctx.Database.BeginTransaction())
            {                
                var r = ctx.Customers.FirstOrDefault();
                r.Name = "testmodify";
                ctx.SaveChanges();

                trans.CreateSavepoint("ver1");
                //create savepoint ver1
                r.Name = "testmodify3";
                ctx.SaveChanges(); //commit testmodify3
                //rollback to ver1, now the name is testmodify
                trans.RollbackToSavepoint("ver1");
                trans.Commit();
            }
            Console.ReadLine();
        }
    }
}
