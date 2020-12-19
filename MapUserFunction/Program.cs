using System;
using System.Linq;

namespace MapUserFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDB2Context();
            var result = (from s1 in ctx.Customers select ctx.MySum(s1.CREDIT_LEVEL, 12)).FirstOrDefault();
            Console.WriteLine(result);
        }
    }
}
