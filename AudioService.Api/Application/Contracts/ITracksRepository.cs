using Domain.Models;

namespace Application.Contracts
{
    public interface ITracksRepository
    {
        Task<Track?> GetTrackByIdAsync(Guid trackId, CancellationToken ct);
        Task<IEnumerable<Track>> GetPopularTracksAsync(int numberofTracks, CancellationToken ct);
    }
}
