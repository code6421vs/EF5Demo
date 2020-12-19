using Microsoft.Extensions.DependencyInjection;
using System;

namespace UseDbContextFactory
{
    class Program
    {
        static IServiceProvider provider;

        static void Setup()
        {
            var sc = new ServiceCollection();
            sc.AddDbContextFactory<MyDBContext>();
            sc.AddTransient<MyService1>();
            provider = sc.BuildServiceProvider();
        }

        static void Main(string[] args)
        {
            Setup();
            var service = provider.GetRequiredService<MyService1>();
            service.WorkIt();
            Console.Read();
        }
    }
}
