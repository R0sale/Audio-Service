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
    }
}
