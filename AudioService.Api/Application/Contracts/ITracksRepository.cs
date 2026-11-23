using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface ITracksRepository
    {
        Task<Track?> GetTrackByIdAsync(Guid trackId, CancellationToken ct);
        Task<IEnumerable<Track>> GetPopularTracksAsync(int numberofTracks, CancellationToken ct);
    }
}
