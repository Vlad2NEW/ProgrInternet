using Microsoft.EntityFrameworkCore;
using WebCalendarSandbox.Data;

namespace WebCalendarSandbox.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebCalendarSandboxContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebCalendarSandboxContext>>()))
            {
                // Look for any CalendarSystem.
                if (context.CalendarSystem.Any())
                {
                    return;
                }
                context.CalendarSystem.AddRange(
                    new CalendarSystem
                    {
                        Name = "MyCalendarSystem",
                        Author = "Vlad Kvit",
                        ReleaseDate = DateTime.Parse("2020-12-21"),
                        isAbstract = false,
                        MonthCount = 12,
                        DaysPerWeek = 7,
                    }
                );
                using (var context1 = new WebCalendarSandboxContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebCalendarSandboxContext>>()))
                {
                    // Look for any Songs.
                    if (context.User.Any())
                    {
                        return;
                    }
                    context.User.AddRange(
                        new User
                        {
                            Nickname = "Admin",
                            Email = "kvitvladyslav0@gmail.com",
                            Password = "#1dmIn"
                        },
                        new User
                        {
                            Nickname = "Vlad Kvit",
                            Email = "kvitvladyslav@gmail.com",
                            Password = "q1w2e3r4t5y6u7i8o9p0"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
