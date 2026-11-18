using Application.Commands;
using Application.Contracts;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PaymentGateway.Extensions
{
    public static class DIProvider
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ChargeCommand).Assembly));
            services.AddDbContext<PaymentDbContext>(options => options.UseNpgsql(config.GetConnectionString("PostgresConnectionString")));

            return services;
        }
    }
}
