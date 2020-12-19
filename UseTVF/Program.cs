using System;
using System.Linq;

namespace UseTVF
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            var r = ctx.GetCustomerByName("%17%");
            foreach(var item in r.OrderBy(a => a.Id).Take(15))
            {
                Console.WriteLine($"{item.NAME}");
            }
            Console.Read();
        }
    }
}
