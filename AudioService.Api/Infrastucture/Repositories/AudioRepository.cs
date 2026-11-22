using Application.Contracts;
using Domain.Models;
using Domain.Shared;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Infrastucture.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        private readonly AudioDbContext _context;

        public AudioRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Track>> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var track = await _context.Tracks.AsNoTracking().SingleOrDefaultAsync(x => x.Id == trackId, ct);

            if (track == null)
                return Result<Track>.Failure($"Couldn't find the track with track id: {trackId}");

            return Result<Track>.Success(track);
        }

        public async Task<Result<IEnumerable<Playlist>>> GetPlaylistsAsync(CancellationToken ct)
        {
            var playlists = await _context.Playlists.AsNoTracking().ToListAsync(ct);

            return Result<IEnumerable<Playlist>>.Success(playlists);
        }

        public async Task<Result<Playlist>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var playlist = await _context.Playlists.AsNoTracking()
            .Include(x => x.Tracks)
            .SingleOrDefaultAsync(x => x.Id == playlistId, ct);

            if (playlist == null)
                return Result<Playlist>.Failure($"Couldn't find the playlist with playlist id: {playlistId}");

            return Result<Playlist>.Success(playlist);
        }
    }
}
