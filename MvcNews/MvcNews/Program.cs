using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcNews.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services
    .AddIdentity<User, Role>(config =>
    {

        config.Password.RequiredLength = 1;
        config.Password.RequireDigit = false;
        config.Password.RequireUppercase = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireLowercase = false;

    })
    .AddEntityFrameworkStores<AppDbContext>();




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

CreateDefaultUserAndRoles().Wait();

app.Run();


async Task CreateDefaultUserAndRoles()
{
    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.Migrate();
    
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    var roles = new[] {
        new Role { Name = "Administrators" },
        new Role { Name = "Reporters" },
        new Role { Name = "Authors" },
        };

    foreach (var role in roles)
        if (!await roleManager.RoleExistsAsync(role.Name))
            await roleManager.CreateAsync(role);

    var user = new User
    {
        UserName = builder.Configuration.GetValue<string>("App:DefaultUser:UserName"),
        Name = builder.Configuration.GetValue<string>("App:DefaultUser:Name"),
       
    };

    var userExists = await userManager.FindByNameAsync(user.UserName);
    if (userExists == null)
    {
        var result = await userManager.CreateAsync(user, builder.Configuration.GetValue<string>("App:DefaultUser:Password"));
        if (result.Succeeded)
            await userManager.AddToRoleAsync(user, "Administrators");
    }


}