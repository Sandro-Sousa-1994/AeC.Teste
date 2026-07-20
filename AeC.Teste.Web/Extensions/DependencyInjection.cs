using AeC.Teste.Web.Data;
using AeC.Teste.Web.Services;
using AeC.Teste.Web.Services.Interfaces;
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

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ICsvService, CsvService>();

            services.AddHttpClient<IViaCepService, ViaCepService>();

            return services;
        }
    }
}
