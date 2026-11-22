using Application.Contracts;
using Domain.Models;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Track> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var track = await _context.Tracks.AsNoTracking().SingleAsync(x => x.Id == trackId, ct);

            return track;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct)
        {
            var playlists = await _context.Playlists.AsNoTracking().ToListAsync(ct);

            return playlists;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var playlist = await _context.Playlists.AsNoTracking()
                .Include(x => x.Tracks)
                .SingleAsync(x => x.Id == playlistId, ct);

            return playlist;
        }
    }
}
