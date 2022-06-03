using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SuperMarketManagement.Application.Interfaces.Product;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Services.Product;
using SuperMarketManagement.Application.Services.User;
using SuperMarketManagement.Data.Context;
using SuperMarketManagement.Data.Repositories.Product;
using SuperMarketManagement.Data.Repositories.User;
using SuperMarketManagement.Domain.Interfaces.Product;
using SuperMarketManagement.Domain.Interfaces.User;

namespace SuperMarketManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region services

            #region mvc

            builder.Services.AddControllersWithViews();

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + "\\wwwroot\\AuthorizeFile\\"))
                .SetApplicationName("SuperMarketManagement")
                .SetDefaultKeyLifetime(TimeSpan.FromMinutes(43200));

            #endregion

            #region Context

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var connectionString = configuration.GetConnectionString("SuperMarketDBConnection");

            builder.Services.AddDbContext<SuperMarketDbContext>(option =>
            {
                option.UseSqlServer(connectionString);

            });

            #endregion

            #region IoC

            #region user

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            #endregion

            #region product

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            #endregion

            #endregion

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region pipelines and middlewares

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            #endregion
        }
    }
}