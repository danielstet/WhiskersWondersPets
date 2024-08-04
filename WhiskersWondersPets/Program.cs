using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WhiskersWondersPets.Data;
using WhiskersWondersPets.Repository;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<IRepository, MyRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
//builder.Services.AddDbContext<DataBase>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<AnimalsDBContext>(options => options.UseLazyLoadingProxies().UseSqlite(connectionString));
builder.Services.AddScoped<IRepository, AnimalsRepo>();
builder.Services.AddControllersWithViews();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalsDBContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("Default", "{controller=Home}/{action=index}");

app.Run();
