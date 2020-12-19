using System;
using System.Collections.Generic;
using System.Linq;

namespace ManyToManyMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            ctx.Database.EnsureCreated();
            var d = new Doctors
            {
                Name = "jeff",
                Patients = new List<Patients>()
                {
                    new Patients { Name = "code6421"}
                }
            };

            ctx.Doctors.Add(d);
            ctx.SaveChanges();
        }
    }
}
