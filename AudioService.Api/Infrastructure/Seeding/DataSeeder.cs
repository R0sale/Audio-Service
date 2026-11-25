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
        private const string PlaylistCoverUrl = "https://picsum.photos/seed/late-night-drive/512/512";

        private readonly IMediaStorage _mediaStorage;
        private readonly AudioDbContext _context;
        private readonly HttpClient _client;

        public DataSeeder(IMediaStorage mediaStorage, AudioDbContext context, HttpClient client)
        {
            _context = context;
            _mediaStorage = mediaStorage;
            _client = client;
        }

        private sealed record SeedTrack(string Title, string Artist, string? Album, int DurationInSeconds, int SoundHelixNumber, string CoverUrl);

        private static readonly SeedTrack[] SeedTracks =
        [
            new("Neon Avenue",   "Midnight Atlas", "City Lights",      372, 1, "https://picsum.photos/seed/neon-avenue/512/512"),
            new("Quiet Signals", "Lumen Field",    "Low Frequencies",  425, 2, "https://picsum.photos/seed/quiet-signals/512/512"),
            new("Glass Horizon", "Northbound",     "Open Roads",       344, 3, "https://picsum.photos/seed/glass-horizon/512/512"),
            new("Paper Planes",  "Sofa Theory",    "Weekend Sketches", 302, 4, "https://picsum.photos/seed/paper-planes/512/512"),
            new("Afterglow",     "Midnight Atlas", "City Lights",      353, 5, "https://picsum.photos/seed/afterglow/512/512"),
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
                var audioBlobName = $"{id}.mp3";
                var coverBlobName = $"{id}.jpg";

                await UploadFromUrlAsync(MediaKind.Audio, audioBlobName, $"https://www.soundhelix.com/examples/mp3/SoundHelix-Song-{seed.SoundHelixNumber}.mp3", "audio/mpeg", ct);
                await UploadFromUrlAsync(MediaKind.Cover, coverBlobName, seed.CoverUrl, "image/jpeg", ct);

                tracks.Add(new Track
                {
                    Id = id,
                    Title = seed.Title,
                    Album = seed.Album,
                    Artist = seed.Artist,
                    DurationInSeconds = seed.DurationInSeconds,
                    AudioBlobName = audioBlobName,
                    CoverBlobName = coverBlobName
                });
            }

            var playlistCoverBlobName = $"{Guid.NewGuid()}.jpg";
            await UploadFromUrlAsync(MediaKind.Cover, playlistCoverBlobName, PlaylistCoverUrl, "image/jpeg", ct);

            var playlist = new Playlist
            {
                Id= Guid.NewGuid(),
                CoverBlobName = playlistCoverBlobName,
                Description = "Synths for empty roads",
                Title = "Late Night Drive",
                Tracks = tracks.Select((track, index) => new PlaylistTrack { Order = index, Track = track }).ToList()
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
