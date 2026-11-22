using Application.Contracts;
using Domain.Models;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TracksRepository : ITracksRepository
    {
        private readonly AudioDbContext _context;

        public TracksRepository(AudioDbContext context)
        {
            _context = context;
        }

        public async Task<Track?> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var track = await _context.Tracks.AsNoTracking().SingleOrDefaultAsync(x => x.Id == trackId, ct);

            return track;
        }
    }
}
