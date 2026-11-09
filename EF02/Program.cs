using Microsoft.EntityFrameworkCore;
using EF02.DbContexts;
namespace EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EventHubDbContexts();
            context.Database.EnsureCreated();
            Console.WriteLine("EventHub Database and tables created successfully with all rules and relationships!");
        }
    }
}
