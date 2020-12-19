using System;
using System.Linq;
using System.Collections.Generic;

namespace PropertyBagDemo
{
    class Program
    {
        static void AddData()
        {
            var ctx = new MyDbContext();
            var rec1 = new Dictionary<string, object>
            {
                ["NAME"] = "mary",
                ["ADDRESS"] = "Taipei"
            };

            ctx.Customers.Add(rec1);
            ctx.SaveChanges();
        }

        static void QueryData()
        {
            var ctx = new MyDbContext();
            var r = ctx.Customers.FirstOrDefault(a => a["NAME"] == "tom12");
            Console.WriteLine(r["NAME"]);
        }
        

        static void Main(string[] args)
        {
            
            Console.ReadLine();
        }
    }
}
