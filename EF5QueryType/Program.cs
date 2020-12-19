using System;
using System.Linq;  

namespace EF5QueryType
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            var r = ctx.Customers.Where(a => a.Name.Contains("code6421")).ToList();
            Console.ReadLine();
        }
    }
}
