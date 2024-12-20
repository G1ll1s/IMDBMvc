using IMDBMvc.Models;
using IMDBMvc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IMDBMvc
{
    /// <summary>
    /// Oscar Gillberg
    /// BUV23
    /// Slutuppgift ASP.NET Core MVC
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<DataService>(); // Dependency Injection
            builder.Services.AddTransient<AccountService>();
            builder.Services.AddTransient<StateService>();

            var connString = builder.Configuration
                .GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(
                o => o.UseSqlServer(connString));

            // 1. Registera identity-klasserna och vilken DbContext som ska användas
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Här kan vi (om vi vill) ange inställningar för t.ex. lösenord
                // (ofta struntar man i detta och kör på default-värdena)
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
            
            // 2. Specificera att cookies ska användas och URL till inloggnings-sidan
            builder.Services.ConfigureApplicationCookie(
                o => o.LoginPath = "/login");
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            // Kör ALLTID MapControllerRoute eftersom allt annat fuckar upp!
            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=Movie}/{action=Index}/{id?}");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            
            app.Run();
        }
    }
}
