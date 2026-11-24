using Application.Contracts;
using Application.Services;
using Infrastructure.Repositories;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;
using Infrastructure.Storage;
using Infrastructure.Seeding;

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
            services.AddSingleton<IMediaStorage, MediaStorage>();

            services.AddHttpClient();
            services.AddScoped<DataSeeder>();

            services.AddDbContext<AudioDbContext>(options => options.UseNpgsql(config.GetConnectionString("PostgresConnectionString")).UseSnakeCaseNamingConvention());

            return services;
        }

        public static IServiceCollection ConfigureStorage(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions<MediaStorageOptions>()
                .Bind(config.GetSection("Storage"));

            services.AddSingleton(x => new BlobServiceClient(config.GetConnectionString("AzuriteConnectionString")));

            return services;
        }
    }
}
