using Application.Contracts;
using Domain.Enums;
using Domain.Models;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Seeding
{
    public sealed class DataSeeder
    {
        private readonly IMediaStorage _mediaStorage;
        private readonly AudioDbContext _context;
        private readonly HttpClient _client;

        public DataSeeder(IMediaStorage mediaStorage, AudioDbContext context, HttpClient client)
        {
            _context = context;
            _mediaStorage = mediaStorage;
            _client = client;
        }

        private sealed record SeedTrack(string Title, string Artist, string? Album, int DurationInSeconds, int SoundHelixNumber);

        private static readonly SeedTrack[] SeedTracks =
        [
            new("Neon Avenue",   "Midnight Atlas", "City Lights",      372, 1),
            new("Quiet Signals", "Lumen Field",    "Low Frequencies",  425, 2),
            new("Glass Horizon", "Northbound",     "Open Roads",       344, 3),
            new("Paper Planes",  "Sofa Theory",    "Weekend Sketches", 302, 4),
            new("Afterglow",     "Midnight Atlas", "City Lights",      353, 5),
        ];

        public async Task SeedAsync(CancellationToken ct)
        {
            await _context.Database.MigrateAsync(ct);

            await _mediaStorage.EnsureContainersAsync(ct);

            if (await _context.Tracks.AnyAsync(ct))
                return;

            var tracks = new List<Track>();

            foreach (var seed in SeedTracks)
            {
                var id = Guid.NewGuid();
                var blobName = $"{id}.mp3";

                await UploadFromUrlAsync(MediaKind.Audio, blobName, $"https://www.soundhelix.com/examples/mp3/SoundHelix-Song-{seed.SoundHelixNumber}.mp3", "audio/mpeg", ct);

                tracks.Add(new Track
                {
                    Id = id,
                    Title = seed.Title,
                    Album = seed.Album,
                    Artist = seed.Artist,
                    DurationInSeconds = seed.DurationInSeconds,
                    AudioBlobName = blobName,
                    CoverBlobName = null
                });
            }

            var playlist = new Playlist
            {
                Id= Guid.NewGuid(),
                CoverBlobName = null,
                Description = "Synths for empty roads",
                Title = "Late Night Drive",
                Tracks = tracks.Select((track, index) => new PlaylistTrack { Order = index, Track = track}).ToList()
            };

            _context.Tracks.AddRange(tracks);
            _context.Playlists.Add(playlist);

            await _context.SaveChangesAsync();
        }

        private async Task UploadFromUrlAsync(MediaKind kind, string blobName, string url, string contentType, CancellationToken ct)
        {
            if (await _mediaStorage.ExistsAsync(kind, blobName, ct))
                return;

            using var response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, ct);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(ct);
            await _mediaStorage.UploadAsync(kind, blobName, contentType, stream, ct);
        }
    }
}
