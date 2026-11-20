using Application.Contracts;
using Infrastucture.Persistence;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AudioService.Api.Extensions
{
    public static class DIProvider
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAudioRepository, AudioRepository>();
            services.AddScoped<IAudioService, Application.Services.AudioService>();

            services.AddDbContext<AudioDbContext>(options => options.UseNpgsql(config.GetConnectionString("PostgresConnectionString")));

            return services;
        }
    }
}
