using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCalendarSandbox.Models;

namespace WebCalendarSandbox.Data
{
    public class WebCalendarSandboxContext : DbContext
    {
        public WebCalendarSandboxContext (DbContextOptions<WebCalendarSandboxContext> options)
            : base(options)
        {
        }

        public DbSet<WebCalendarSandbox.Models.CalendarSystem> CalendarSystem { get; set; } = default!;
        public DbSet<WebCalendarSandbox.Models.User> User { get; set; } = default!;
    }
}
