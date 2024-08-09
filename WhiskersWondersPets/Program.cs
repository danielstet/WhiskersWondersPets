using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WhiskersWondersPets.Data;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<IRepository, MyRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
string UsersconnectionString = builder.Configuration["ConnectionStrings:UsersConnection"]!;
//builder.Services.AddDbContext<DataBase>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<AnimalsDBContext>(options => options.UseLazyLoadingProxies().UseSqlite(connectionString));
builder.Services.AddDbContext<AuthenticationContext>(options => options.UseLazyLoadingProxies().UseSqlite(UsersconnectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationContext>();
builder.Services.AddScoped<IRepository, AnimalsRepo>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalsDBContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}

app.UseAuthentication();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("Default", "{controller=Home}/{action=index}");
app.MapControllerRoute(
    name: "account",
    pattern: "Account/{action=Login}/{id?}",
    defaults: new { controller = "Account", action = "Login" });

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var context = services.GetRequiredService<AuthenticationContext>();

    await DbInitializer.Initialize(context, userManager, roleManager);
}


app.Run();
