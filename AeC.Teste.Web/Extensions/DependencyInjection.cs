using AeC.Teste.Web.Data;
using AeC.Teste.Web.Models;
using AeC.Teste.Web.Services;
using AeC.Teste.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AeC.Teste.Web.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
       this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login";
                        options.AccessDeniedPath = "/Account/Login";

                        options.Cookie.Name = "AeCTest.Auth";

                        options.ExpireTimeSpan = TimeSpan.FromHours(8);
                        options.SlidingExpiration = true;
                    });

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ICsvService, CsvService>();

            services.AddHttpClient<IViaCepService, ViaCepService>();

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
