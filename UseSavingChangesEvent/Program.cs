using System;

namespace UseSavingChangesEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyDBContext();
            ctx.SavingChanges += Ctx_SavingChanges;
            ctx.SavedChanges += Ctx_SavedChanges;

            var c = new Customers
            {
                Name = "code6421_newitem",
                Address = "Tainan"
            };
            ctx.Customers.Add(c);
            ctx.SaveChanges();
        }

        private static void Ctx_SavedChanges(object sender, Microsoft.EntityFrameworkCore.SavedChangesEventArgs e)
        {
            Console.WriteLine("after save");            
        }

        private static void Ctx_SavingChanges(object sender, Microsoft.EntityFrameworkCore.SavingChangesEventArgs e)
        {
            Console.WriteLine("before save");
            foreach (var item in ((MyDBContext)sender).ChangeTracker.Entries())
            {
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added && item.Entity is Customers)
                {
                    var c = (Customers)item.Entity;
                    if (string.IsNullOrEmpty(c.Address))
                        throw new ArgumentException("Address must have value");
                }
            }
        }
    }
}
