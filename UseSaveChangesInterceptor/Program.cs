using System;

namespace UseSaveChangesInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();

            var c = new Customers
            {
                Name = "code6421_newitem"
            };
            ctx.Customers.Add(c);
            ctx.SaveChanges();
        }
    }
}
