using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyBagDemo
{
    public static class DynamicQuery1
    {
        static void QueryData2(string key, string value)
        {
            var ctx = new MyDbContext();
            var r = ctx.Customers.FirstOrDefault(a => a[key] == value);
            Console.WriteLine(r["NAME"]);
        }

        public static void Run()
        {
            QueryData2("NAME", "code6421");
        }
    }
}
