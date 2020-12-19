using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyBagDemo
{
    public static class DynamicQuery2
    {
        static void QueryData3(Dictionary<string, object> query)
        {
            var ctx = new MyDbContext();
            if (query.Count == 0)
                throw new ArgumentException("query is empty");
            IQueryable<Dictionary<string, object>> tempQuery = ctx.Customers;
            foreach (var item in query)
            {
                tempQuery = tempQuery.Where(a => a[item.Key] == query[item.Key]);
            }

            foreach (var item in tempQuery)
            {
                Console.WriteLine(item["NAME"]);
            }
        }

        public static void Run()
        {
            var d = new Dictionary<string, object>
            {
                ["ADDRESS"] = "Taipei"
            };

            QueryData3(d);
        }

    }
}
