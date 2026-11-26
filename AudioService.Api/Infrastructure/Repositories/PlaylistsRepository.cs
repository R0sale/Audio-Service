using Application.Contracts;
using Domain.Models;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PlaylistsRepository : IPlaylistsRepository
    {
        private readonly AudioDbContext _context;

        public PlaylistsRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct)
        {
            var playlists = await _context.Playlists.AsNoTracking().ToListAsync(ct);

            return playlists;
        }

        public async Task<Playlist?> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var playlist = await _context.Playlists.AsNoTracking()
                .Include(x => x.Tracks)
                .ThenInclude(x => x.Track)
                .SingleOrDefaultAsync(x => x.Id == playlistId, ct);

            return playlist;
        }

        public async Task<IEnumerable<Playlist>> GetFeaturedPlaylistsAsync(int numberOfPlaylists, CancellationToken ct)
        {
            var playlists = await _context.Playlists.AsNoTracking()
                .Include(x => x.Tracks)
                .ThenInclude(x => x.Track)
                .OrderBy(x => x.Title)
                .Take(numberOfPlaylists)
                .ToListAsync(ct);

            return playlists;
        }
    }
}
