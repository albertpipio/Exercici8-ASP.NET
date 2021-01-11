using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorEmpleats.Data;
using System;
using System.Linq;

namespace RazorEmpleats.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmpleatContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EmpleatContext>>()))
            {
                // Look for any movies.
                if (context.EmpleatInfo.Any())
                {
                    return;   // DB has been seeded
                }

                context.EmpleatInfo.AddRange(
                    new EmpleatInfo
                    {
                        Name = "Albert",
                        Surname = "Pipió",
                        Position = "CEO",
                        Salary = 4500
                    },

                    new EmpleatInfo
                    {
                        Name = "Steven",
                        Surname = "Spielberg",
                        Position = "Marketing",
                        Salary = 3500
                    },

                    new EmpleatInfo
                    {
                        Name = "Steve",
                        Surname = "Wozniak",
                        Position = "CTO",
                        Salary = 2500
                    },

                    new EmpleatInfo
                    {
                        Name = "Steve",
                        Surname = "Jobs",
                        Position = "Intern",
                        Salary = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}