using Application.Contracts;
using Application.Services;
using Infrastructure.Repositories;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AudioService.Api.Extensions
{
    public static class DIProvider
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPlaylistsRepository, PlaylistsRepository>();
            services.AddScoped<IPlaylistsService, PlaylistsService>();
            services.AddScoped<ITracksRepository, TracksRepository>();
            services.AddScoped<ITracksService, TracksService>();

            services.AddDbContext<AudioDbContext>(options => options.UseNpgsql(config.GetConnectionString("PostgresConnectionString")).UseSnakeCaseNamingConvention());

            return services;
        }
    }
}
