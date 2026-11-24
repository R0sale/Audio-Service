using Application.DTOs;
using Domain.Shared;

namespace Application.Contracts
{
    public interface ITracksService
    {
        Task<Result<TrackDto>> GetTrackByIdAsync(Guid trackId, CancellationToken ct);
        Task<IEnumerable<TrackDto>> GetPopularTracksAsync(int numberofTracks, CancellationToken ct);
    }
}
