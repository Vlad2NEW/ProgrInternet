using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebCalendarSandbox.Data;
using WebCalendarSandbox.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebCalendarSandboxContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebCalendarSandboxContext")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
