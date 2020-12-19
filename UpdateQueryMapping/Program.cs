using System;
using System.Linq;

namespace UpdateQueryMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            foreach(var item in ctx.Customers)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.WriteLine("press key to change data");
            Console.ReadLine();
            var r = ctx.Customers.FirstOrDefault();
            r.Name = $"code6421_modify_view{DateTime.Now.ToFileTime()}";
            ctx.SaveChanges();
        }
    }
}
