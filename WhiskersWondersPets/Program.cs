using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WhiskersWondersPets.Data;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
    string UsersconnectionString = builder.Configuration["ConnectionStrings:UsersConnection"]!;
    builder.Services.AddDbContext<AnimalsDBContext>(options => options.UseLazyLoadingProxies().UseSqlite(connectionString));

    builder.Services.AddDbContext<AuthenticationContext>(options => options.UseLazyLoadingProxies().UseSqlite(UsersconnectionString));

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationContext>();

    builder.Services.AddScoped<IRepository, AnimalsRepo>();
    builder.Services.AddControllersWithViews();

    //builder.Services.AddSession(options =>
    //{
    //    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the timeout duration
    //    options.Cookie.HttpOnly = true; // Set the cookie to be HttpOnly
    //    options.Cookie.IsEssential = true; // Make the session cookie essential
    //});

    // Add google auth services
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    }).AddCookie()
      .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
      {
          options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.ClientId = builder.Configuration["GoogleKeys:ClientId"]!;
          options.ClientSecret = builder.Configuration["GoogleKeys:ClientSecret"]!;
      });

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
    //app.UseSession();
    app.MapControllerRoute("Default", "{controller=Home}/{action=index}");


    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var context = services.GetRequiredService<AuthenticationContext>();

        await DbInitializer.Initialize(context, userManager, roleManager);
    }


    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex);
}
finally
{
    LogManager.Shutdown();
}

