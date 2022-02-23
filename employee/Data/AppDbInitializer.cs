using employee.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace employee.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new Employee()
                    {
                        Name = "Jhon Wwllson",
                        Email = "jhonwillson",
                        Position = "UX Design",
                        Office = "Texas",
                        Phone_nr = 0484548,
                        Salary = 3000,
                    },
                    new Employee()
                    {
                        Name = "William Scot",
                        Email = "williamscot",
                        Position = "Web Developer",
                        Office = "New York",
                        Phone_nr = 0254868,
                        Salary = 3500,
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
