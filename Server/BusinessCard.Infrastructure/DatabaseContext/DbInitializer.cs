using BusinessCard.Domain.Enums;
using BusinessCard.Infrastructure.DatabaseContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCard.Infrastructure
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            // Check if any records exist
            if (context.BusinessCards.Any())
            {
                return;
            }

            var businessCards = new[]
            {
                Domain.BusinessCard.Create("Alice Smith", Gender.Female, new DateTime(1990, 5, 1), "alice@example.com", "+1", "1234567890", "123 Elm St", "Springfield", "12345"),
                Domain.BusinessCard.Create("Bob Johnson", Gender.Male, new DateTime(1985, 3, 15), "bob@example.com", "+1", "0987654321", "456 Oak St", "Springfield", "12345"),
                Domain.BusinessCard.Create("Charlie Brown", Gender.Male, new DateTime(1992, 7, 22), "charlie@example.com", "+44", "1122334455", "789 Maple Ave", "London", "54321"),
                Domain.BusinessCard.Create("Diana Prince", Gender.Female, new DateTime(1988, 11, 11), "diana@example.com", "+44", "5566778899", "159 Pine St", "London", "54321"),
                Domain.BusinessCard.Create("Edward Elric", Gender.Male, new DateTime(1996, 4, 3), "edward@example.com", "+81", "1231231234", "852 Birch St", "Tokyo", "98765"),
                Domain.BusinessCard.Create("Fiona Green", Gender.Female, new DateTime(1994, 8, 30), "fiona@example.com", "+81", "4321432143", "963 Cedar St", "Tokyo", "98765"),
                Domain.BusinessCard.Create("George Martin", Gender.Male, new DateTime(1980, 12, 15), "george@example.com", "+61", "3213214321", "741 Spruce St", "Sydney", "54321"),
                Domain.BusinessCard.Create("Hannah White", Gender.Female, new DateTime(1995, 6, 18), "hannah@example.com", "+61", "6546546544", "852 Cedar Rd", "Sydney", "54321"),
                Domain.BusinessCard.Create("Ian Curtis", Gender.Male, new DateTime(1991, 1, 5), "ian@example.com", "+33", "9876543210", "963 Birch Dr", "Paris", "12345"),
                Domain.BusinessCard.Create("Julia Roberts", Gender.Female, new DateTime(1983, 10, 10), "julia@example.com", "+33", "6543217890", "258 Oak Rd", "Paris", "12345"),
            };

            await context.BusinessCards.AddRangeAsync(businessCards);
            await context.SaveChangesAsync();
        }
    }
}
