using System;

namespace UseComputeSql
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            var o = new Orders
            {
                ProductName = "C#",
                Price = 120,
                Qty = 16
            };
            ctx.Orders.Add(o);
            ctx.SaveChanges();
            Console.WriteLine(o.Total);
            Console.ReadLine();
        }
    }
}
