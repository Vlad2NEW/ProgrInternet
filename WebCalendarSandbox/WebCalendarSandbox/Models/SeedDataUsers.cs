using Microsoft.EntityFrameworkCore;
using WebCalendarSandbox.Data;

namespace WebCalendarSandbox.Models
{
    public static class SeedDataUsers
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebCalendarSandboxContext(
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
                        Password = "tgbbhu"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
