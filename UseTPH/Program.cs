using System;

namespace UseTPH
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            ctx.Database.EnsureCreated();

            var emp = new Employees
            {
                Name = "code6421"
            };

            var manager = new Managers
            {
                Name = "jeff",
                Role = "RD Leader"
            };

            ctx.Employees.Add(emp);
            ctx.Managers.Add(manager);
            ctx.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}
